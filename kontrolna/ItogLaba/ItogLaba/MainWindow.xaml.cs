using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using LIB090;
using System.Diagnostics;
using System.Threading;
using System.Windows.Threading;
using System.Reflection;

namespace ItogLaba
{
    public partial class MainWindow : Window
    {
        private List<TestQuestion> testQuestions;
        private int currentQuestionIndex;
        private DispatcherTimer timer;
        private DateTime startTime;
        private bool isTestFinished = false;

        public MainWindow()
        {
            InitializeComponent();
            Process currentProcess = Process.GetCurrentProcess();
            currentProcess.PriorityClass = ProcessPriorityClass.High;
            currentProcess.ProcessorAffinity = (IntPtr)0x0001;
            Loaded += MainWindow_Loaded;
            gen.Click += gen_Click;
            pokaz.Click += pokaz_Click;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await InitializeTest();
        }

        private void pokaz_Click(object sender, RoutedEventArgs e)
        {
            // Показывает правильные ответы без маскировки
            dataGrid.Columns[3].Visibility = Visibility.Visible;

            // Обновляет привязку данных в DataGrid, чтобы отобразить изменения
            dataGrid.Items.Refresh();
        }

        private async void gen_Click(object sender, RoutedEventArgs e)
        {
            // Проверка на корректное введенное число в TextBox
            if (int.TryParse(kolVop.Text, out int numberOfQuestions))
            {
                // Генерация новых вопросов
                testQuestions = await Task.Run(() => GenerateTestQuestionsAsync(numberOfQuestions));

                // Обновление DataGrid
                dataGrid.ItemsSource = testQuestions;

                // Запуск таймера только если он не активен
                if (!timer.IsEnabled)
                {
                    startTime = DateTime.Now;
                    timer.Start();
                }

                // Сброс флага завершения теста
                isTestFinished = false;
                dataGrid.Columns[3].Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Введите корректное число в поле 'Количество вопросов'", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task InitializeTest()
        {
            // Настройка DataGrid
            dataGrid.AutoGenerateColumns = false;

            // Получение пути к файлу russian.txt
            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "russian.txt");

            // Инициализация библиотеки с использованием пути к файлу
            Class1.Initialize(filePath);

            // Заполнение вопросов
            testQuestions = await Task.Run(() => GenerateTestQuestionsAsync(10));

            // Установка источника данных для DataGrid
            dataGrid.ItemsSource = testQuestions;
        }


        private async Task<List<TestQuestion>> GenerateTestQuestionsAsync(int numberOfQuestions)
        {
            var questions = new List<TestQuestion>();

            for (int i = 0; i < numberOfQuestions; i++)
            {
                // Получение следующего случайного слова из библиотеки
                string randomWord = Class1.GetNextRandomWord();

                // Замените одно случайное слово на ".." в вопросе
                string maskedQuestion = MaskRandomWord(randomWord);

                questions.Add(new TestQuestion(randomWord)
                {
                    Number = i + 1,
                    Question = maskedQuestion,
                    CorrectAnswer = randomWord,
                    MaskedCorrectAnswer = MaskRandomWord(randomWord),  // Сохранение замаскированного правильного ответа
                    UserAnswer = "",
                    IsCorrect = false
                });
            }

            return questions;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Обновление таймера на форме
            if (!isTestFinished)  // Если тест не завершен, обновляем таймер
            {
                var elapsedTime = DateTime.Now - startTime;
                timerLabel.Content = $"{elapsedTime:mm\\:ss}";
            }
        }

        private string CalculateGrade(double percentage)
        {
            // Ваш код для расчета оценки
            // Пример: Если процент >= 90, то "Отлично", если >= 70, то "Хорошо", и так далее...
            if (percentage >= 90)
                return "Отлично";
            else if (percentage >= 70)
                return "Хорошо";
            else if (percentage >= 50)
                return "Удовлетворительно";
            else
                return "Неудовлетворительно";
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверка ответов и раскраска строк в DataGrid
            foreach (var question in testQuestions)
            {
                question.IsCorrect = question.UserAnswer.Equals(question.CorrectAnswer, StringComparison.OrdinalIgnoreCase);
            }

            // Оценка и вывод результатов
            int correctAnswersCount = testQuestions.Count(q => q.IsCorrect);
            double percentage = (double)correctAnswersCount / testQuestions.Count * 100;

            // Раскрашивание строк в DataGrid
            for (int i = 0; i < testQuestions.Count; i++)
            {
                var row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(i);
                if (testQuestions[i].IsCorrect)
                    row.Background = Brushes.Green;
                else
                    row.Background = Brushes.Red;
            }

            // Отображение правильных ответов и скрытие кнопки
            ShowCorrectAnswers();

            // Оценка и вывод результатов
            string grade = CalculateGrade(percentage);
            MessageBox.Show($"Результат: {correctAnswersCount} из {testQuestions.Count} правильных ответов. Оценка: {grade}\nВремя:{timerLabel.Content}");
            timer.Stop();

            isTestFinished = true;
        }

        private void ShowCorrectAnswers()
        {
            // Раскрывает столбец с правильными ответами
            dataGrid.Columns[3].Visibility = Visibility.Visible;

            // Обновляет привязку данных в DataGrid, чтобы отобразить изменения
            dataGrid.Items.Refresh();
        }

        private string MaskRandomWord(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return word;
            }

            Random random = new Random();
            int indexToMask = random.Next(0, word.Length);
            StringBuilder maskedWord = new StringBuilder(word);

            // Replace one random letter with ".."
            maskedWord[indexToMask] = '*';

            return maskedWord.ToString();
        }

        public class TestQuestion
        {
            public int Number { get; set; }
            public string Question { get; set; }
            public string CorrectAnswer { get; set; }
            public string MaskedCorrectAnswer { get; set; }  // Замаскированный правильный ответ
            public string OriginalCorrectAnswer { get; set; }  // Оригинальный правильный ответ
            public string UserAnswer { get; set; }
            public bool IsCorrect { get; set; }
            public TestQuestion(string originalCorrectAnswer)
            {
                OriginalCorrectAnswer = originalCorrectAnswer;
            }
        }
    }
}

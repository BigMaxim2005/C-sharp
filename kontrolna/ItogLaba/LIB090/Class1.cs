using System;
using System.IO;

namespace LIB090
{
    public class Class1
    {
        private static string[] words;
        private static int currentIndex;
        private static Random random = new Random();

        public static void Initialize(string filePath)
        {
            words = File.ReadAllLines("C:\\Users\\090\\source\\repos\\ItogLaba\\LIB090\\russian.txt");
            ShuffleWords();
            currentIndex = 0;
        }

        private static void ShuffleWords()
        {
            int n = words.Length;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                string value = words[k];
                words[k] = words[n];
                words[n] = value;
            }
        }

        public static string GetNextRandomWord()
        {
            if (words == null || words.Length == 0)
            {
                throw new InvalidOperationException("Список слов не инициализирован.");
            }

            if (currentIndex >= words.Length)
            {
                // Если достигнут конец списка, перемешиваем слова и сбрасываем индекс
                ShuffleWords();
                currentIndex = 0;
            }

            string nextWord = words[currentIndex];
            currentIndex++;

            return nextWord;
        }
    }
}

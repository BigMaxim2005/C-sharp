using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Shapes;

namespace lab_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CheckBox checkBox = new CheckBox { Content = "Новый флажок", MinHeight = 20,IsChecked= true };
            checkBox.Checked += checkBox_Checked;
            stack5.Children.Add(checkBox);
            RadioButton rb = new RadioButton { IsChecked = true, GroupName = "Boot", Content= "Boot4" };
            rb.Checked += RadioButton_Checked;
            stack6.Children.Add(rb);


            ToolTip toolTip = new ToolTip();
            StackPanel toolTipPanel = new StackPanel();
            toolTipPanel.Children.Add(new TextBlock { Text = "Кнопка", FontSize = 16 });
            toolTipPanel.Children.Add(new TextBlock { Text = "с подсказкой" });
            toolTip.Content = toolTipPanel;
            button.ToolTip = toolTip;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Кнопка нажата");
        }
        private void escButton_Click(object sender,RoutedEventArgs e)
        {
            this.Close();
        }
        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cостояние кнопки: " + (sender as System.Windows.Controls.Primitives.ToggleButton).IsChecked);
        }
        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chBox = (CheckBox)sender;
            MessageBox.Show(checkBox.Content.ToString() + " отмечен");
        }
        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(checkBox.Content.ToString() + " не отмечен");
        }
        private void checkBox_Indeterminate(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(checkBox.Content.ToString() + " в неопределённом состоянии");
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (RadioButton_Boot1.IsChecked == true)
                MessageBox.Show(RadioButton_Boot1.Content.ToString());
            else if (RadioButton_Boot1.IsChecked == true)
                MessageBox.Show(RadioButton_Boot2.Content.ToString());
            else if (RadioButton_Boot1.IsChecked == true)
                MessageBox.Show(RadioButton_Boot3.Content.ToString());
            RadioButton pressed = (RadioButton)sender;
            MessageBox.Show(pressed.Content.ToString());
        }
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            popup.IsOpen = true;
        }
    }
}

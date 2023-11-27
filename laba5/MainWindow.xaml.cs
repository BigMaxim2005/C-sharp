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

namespace laba5
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			throw new NotImplementedException();
		}
		private void RadioButton_Click(object sender, RoutedEventArgs e)
		{
			RadioButton selectedRadio = (RadioButton)e.Source;
			TextBlock1.Text = "U choose " + selectedRadio.Content.ToString();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("qq Button_Click");
		}

		private void Button1_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("qq Button1_Click");
		}
	}
}
}

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

namespace WpfApp7
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

		private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			if (Message != null)
				Message.FontSize = ((Slider)sender).Value;
		}

		private void ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			if (t2 != null && t1 != null)
				t2.FontSize = ((Slider)sender).Value;
			t1.FontSize = ((Slider)sender).Value;
		}
	}
}
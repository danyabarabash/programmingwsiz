using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Zadanie_1_2
{
	/// <summary>
	/// Interaction logic for AddGrade.xaml
	/// </summary>
	public partial class AddGrade : Window
	{
		public Student student;

		public AddGrade(Student student = null)
		{
			InitializeComponent();

			this.student = student;
		}

		public AddGrade()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (!Regex.IsMatch(tbPrzedmiot.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
			    !Regex.IsMatch(tbOcena.Text, @"^[0-9]*(?:\.[0-9]*)?$"))
			{
				MessageBox.Show("Podanoe bledne dane.");
				return;
			}

			student.Oceny.Add(new Grade(float.Parse(tbOcena.Text), tbPrzedmiot.Text));

			this.DialogResult = true;
		}
	}
}

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
using System.Windows.Shapes;

namespace Zadanie_1_2
{
	/// <summary>
	/// Interaction logic for ShowGrades.xaml
	/// </summary>
	public partial class ShowGrades : Window
	{
		public ShowGrades(Student student = null)
		{
			InitializeComponent();
			InitDataGrid(student);
		}

		private void InitDataGrid(Student student)
		{
			dgGrades.Columns.Add(new DataGridTextColumn() { Header = "Przedmiot", Binding = new Binding("Przedmiot") });
			dgGrades.Columns.Add(new DataGridTextColumn() { Header = "Ocena", Binding = new Binding("Ocena") });

			dgGrades.AutoGenerateColumns = false;
			dgGrades.ItemsSource = student.Oceny;
		}
	}
}

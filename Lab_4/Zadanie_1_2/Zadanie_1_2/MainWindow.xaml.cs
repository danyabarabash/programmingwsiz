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

namespace Zadanie_1_2
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public List<Student> ListaStudentow { get; set; }

		public MainWindow()
		{
			InitializeComponent();
			InitDataGrid();
		}

		private void InitDataGrid()
		{
			ListaStudentow = new List<Student>()
			{
				new Student("Jan", "Kowalski", "KIS", 2341),
				new Student("Anna", "Nowak", "KIS", 2523),
				new Student("Michal", "Jacek", "KIS", 4765)
			};

			dgStudent.Columns.Add(new DataGridTextColumn() {Header = "Imie", Binding = new Binding("Imie")});
			dgStudent.Columns.Add(new DataGridTextColumn() { Header = "Nazwisko", Binding = new Binding("Nazwisko") });
			dgStudent.Columns.Add(new DataGridTextColumn() { Header = "Wydzial", Binding = new Binding("Wydzial") });
			dgStudent.Columns.Add(new DataGridTextColumn() { Header = "Nr indeksu", Binding = new Binding("NrIndeksu") });

			dgStudent.AutoGenerateColumns = false;
			dgStudent.ItemsSource = ListaStudentow;
		}

		private void Button_Click_Remove_Student(object sender, RoutedEventArgs e)
		{
			if (dgStudent.SelectedItem == null)
			{
				MessageBox.Show("Wybierz studenta.");
				return;
			}

			if (dgStudent.SelectedItem is Student)
				ListaStudentow.Remove((Student)dgStudent.SelectedItem);
			dgStudent.Items.Refresh();
		}

		private void Button_Click_Add_Student(object sender, RoutedEventArgs e)
		{
			var dialog = new StudentWindow();
			if (dialog.ShowDialog() == true)
			{
				ListaStudentow.Add(dialog.student);
				dgStudent.Items.Refresh();
			}
		}

		private void Button_Click_Edit_Student(object sender, RoutedEventArgs e)
		{
			if (dgStudent.SelectedItem == null)
			{
				MessageBox.Show("Wybierz studenta.");
				return;
			}

			var dialog = new StudentWindow((Student)dgStudent.SelectedItem);
			if (dialog.ShowDialog() == true)
			{
				dgStudent.Items.Refresh();
			}
		}

		private void Button_Click_AddGrade(object sender, RoutedEventArgs e)
		{
			if (dgStudent.SelectedItem == null)
			{
				MessageBox.Show("Wybierz studenta.");
				return;
			}

			var dialog = new AddGrade((Student)dgStudent.SelectedItem);
			if (dialog.ShowDialog() == true)
			{
				dgStudent.Items.Refresh();
			}
		}

		private void Button_Click_ShowGrade(object sender, RoutedEventArgs e)
		{
			if (dgStudent.SelectedItem == null)
			{
				MessageBox.Show("Wybierz studenta.");
				return;
			}
			var dialog = new ShowGrades((Student)dgStudent.SelectedItem);
			dialog.ShowDialog();
		}
	}
}

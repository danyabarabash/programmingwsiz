using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using System.Xml.Serialization;
using Microsoft.Win32;

namespace WszystkieZadania
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

			dgStudent.Columns.Add(new DataGridTextColumn() { Header = "Imie", Binding = new Binding("Imie") });
			dgStudent.Columns.Add(new DataGridTextColumn() { Header = "Nazwisko", Binding = new Binding("Nazwisko") });
			dgStudent.Columns.Add(new DataGridTextColumn() { Header = "Wydzial", Binding = new Binding("Wydzial") });
			dgStudent.Columns.Add(new DataGridTextColumn() { Header = "Nr indeksu", Binding = new Binding("NrIndeksu") });

			dgStudent.AutoGenerateColumns = false;
			dgStudent.ItemsSource = ListaStudentow;
		}

		private void btnAddStudent_Click(object sender, RoutedEventArgs e)
		{
			var dialog = new StudentWindow();
			if (dialog.ShowDialog() == true)
			{
				ListaStudentow.Add(dialog.student);
				dgStudent.Items.Refresh();
			}
		}

		private void btnRemoveStudent_Click(object sender, RoutedEventArgs e)
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

		private void btnSaveToFile_Click(object sender, RoutedEventArgs e)
		{
			ReflectionWrite();
		}

		private void btnLoadFromFile_Click(object sender, RoutedEventArgs e)
		{
			var list = ReflectionRead<Student>();
			ListaStudentow.AddRange(list);
			dgStudent.Items.Refresh();
		}

		private void ReflectionWrite()
		{
			var fs = new FileStream("data.txt", FileMode.Create);
			var sw = new StreamWriter(fs);

			foreach (Object obj in ListaStudentow)
			{
				var type = obj.GetType();
				sw.WriteLine($"[[{type.FullName}]]");
				foreach (var p in type.GetProperties())
				{
					sw.WriteLine($"[{p.Name}]");
					sw.WriteLine(p.GetValue(obj));
				}

				sw.WriteLine($"[[]]");
			}

			sw.Close();
			fs.Close();
		}

		private List<T> ReflectionRead<T>()
		{
			var fs = new FileStream("data.txt", FileMode.Open);
			var sr = new StreamReader(fs);

			var list = new List<T>();
			T obj = default(T);
			Type type = null;
			PropertyInfo property = null;

			while (!sr.EndOfStream)
			{
				var ln = sr.ReadLine();
				if (ln == "[[]]")
				{
					list.Add(obj);
					obj = default(T);
					type = null;
					property = null;
				}
				else if (ln.StartsWith("[["))
				{
					type = Type.GetType(ln.Trim('[', ']'));
					if (typeof(T).IsAssignableFrom(type))
						obj = (T) Activator.CreateInstance(type);
				}
				else if (ln.StartsWith("[") && obj != null)
					property = type.GetProperty(ln.Trim('[', ']'));
				else if (obj != null && property != null)
					property.SetValue(obj, Convert.ChangeType(ln, property.PropertyType));
			}

			sr.Close();
			fs.Close();

			return list;
		}

		private void StandartWrite()
		{
			var fs = new FileStream("data.txt", FileMode.Create);
			var sw = new StreamWriter(fs);

			foreach (var student in ListaStudentow)
			{
				sw.WriteLine("[[Student]]");
				sw.WriteLine("[FirstName]");
				sw.WriteLine(student.Imie);
				sw.WriteLine("[SurName]");
				sw.WriteLine(student.Nazwisko);
				sw.WriteLine("[StudentNo]");
				sw.WriteLine(student.NrIndeksu);
				sw.WriteLine("[Faculty]");
				sw.WriteLine(student.Wydzial);
				sw.WriteLine("[[]]");
			}
			sw.WriteLine("[End]");

			sw.Close();
			fs.Close();
		}

		private void StandartRead()
		{
			var fs = new FileStream("data.txt", FileMode.Open);
			var sr = new StreamReader(fs);

			string prevLine = null;
			Student student = null;

			while (!sr.EndOfStream)
			{
				if (prevLine != null)
				{
					switch (prevLine)
					{
						case "[[Student]]":
							student = new Student();
							break;
						case "[[]]":
							ListaStudentow.Add(student);
							break;
						case "[FirstName]":
							student.Imie = sr.ReadLine();
							break;
						case "[SurName]":
							student.Nazwisko = sr.ReadLine();
							break;
						case "[StudentNo]":
							student.NrIndeksu = int.Parse(sr.ReadLine());
							break;
						case "[Faculty]":
							student.Wydzial = sr.ReadLine();
							break;
					}
				}

				prevLine = sr.ReadLine();
			}
			dgStudent.Items.Refresh();

			sr.Close();
			fs.Close();
		}

		private void btnSaveToXml_Click(object sender, RoutedEventArgs e)
		{
			Stream s;
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.DefaultExt = ".txt";
			if (saveFileDialog.ShowDialog() == true)
			{
				if ((s = saveFileDialog.OpenFile()) != null)
				{
					var xml = new XmlSerializer(ListaStudentow.GetType());
					xml.Serialize(s, ListaStudentow);
					s.Close();
					MessageBox.Show("Success!!!");
				}
			}
		}

		private void btnLoadFromXML_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = "c:\\";
			openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
			if (openFileDialog.ShowDialog() == true)
			{
				var fileStream = openFileDialog.OpenFile();

				var s = new XmlSerializer(ListaStudentow.GetType());

				try
				{
					ListaStudentow.AddRange((List<Student>) s.Deserialize(fileStream));
					MessageBox.Show("Success!!!");
				}
				catch (Exception)
				{
					MessageBox.Show("Ooops, smth wrong with file...");
				}

				fileStream.Close();
				dgStudent.Items.Refresh();
			}
		}

		private void btnReadSomeValue_Click(object sender, RoutedEventArgs e)
		{
			var fs = new FileStream("data.txt", FileMode.Open);
			var sr = new StreamReader(fs);

			var sn = new StreamEnumerable<Student>(sr);

			sn.MoveNext();
			sn.MoveNext();
			sn.MoveNext();
			sn.MoveNext();

			fs.Close();
		}
	}
}

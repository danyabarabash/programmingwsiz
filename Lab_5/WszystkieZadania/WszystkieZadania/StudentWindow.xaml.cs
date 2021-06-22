﻿using System;
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

namespace WszystkieZadania
{
	/// <summary>
	/// Interaction logic for StudentWindow.xaml
	/// </summary>
	public partial class StudentWindow : Window
	{
		public Student student;

		public StudentWindow(Student student = null)
		{
			InitializeComponent();
			if (student != null)
			{
				tbImie.Text = student.Imie;
				tbNazwisko.Text = student.Nazwisko;
				tbNrAlbumu.Text = student.NrIndeksu.ToString();
				tbWydzial.Text = student.Wydzial;
			}

			this.student = student ?? new Student();
		}

		private void btnOk_Click(object sender, RoutedEventArgs e)
		{
			student.Imie = tbImie.Text;
			student.Nazwisko = tbNazwisko.Text;
			student.Wydzial = tbWydzial.Text;
			student.NrIndeksu = int.Parse(tbNrAlbumu.Text);

			this.DialogResult = true;
		}
	}
}

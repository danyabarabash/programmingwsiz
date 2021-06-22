using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_1_2
{
	public class Student
	{
		public string Imie { get; set; }
		public string Nazwisko { get; set; }
		public string Wydzial { get; set; }
		public int NrIndeksu { get; set; }
		public List<Grade> Oceny { get; set; }

		public Student(string imie, string nazwisko, string wydzial, int nrIndeksu)
		{
			Oceny = new List<Grade>();
			Imie = imie;
			Nazwisko = nazwisko;
			Wydzial = wydzial;
			NrIndeksu = nrIndeksu;
		}

		public Student() : this("", "", "", 0) { }
	}
}

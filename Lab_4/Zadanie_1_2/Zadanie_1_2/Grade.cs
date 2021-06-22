using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_1_2
{
	public class Grade
	{
		public string Przedmiot { get; set; }
		public float Ocena { get; set; }

		public Grade(float ocena, string przedmiot)
		{
			Przedmiot = przedmiot;
			Ocena = ocena;
		}
	}
}

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

namespace Lab_3_Zadanie_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double a;
            double b;
            double wynik;

            double.TryParse(tBox1.Text, out a);
            double.TryParse(tBox2.Text, out b);

            wynik = a + b;
            tbWynik.Text = "Suma = " + a + "+" + b + "=" + wynik;


        }

        private void Roznica_Click(object sender, RoutedEventArgs e)
        {
            double a;
            double b;
            double wynik;

            double.TryParse(tBox1.Text, out a);
            double.TryParse(tBox2.Text, out b);

            wynik = a - b;
            tbWynik.Text = "Różnica = " + a + "-" + b + "=" + wynik;
        }

        private void Iloczyn_Click(object sender, RoutedEventArgs e)
        {
            double a;
            double b;
            double wynik;

            double.TryParse(tBox1.Text, out a);
            double.TryParse(tBox2.Text, out b);

            wynik = a * b;
            tbWynik.Text = "Iloczyn = " + a + "*" + b + "=" + wynik;
        }

        private void Iloraz_Click(object sender, RoutedEventArgs e)
        {
            double a;
            double b;
            double wynik;

            double.TryParse(tBox1.Text, out a);
            double.TryParse(tBox2.Text, out b);

            if (b==0)
            {
                MessageBox.Show("Nie można dzielić przez 0", "Uwaga!");
            }
            else
            {
                wynik = a / b;
                tbWynik.Text = "Iloraz = " + a + "/" + b + "=" + wynik;
            }
            
        }
    }
}

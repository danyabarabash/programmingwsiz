using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_3_Zadanie_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
                if (checkBox1.Checked == true)
                {
                    double euro = 4.48;
                    double zloty = double.Parse(textBox1.Text);
                    textBox2.Text = (euro * zloty).ToString("0.00");
                }

                if (checkBox2.Checked == true)
                {
                    double dolar = 3.7;
                    double zloty = double.Parse(textBox1.Text);
                    textBox3.Text = (dolar * zloty).ToString("0.00");
                }

                if (checkBox3.Checked == true)
                {
                    double funt = 5.21;
                    double zloty = double.Parse(textBox1.Text);
                    textBox4.Text = (funt * zloty).ToString("0.00");
                }

                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false)
                {
                MessageBox.Show("Należy wybrać min 1 walutę!", "Uwaga!");
                }
                
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_2_Zadanie_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonOblicz_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (!string.IsNullOrWhiteSpace(this.textBox1.Text))
                {
                    if (this.radioButton1.Checked == false && this.radioButton2.Checked == false)
                    {
                        throw new Exception("Nie wybrałeś płeć!");
                    }

                    if (this.checkBox1.Checked == false && this.checkBox2.Checked == false)
                    {
                        throw new Exception("Nie wybrałeś żadnej wagi!");
                    }

                    if (this.checkBox1.Checked == true && this.checkBox2.Checked == true)
                    {
                        int standardowa = int.Parse(this.textBox1.Text) - 100;
                        this.textBox2.Text = "Standartowa: " + (int.Parse(this.textBox1.Text) - 100).ToString() + " kg";
                        if (this.radioButton1.Checked)
                        {
                            this.textBox3.Text = "Idealna: " + (Convert.ToDouble(standardowa) * 0.85).ToString("0.0") + " kg";
                        }
                        else if (this.radioButton2.Checked)
                        {
                            this.textBox3.Text = "Idealna: " + (Convert.ToDouble(standardowa) * 0.9).ToString("0.0") + " kg";
                        }
                        else
                        {
                            throw new Exception("Dla idealnej wagi należy wybrać płeć!");
                        }
                    }
                        
                    if (this.checkBox1.Checked == true)
                    {
                        this.textBox2.Text = "Standartowa: " + (int.Parse(this.textBox1.Text) - 100).ToString() + " kg"; 
                    }

                    if (this.checkBox2.Checked == true)
                    {
                        int standardowa = int.Parse(this.textBox1.Text) - 100;
                        
                        if (this.radioButton1.Checked)
                        {
                            this.textBox3.Text = "Idealna: " + (Convert.ToDouble(standardowa) * 0.85).ToString("0.0") + " kg";
                        }
                        else if (this.radioButton2.Checked)
                        {
                            this.textBox3.Text = "Idealna: " + (Convert.ToDouble(standardowa) * 0.9).ToString("0.0") + " kg";
                        }
                        else
                        {
                            throw new Exception("Dla idealnej wagi należy wybrać płeć!");
                        }
                    }
                }
                else
                {
                    throw new Exception("Należy podać wagę!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Uwaga!", MessageBoxButtons.OK);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}

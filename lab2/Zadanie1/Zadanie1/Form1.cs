using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonDzielenie_Click(object sender, EventArgs e)
        {
            try
            {
                double dzielna = double.Parse(textBoxDzielna.Text);
                double dzielnik = double.Parse(textBoxDzielnik.Text);

                if (dzielnik == 0)
                {
                    throw new DivideByZeroException("Nie można dzielić przez zero.");
                }

                double wynik = dzielna / dzielnik;
                textBoxWynik.Text = wynik.ToString();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Błędny format liczby. Proszę wprowadzić prawidłowe liczby.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EventLog.WriteEntry("Application", $"Błędny format liczby: {ex.Message}", EventLogEntryType.Error);
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show("Nie można dzielić przez zero.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EventLog.WriteEntry("Application", $"Próba dzielenia przez zero: {ex.Message}", EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EventLog.WriteEntry("Application", $"Nieoczekiwany błąd: {ex.Message}", EventLogEntryType.Error);
            }
        }
    }
}
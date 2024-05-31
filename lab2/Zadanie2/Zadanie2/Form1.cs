using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie2
{
    public partial class Form1 : Form
    {
        private string wejscie = string.Empty;
        private string liczba1 = string.Empty;
        private string liczba2 = string.Empty;
        private char operacja;
        private double wynik = 0.0;
        private Stopwatch stoper;

        private const string nazwaZrodla = "Aplikacja";
        private const string nazwaDziennika = "Application";
        public Form1()
        {
            stoper = Stopwatch.StartNew();
            InitializeComponent();
            InicjalizujDziennikZdarzen();
            stoper.Stop();
            LogujCzasInicjalizacji(stoper.ElapsedMilliseconds);
        }

        private void InicjalizujDziennikZdarzen()
        {
            if (!EventLog.SourceExists(nazwaZrodla)) // program uruchamia sie, dopiero gdy visual studio jest uruchomiony jaki administrator, w przeciwnym razie nie ma dostepu do dziennika zdarzen
            {
                EventLog.CreateEventSource(nazwaZrodla, nazwaDziennika);
            }
        }
        private void LogujCzasInicjalizacji(long czasWMilisekundach)
        {
            const long prog = 2000; // 2 sekundy
            if (czasWMilisekundach > prog)
            {
                EventLog.WriteEntry(nazwaZrodla, $"Inicjalizacja trwała zbyt długo: {czasWMilisekundach} ms", EventLogEntryType.Warning);
            }
        }
        private void przycisk_Click(object sender, EventArgs e)
        {
            Button przycisk = (Button)sender;
            textBoxWynik.Text = textBoxWynik.Text + przycisk.Text;
        }
        private void operator_Click(object sender, EventArgs e)
        {
            Button przycisk = (Button)sender;
            liczba1 = textBoxWynik.Text;
            operacja = przycisk.Text[0];
            textBoxWynik.Text = string.Empty;
        }
        private void przyciskRownaSie_Click(object sender, EventArgs e)
        {
            liczba2 = textBoxWynik.Text;

            try
            {
                double num1, num2;
                double.TryParse(liczba1, out num1);
                double.TryParse(liczba2, out num2);

                switch (operacja)
                {
                    case '+':
                        wynik = num1 + num2;
                        break;
                    case '-':
                        wynik = num1 - num2;
                        break;
                    case '*':
                        wynik = num1 * num2;
                        break;
                    case '/':
                        if (num2 == 0)
                        {
                            throw new DivideByZeroException("Nie można dzielić przez zero.");
                        }
                        wynik = num1 / num2;
                        break;
                }
                textBoxWynik.Text = wynik.ToString();
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(nazwaZrodla, $"Błąd: {ex.Message}", EventLogEntryType.Error);
                MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void przyciskC_Click(object sender, EventArgs e)
        {
            textBoxWynik.Text = string.Empty;
            liczba1 = string.Empty;
            liczba2 = string.Empty;
            operacja = '\0';
            wynik = 0.0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button7_Click(object sender, EventArgs e)
        {
            przycisk_Click(sender, e);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            przycisk_Click(sender, e);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            przycisk_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            przycisk_Click(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            przycisk_Click(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            przycisk_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            przycisk_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            przycisk_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            przycisk_Click(sender, e);
        }

        private void button0_Click(object sender, EventArgs e)
        {
            przycisk_Click(sender, e);
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            operator_Click(sender, e);
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            operator_Click(sender, e);
        }

        private void buttonMnozenie_Click(object sender, EventArgs e)
        {
            operator_Click(sender, e);
        }

        private void buttonDzielenie_Click(object sender, EventArgs e)
        {
            operator_Click(sender, e);
        }

        private void buttonRownaSie_Click(object sender, EventArgs e)
        {
            przyciskRownaSie_Click(sender, e);
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            przyciskC_Click(sender, e);
        }
    }
}

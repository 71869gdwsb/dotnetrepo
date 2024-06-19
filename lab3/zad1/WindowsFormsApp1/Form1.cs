using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private SymmetricAlgorithm algorytm;
        private Stopwatch stoper;
        public Form1()
        {
            InitializeComponent();
            stoper = new Stopwatch();
            comboBoxAlgorytm.Items.AddRange(new string[] { "AES", "DES", "RC2", "TripleDES" });
            comboBoxAlgorytm.SelectedIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonGenerujKlucze_Click(object sender, EventArgs e)
        {
            switch (comboBoxAlgorytm.SelectedItem.ToString())
            {
                case "AES":
                    algorytm = new AesCryptoServiceProvider();
                    break;
                case "DES":
                    algorytm = new DESCryptoServiceProvider();
                    break;
                case "RC2":
                    algorytm = new RC2CryptoServiceProvider();
                    break;
                case "TripleDES":
                    algorytm = new TripleDESCryptoServiceProvider();
                    break;
            }

            algorytm.GenerateKey();
            algorytm.GenerateIV();

            textBoxKey.Text = BitConverter.ToString(algorytm.Key).Replace("-", "");
            textBoxIV.Text = BitConverter.ToString(algorytm.IV).Replace("-", "");
        }

        private void buttonSzyfruj_Click(object sender, EventArgs e)
        {
            try
            {
                stoper.Restart();
                byte[] zaszyfrowane = Szyfruj(textBoxText.Text, algorytm.Key, algorytm.IV);
                stoper.Stop();

                textBoxCipherTextASCII.Text = Encoding.ASCII.GetString(zaszyfrowane);
                textBoxCipherTextHEX.Text = BitConverter.ToString(zaszyfrowane).Replace("-", "");

                MessageBox.Show($"Czas szyfrowania: {stoper.ElapsedMilliseconds} ms");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd szyfrowania: {ex.Message}");
            }
        }

        private void buttonDeszyfruj_Click(object sender, EventArgs e)
        {
            try
            {
                stoper.Restart();
                byte[] odszyfrowane = Deszyfruj(ConvertHexStringToByteArray(textBoxCipherTextHEX.Text), algorytm.Key, algorytm.IV);
                stoper.Stop();

                textBoxText.Text = Encoding.ASCII.GetString(odszyfrowane);

                MessageBox.Show($"Czas deszyfrowania: {stoper.ElapsedMilliseconds} ms");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd deszyfrowania: {ex.Message}");
            }
        }
        private byte[] Szyfruj(string plainText, byte[] key, byte[] iv)
        {
            ICryptoTransform encryptor = algorytm.CreateEncryptor(key, iv);
            byte[] inputBuffer = Encoding.ASCII.GetBytes(plainText);
            return encryptor.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
        }

        private byte[] Deszyfruj(byte[] cipherText, byte[] key, byte[] iv)
        {
            ICryptoTransform decryptor = algorytm.CreateDecryptor(key, iv);
            return decryptor.TransformFinalBlock(cipherText, 0, cipherText.Length);
        }

        private byte[] ConvertHexStringToByteArray(string hexString)
        {
            int length = hexString.Length;
            byte[] bytes = new byte[length / 2];
            for (int i = 0; i < length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
            }
            return bytes;
        }
    }
}

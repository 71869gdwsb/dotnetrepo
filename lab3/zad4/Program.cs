using System;
using System.IO;
using System.Security.Cryptography;

namespace SzyfrowanieRSA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program szyfrujący i deszyfrujący pliki RSA");
            Console.WriteLine("Upewnij się, że plik do szyfrowania, plik klucza publicznego i prywatnego znajdują się w tym samym folderze co plik wykonywalny.");

            string plikWejsciowy = "plik.txt"; // przykładowy plik do szyfrowania
            string plikZaszyfrowany = "zaszyfrowany.dat"; // plik, do którego zapisany zostanie zaszyfrowany tekst
            string plikOdszyfrowany = "odszyfrowany.txt"; // plik, do którego zapisany zostanie odszyfrowany tekst

            string sciezkaKluczPubliczny = "klucz_publiczny.xml"; // plik klucza publicznego
            string sciezkaKluczPrywatny = "klucz_prywatny.xml"; // plik klucza prywatnego

            // wygenerowanie kluczy
            if (!File.Exists(sciezkaKluczPubliczny) || !File.Exists(sciezkaKluczPrywatny))
            {
                WygenerujKlucze(sciezkaKluczPubliczny, sciezkaKluczPrywatny);
            }

            // menu
            Console.WriteLine();
            Console.WriteLine("Wybierz opcję:");
            Console.WriteLine("1. Szyfruj plik");
            Console.WriteLine("2. Odszyfruj plik");
            Console.WriteLine("3. Wyjście");

            // wybor
            string wybor = Console.ReadLine();
            switch (wybor)
            {
                case "1":
                    SzyfrujPlik(plikWejsciowy, plikZaszyfrowany, sciezkaKluczPubliczny);
                    Console.WriteLine("Zaszyfrowano plik.");
                    break;
                case "2":
                    OdszyfrujPlik(plikZaszyfrowany, plikOdszyfrowany, sciezkaKluczPrywatny);
                    Console.WriteLine("Odszyfrowano plik.");
                    break;
                case "3":
                    Console.WriteLine("Wyjście z programu.");
                    break;
                default:
                    Console.WriteLine("Nieprawidłowy wybór.");
                    break;
            }

            Console.WriteLine("Naciśnij dowolny klawisz, aby zakończyć...");
            Console.ReadKey();
        }

        static void WygenerujKlucze(string sciezkaKluczPubliczny, string sciezkaKluczPrywatny)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                // zapis klucza publicznego
                string kluczPubliczny = rsa.ToXmlString(false);
                File.WriteAllText(sciezkaKluczPubliczny, kluczPubliczny);

                // zapis klucza prywatnego
                string kluczPrywatny = rsa.ToXmlString(true);
                File.WriteAllText(sciezkaKluczPrywatny, kluczPrywatny);
            }
        }

        static void SzyfrujPlik(string plikWejsciowy, string plikZaszyfrowany, string sciezkaKluczPubliczny)
        {
            try
            {
                string kluczPubliczny = File.ReadAllText(sciezkaKluczPubliczny);
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(kluczPubliczny);
                    byte[] daneDoZaszyfrowania = File.ReadAllBytes(plikWejsciowy);
                    byte[] zaszyfrowaneDane = rsa.Encrypt(daneDoZaszyfrowania, false);
                    File.WriteAllBytes(plikZaszyfrowany, zaszyfrowaneDane);
                }
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine($"Zgłoszony wyjątek: {ex.GetType().FullName}");
                Console.WriteLine($"Wiadomość: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Zgłoszony wyjątek: {ex.GetType().FullName}");
                Console.WriteLine($"Wiadomość: {ex.Message}");
            }
        }

        static void OdszyfrujPlik(string plikZaszyfrowany, string plikOdszyfrowany, string sciezkaKluczPrywatny)
        {
            try
            {
                string kluczPrywatny = File.ReadAllText(sciezkaKluczPrywatny);
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(kluczPrywatny);
                    byte[] zaszyfrowaneDane = File.ReadAllBytes(plikZaszyfrowany);
                    byte[] odszyfrowaneDane = rsa.Decrypt(zaszyfrowaneDane, false);
                    File.WriteAllBytes(plikOdszyfrowany, odszyfrowaneDane);
                }
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine($"Zgłoszony wyjątek: {ex.GetType().FullName}");
                Console.WriteLine($"Wiadomość: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Zgłoszony wyjątek: {ex.GetType().FullName}");
                Console.WriteLine($"Wiadomość: {ex.Message}");
            }
        }
    }
}

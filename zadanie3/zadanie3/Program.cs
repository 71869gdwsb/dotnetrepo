using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // sciezka do txt
        string sciezkaDoPliku = "test.txt";

        try
        {
            // otwarcie przez fstream
            using (FileStream fs = new FileStream(sciezkaDoPliku, FileMode.Open, FileAccess.Read))
            {
                // odczyt strreader
                using (StreamReader sr = new StreamReader(fs))
                {
                    // wyswietlenie
                    Console.WriteLine("Zawartość pliku:");
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Plik nie istnieje.");
        }
        catch (IOException ex)
        {
            Console.WriteLine("Wystąpił błąd podczas odczytu pliku: " + ex.Message);
        }

        Console.ReadKey();
    }
}

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Ścieżka do pliku tekstowego
        string sciezkaDoPliku = "test.txt";

        try
        {
            // Otwarcie istniejącego pliku tekstowego za pomocą StreamReader
            using (StreamReader sr = new StreamReader(sciezkaDoPliku))
            {
                string linia;
                // Odczytanie i wyświetlenie kolejnych linii z pliku
                while ((linia = sr.ReadLine()) != null)
                {
                    // Odwrócenie kolejności znaków w linii i wyświetlenie na konsoli
                    char[] odwroconaLinia = linia.ToCharArray();
                    Array.Reverse(odwroconaLinia);
                    Console.WriteLine(odwroconaLinia);
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

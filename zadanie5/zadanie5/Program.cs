using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Wybierz opcję:");
        Console.WriteLine("1. Zapisz dane do pliku");
        Console.WriteLine("2. Odczytaj dane z pliku");

        // Pobranie wyboru użytkownika
        int wybor;
        while (!int.TryParse(Console.ReadLine(), out wybor) || (wybor != 1 && wybor != 2))
        {
            Console.WriteLine("Niepoprawna opcja. Wybierz 1 lub 2.");
        }

        switch (wybor)
        {
            case 1:
                ZapiszDaneDoPliku();
                break;
            case 2:
                OdczytajDaneZPliku();
                break;
        }
    }

    static void ZapiszDaneDoPliku()
    {
        try
        {
            Console.WriteLine("Podaj imię:");
            string imie = Console.ReadLine();

            Console.WriteLine("Podaj wiek:");
            int wiek;
            while (!int.TryParse(Console.ReadLine(), out wiek))
            {
                Console.WriteLine("Niepoprawny wiek. Podaj liczbę całkowitą.");
            }

            Console.WriteLine("Podaj adres:");
            string adres = Console.ReadLine();

            using (FileStream fs = new FileStream("dane.bin", FileMode.Create))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                writer.Write(imie);
                writer.Write(wiek);
                writer.Write(adres);
            }

            Console.WriteLine("Dane zapisane do pliku.");
        }
        catch (IOException ex)
        {
            Console.WriteLine("Wystąpił błąd podczas zapisu danych: " + ex.Message);
        }
    }

    static void OdczytajDaneZPliku()
    {
        try
        {
            using (FileStream fs = new FileStream("dane.bin", FileMode.Open))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                string imie = reader.ReadString();
                int wiek = reader.ReadInt32();
                string adres = reader.ReadString();

                Console.WriteLine("Imię: " + imie);
                Console.WriteLine("Wiek: " + wiek);
                Console.WriteLine("Adres: " + adres);
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Plik nie istnieje.");
        }
        catch (IOException ex)
        {
            Console.WriteLine("Wystąpił błąd podczas odczytu danych: " + ex.Message);
        }
    }
}

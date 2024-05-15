using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        
        string plikin = "in.txt";
        
        string plikout = "out.txt";

        try
        {
            // otwarcie in
            using (FileStream fsWejsciowy = new FileStream(plikin, FileMode.Open, FileAccess.Read))
            {
                // otwarcie nowego out
                using (FileStream fsWyjsciowy = new FileStream(plikout, FileMode.Create, FileAccess.Write))
                {
                    // kopiowanie
                    byte[] buffer = new byte[1024];
                    int iloscOdczytanychBajtow;
                    while ((iloscOdczytanychBajtow = fsWejsciowy.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fsWyjsciowy.Write(buffer, 0, iloscOdczytanychBajtow);
                    }
                }
            }

            Console.WriteLine("Plik został skopiowany pomyślnie.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Plik wejściowy nie istnieje.");
        }
        catch (IOException ex)
        {
            Console.WriteLine("Wystąpił błąd podczas kopiowania pliku: " + ex.Message);
        }

        Console.ReadKey();
    }
}

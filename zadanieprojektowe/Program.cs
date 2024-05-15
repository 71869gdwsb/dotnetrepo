using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class Zadanie
{
    public int Id { get; set; }
    public string Nazwa { get; set; }
    public string Opis { get; set; }
    public DateTime DataZakonczenia { get; set; }
    public bool CzyWykonane { get; set; }

    public Zadanie() { }

    public Zadanie(int id, string nazwa, string opis, DateTime dataZakonczenia)
    {
        Id = id;
        Nazwa = nazwa;
        Opis = opis;
        DataZakonczenia = dataZakonczenia;
        CzyWykonane = false;
    }
}

public class ManagerZadan
{
    private List<Zadanie> listaZadan;

    public ManagerZadan()
    {
        listaZadan = new List<Zadanie>();
    }

    public void DodajZadanie(Zadanie zadanie)
    {
        listaZadan.Add(zadanie);
    }

    public void UsunZadanie(int id)
    {
        Zadanie zadanie = listaZadan.Find(z => z.Id == id);
        if (zadanie != null)
        {
            listaZadan.Remove(zadanie);
        }
    }

    public void WyswietlZadania()
    {
        foreach (var zadanie in listaZadan)
        {
            Console.WriteLine($"Id: {zadanie.Id}, Nazwa: {zadanie.Nazwa}, Opis: {zadanie.Opis}, Data zakończenia: {zadanie.DataZakonczenia}, Wykonane: {zadanie.CzyWykonane}");
        }
    }

    public void ZapiszDoPliku(string sciezka = null)
    {
        if (string.IsNullOrEmpty(sciezka))
        {
            sciezka = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "lista_zadan.xml");
            Console.WriteLine($"Lista zadań zostanie zapisana w folderze Moje Dokumenty.");
        }

        XmlSerializer serializer = new XmlSerializer(typeof(List<Zadanie>));
        using (TextWriter writer = new StreamWriter(sciezka))
        {
            serializer.Serialize(writer, listaZadan);
        }
    }

    public void WczytajZPliku(string sciezka)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Zadanie>));
        using (TextReader reader = new StreamReader(sciezka))
        {
            listaZadan = (List<Zadanie>)serializer.Deserialize(reader);
        }
    }

    public List<Zadanie> PobierzListeZadan()
    {
        return listaZadan;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ManagerZadan manager = new ManagerZadan();

        while (true)
        {
            Console.WriteLine("1. Dodaj zadanie");
            Console.WriteLine("2. Usuń zadanie");
            Console.WriteLine("3. Wyświetl zadania");
            Console.WriteLine("4. Zapisz listę zadań do pliku XML");
            Console.WriteLine("5. Wczytaj listę zadań z pliku XML");
            Console.WriteLine("6. Wyjdź z programu");

            Console.WriteLine("Wybierz opcję:");
            string opcja = Console.ReadLine();

            switch (opcja)
            {
                case "1":
                    DodajZadanie(manager);
                    break;
                case "2":
                    UsunZadanie(manager);
                    break;
                case "3":
                    manager.WyswietlZadania();
                    break;
                case "4":
                    manager.ZapiszDoPliku();
                    break;
                case "5":
                    Console.WriteLine("Podaj ścieżkę do pliku XML (domyślnie C:\\Users\\nazwauzytkownika\\Documents\\lista_zadan.xml):");
                    string sciezkaWczytania = Console.ReadLine();
                    manager.WczytajZPliku(sciezkaWczytania);
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie.");
                    break;
            }
        }
    }

    public static void DodajZadanie(ManagerZadan manager)
    {
        Console.WriteLine("Podaj nazwę zadania:");
        string nazwa = Console.ReadLine();
        Console.WriteLine("Podaj opis zadania:");
        string opis = Console.ReadLine();
        Console.WriteLine("Podaj datę zakończenia zadania (w formacie RRRR-MM-DD):");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataZakonczenia))
        {
            Console.WriteLine("Podano nieprawidłową datę.");
            return;
        }

        Zadanie noweZadanie = new Zadanie(manager.PobierzListeZadan().Count + 1, nazwa, opis, dataZakonczenia);
        manager.DodajZadanie(noweZadanie);
        Console.WriteLine("Zadanie zostało dodane.");
    }

    public static void UsunZadanie(ManagerZadan manager)
    {
        Console.WriteLine("Podaj Id zadania do usunięcia:");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Podano nieprawidłową wartość.");
            return;
        }

        manager.UsunZadanie(id);
        Console.WriteLine("Zadanie zostało usunięte.");
    }
}

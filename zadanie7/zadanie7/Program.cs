using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // path in
        string sciezkaPlikuZrodlowego = "in.bin";
        // path out
        string sciezkaPlikuDocelowego = "out.bin";

        // 300 MB
        UtworzPlik(sciezkaPlikuZrodlowego, 300 * 1024 * 1024);

        // sprawdz czy istnieje
        if (File.Exists(sciezkaPlikuDocelowego))
        {
            File.Delete(sciezkaPlikuDocelowego);
        }


        // Kopia FileStream
        TestujKopie(() =>
        {
            KopiujPlikFileStream(sciezkaPlikuZrodlowego, sciezkaPlikuDocelowego);
        }, "Kopiowanie przy użyciu FileStream");

        // Kopia File.Copy
        TestujKopie(() =>
        {
            KopiujPlikFileCopy(sciezkaPlikuZrodlowego, sciezkaPlikuDocelowego);
        }, "Kopiowanie przy użyciu File.Copy");

        // Kopia BinaryReader/BinaryWriter
        TestujKopie(() =>
        {
            KopiujPlikBinaryReaderWriter(sciezkaPlikuZrodlowego, sciezkaPlikuDocelowego);
        }, "Kopiowanie przy użyciu BinaryReader/BinaryWriter");
    }

    // utworz 300mb
    static void UtworzPlik(string sciezka, long wielkoscBajtow)
    {
        using (FileStream fs = new FileStream(sciezka, FileMode.Create))
        {
            fs.SetLength(wielkoscBajtow);
        }
    }

    // FileStream
    static void KopiujPlikFileStream(string zrodlo, string cel)
    {
        using (FileStream fsZrodlo = new FileStream(zrodlo, FileMode.Open, FileAccess.Read))
        using (FileStream fsCel = new FileStream(cel, FileMode.Create, FileAccess.Write))
        {
            byte[] buffer = new byte[4096];
            int odczytaneBajty;
            while ((odczytaneBajty = fsZrodlo.Read(buffer, 0, buffer.Length)) > 0)
            {
                fsCel.Write(buffer, 0, odczytaneBajty);
            }
        }
    }

    // File.Copy
    static void KopiujPlikFileCopy(string zrodlo, string cel)
    {
        File.Copy(zrodlo, cel, true);
    }

    // BinaryReader/BinaryWriter
    static void KopiujPlikBinaryReaderWriter(string zrodlo, string cel)
    {
        using (BinaryReader reader = new BinaryReader(File.Open(zrodlo, FileMode.Open)))
        using (BinaryWriter writer = new BinaryWriter(File.Open(cel, FileMode.Create)))
        {
            byte[] buffer = new byte[4096];
            int odczytaneBajty;
            while ((odczytaneBajty = reader.Read(buffer, 0, buffer.Length)) > 0)
            {
                writer.Write(buffer, 0, odczytaneBajty);
            }
        }
    }

    // testy
    static void TestujKopie(Action kopie, string opis)
    {
        Stopwatch stoper = new Stopwatch();
        stoper.Start();
        kopie();
        stoper.Stop();
        Console.WriteLine($"{opis}: {stoper.ElapsedMilliseconds} ms");
    }
}

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

class Serwer
{
    // lista do przechowywania polaczonych klientow
    private static List<TcpClient> klienci = new List<TcpClient>();
    // klucz i wektor inicjalizujacy do szyfrowania AES
    private static readonly byte[] klucz = Encoding.UTF8.GetBytes("sekretnyklucz123");
    private static readonly byte[] iv = Encoding.UTF8.GetBytes("sekretnywektor12");

    static void Main(string[] args)
    {
        // instancja tcplistener sluchajaca na porcie 8888
        TcpListener serwer = new TcpListener(IPAddress.Any, 8888);
        serwer.Start();
        Console.WriteLine("Serwer uruchomiony...");

        // petla nasluchujaca nowych polaczen
        while (true)
        {
            TcpClient klient = serwer.AcceptTcpClient();
            lock (klienci)
            {
                klienci.Add(klient);
            }
            Console.WriteLine("Klient połączony...");
            // tworzenie nowego watku dla kazdego polaczonego klienta
            Thread klientWatek = new Thread(ObslugaKlienta);
            klientWatek.Start(klient);
        }
    }

    // metoda obsługujaca komunikacje z klientem
    private static void ObslugaKlienta(object obj)
    {
        TcpClient klient = (TcpClient)obj;
        NetworkStream strumien = klient.GetStream();
        byte[] bufor = new byte[1024];
        int odczytaneBajty;

        // petla odbierajaca wiadomosci od klienta
        while ((odczytaneBajty = strumien.Read(bufor, 0, bufor.Length)) != 0)
        {
            string wiadomosc = OdszyfrujWiadomosc(bufor, odczytaneBajty);
            Console.WriteLine("Odebrano: " + wiadomosc);
            RozeslijWiadomosc(wiadomosc);
        }

        // usuniecie klienta po zakonczeniu polaczenia
        lock (klienci)
        {
            klienci.Remove(klient);
        }
        klient.Close();
    }

    // wysylanie do wszystkich podlaczonych klientow
    private static void RozeslijWiadomosc(string wiadomosc)
    {
        byte[] zaszyfrowanaWiadomosc = ZaszyfrujWiadomosc(wiadomosc);
        lock (klienci)
        {
            foreach (TcpClient klient in klienci)
            {
                NetworkStream strumien = klient.GetStream();
                strumien.Write(zaszyfrowanaWiadomosc, 0, zaszyfrowanaWiadomosc.Length);
            }
        }
    }

    // szyfrowanie aes
    private static byte[] ZaszyfrujWiadomosc(string wiadomosc)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = klucz;
            aes.IV = iv;
            ICryptoTransform szyfrator = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] wiadomoscBajty = Encoding.UTF8.GetBytes(wiadomosc);
            return szyfrator.TransformFinalBlock(wiadomoscBajty, 0, wiadomoscBajty.Length);
        }
    }

    // odszyfrowanie aes
    private static string OdszyfrujWiadomosc(byte[] bufor, int odczytaneBajty)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = klucz;
            aes.IV = iv;
            ICryptoTransform deszyfrator = aes.CreateDecryptor(aes.Key, aes.IV);
            byte[] odszyfrowaneBajty = deszyfrator.TransformFinalBlock(bufor, 0, odczytaneBajty);
            return Encoding.UTF8.GetString(odszyfrowaneBajty);
        }
    }
}

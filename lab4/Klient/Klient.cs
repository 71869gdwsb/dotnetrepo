using System;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

class Klient
{
    // klucz i wektor inicjalizujacy do aes
    private static readonly byte[] klucz = Encoding.UTF8.GetBytes("sekretnyklucz123");
    private static readonly byte[] iv = Encoding.UTF8.GetBytes("sekretnywektor12");

    static void Main(string[] args)
    {
        // polaczenie z serwerem, port 8888
        TcpClient klient = new TcpClient("127.0.0.1", 8888);
        NetworkStream strumien = klient.GetStream();

        // watek do odbierania wiadomosci
        Thread odbieranieWatek = new Thread(OdbierajWiadomosci);
        odbieranieWatek.Start(strumien);

        Console.WriteLine("Połączono z serwerem. Wpisz wiadomości do wysłania:");

        // petla do wysylania wiadomosci do serwera
        while (true)
        {
            string wiadomosc = Console.ReadLine();
            byte[] zaszyfrowanaWiadomosc = ZaszyfrujWiadomosc(wiadomosc);
            strumien.Write(zaszyfrowanaWiadomosc, 0, zaszyfrowanaWiadomosc.Length);
        }
    }

    // odbieranie wiadomosci
    private static void OdbierajWiadomosci(object obj)
    {
        NetworkStream strumien = (NetworkStream)obj;
        byte[] bufor = new byte[1024];
        int odczytaneBajty;

        // petla do odbierania i odszyfrowywania wiadomości
        while ((odczytaneBajty = strumien.Read(bufor, 0, bufor.Length)) != 0)
        {
            string wiadomosc = OdszyfrujWiadomosc(bufor, odczytaneBajty);
            Console.WriteLine("Odebrano: " + wiadomosc);
        }
    }

    // szyfrowanie AES
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

    // odszyfrowanie AES
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

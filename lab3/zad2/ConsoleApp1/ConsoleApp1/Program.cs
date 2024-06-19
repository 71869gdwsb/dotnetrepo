using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string[] algorithms = {
            "AES (CSP) 128 bit",
            "AES (CSP) 256 bit",
            "AES Managed 128 bit",
            "AES Managed 256 bit",
            "Rijndael Managed 128 bit",
            "Rijndael Managed 256 bit",
            "DES 56 bit",
            "3DES 168 bit"
        };

        // dane testowe (1MB)
        string plainText = new string('A', 1024 * 1024);
        byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

        Console.WriteLine("Algorytm\t\t\tSekund/Blok\t\tBajtów/sekundę (RAM)\t\tBajtów/sekundę (HDD)");
        foreach (var algorithm in algorithms)
        {
            (double encryptionTime, double decryptionTime, double ramThroughput, double hddThroughput) = MeasureAlgorithmPerformance(algorithm, plainBytes);
            Console.WriteLine($"{algorithm}\t{encryptionTime:F6}\t\t{ramThroughput:F2}\t\t{hddThroughput:F2}");
        }
    }

    private static (double encryptionTime, double decryptionTime, double ramThroughput, double hddThroughput) MeasureAlgorithmPerformance(string algorithmName, byte[] plainBytes)
    {
        SymmetricAlgorithm algorithm = GetAlgorithm(algorithmName);

        algorithm.GenerateKey();
        algorithm.GenerateIV();
        byte[] encryptedBytes;
        byte[] decryptedBytes;

        // pomiar szyfrowania (RAM)
        Stopwatch stopwatch = Stopwatch.StartNew();
        using (var encryptor = algorithm.CreateEncryptor())
        {
            encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
        }
        stopwatch.Stop();
        double encryptionTimeRam = stopwatch.Elapsed.TotalSeconds;

        // pomiar deszyfrowania (RAM)
        stopwatch.Restart();
        using (var decryptor = algorithm.CreateDecryptor())
        {
            decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
        }
        stopwatch.Stop();
        double decryptionTimeRam = stopwatch.Elapsed.TotalSeconds;

        // kalkulacja (RAM)
        double ramThroughput = plainBytes.Length / encryptionTimeRam;

        // pomiar szyfrowania (HDD)
        string tempFile = Path.GetTempFileName();
        stopwatch.Restart();
        using (FileStream fs = new FileStream(tempFile, FileMode.Create, FileAccess.Write))
        {
            using (var encryptor = algorithm.CreateEncryptor())
            {
                byte[] buffer = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
                fs.Write(buffer, 0, buffer.Length);
            }
        }
        stopwatch.Stop();
        double encryptionTimeHdd = stopwatch.Elapsed.TotalSeconds;

    
        stopwatch.Restart();
        using (FileStream fs = new FileStream(tempFile, FileMode.Open, FileAccess.Read))
        {
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, buffer.Length);
            using (var decryptor = algorithm.CreateDecryptor())
            {
                decryptedBytes = decryptor.TransformFinalBlock(buffer, 0, buffer.Length);
            }
        }
        stopwatch.Stop();
        double decryptionTimeHdd = stopwatch.Elapsed.TotalSeconds;

        // kalkulacja (HDD)
        double hddThroughput = plainBytes.Length / encryptionTimeHdd;

     
        File.Delete(tempFile);

        return (encryptionTimeRam, decryptionTimeRam, ramThroughput, hddThroughput);
    }

    private static SymmetricAlgorithm GetAlgorithm(string algorithmName)
    {
        switch (algorithmName)
        {
            case "AES (CSP) 128 bit":
                return new AesCryptoServiceProvider { KeySize = 128 };
            case "AES (CSP) 256 bit":
                return new AesCryptoServiceProvider { KeySize = 256 };
            case "AES Managed 128 bit":
                return new AesManaged { KeySize = 128 };
            case "AES Managed 256 bit":
                return new AesManaged { KeySize = 256 };
            case "Rijndael Managed 128 bit":
                return new RijndaelManaged { KeySize = 128 };
            case "Rijndael Managed 256 bit":
                return new RijndaelManaged { KeySize = 256 };
            case "DES 56 bit":
                return new DESCryptoServiceProvider();
            case "3DES 168 bit":
                return new TripleDESCryptoServiceProvider();
            default:
                throw new NotSupportedException("Nieobsługiwany algorytm szyfrowania.");
        }
    }
}

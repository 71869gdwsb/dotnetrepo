// See https://aka.ms/new-console-template for more information
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace MonitorSystemu
{
    class Program
    {
        private static PerformanceCounter cpuLicznik;
        private static PerformanceCounter memoryLicznik;
        private const string nazwaZrodla = "MonitorSystemu";
        private const string nazwaDziennika = "MonitorDziennik";
        private const string plikLogu = "monitoring_log.txt";

        static void Main(string[] args)
        {
            InicjalizujLiczniki();
            InicjalizujDziennikZdarzen();

            while (true)
            {
                MonitorujSystem();
                Thread.Sleep(5000); //poczekaj 5sek miedzy pomiarami
            }


        }


        private static void InicjalizujLiczniki()
        {
            cpuLicznik = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            memoryLicznik = new PerformanceCounter("Memory", "Available MBytes");

        }

        private static void InicjalizujDziennikZdarzen()
        {
            try
            {
                if (!EventLog.SourceExists(nazwaZrodla))
                {
                    EventLog.CreateEventSource(nazwaZrodla, nazwaDziennika);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Nie można utworzyć źródła dziennika zdarzeń (upewnij się, czy program otworzono jako Administrator): {ex.Message}");
            }
        }

        private static void MonitorujSystem()
        {
            float uzywanieProcesora = cpuLicznik.NextValue();
            float dostepnaPamiec = memoryLicznik.NextValue();

            Console.WriteLine($"Użycie procesora: {uzywanieProcesora}%");
            Console.WriteLine($"Dostępna pamięć: {dostepnaPamiec} MB");
            Console.WriteLine();

            LogujDoPliku(uzywanieProcesora, dostepnaPamiec);
            SprawdzProgiIZapiszZdarzenia(uzywanieProcesora, dostepnaPamiec);
        }
        private static void LogujDoPliku(float uzywanieProcesora, float dostepnaPamiec)
        {
            using (StreamWriter writer = new StreamWriter(plikLogu, true))
            {
                writer.WriteLine($"{DateTime.Now}: Użycie procesora: {uzywanieProcesora}% | Dostępna pamięć: {dostepnaPamiec} MB");
            }
        }

        private static void SprawdzProgiIZapiszZdarzenia(float uzywanieProcesora, float dostepnaPamiec)
        {
            const float progUzywaniaProcesora = 60.0f; // Próg dla użycia procesora (60%)
            const float progPamieci = 1024.0f; // Próg dla dostępnej pamięci (1 GB)

            if (uzywanieProcesora > progUzywaniaProcesora)
            {
                ZapiszZdarzenie($"Przekroczony próg użycia procesora: {uzywanieProcesora}% > {progUzywaniaProcesora}%", EventLogEntryType.Warning);
            }

            if (dostepnaPamiec < progPamieci)
            {
                ZapiszZdarzenie($"Przekroczony próg dostępnej pamięci: {dostepnaPamiec} MB < {progPamieci} MB", EventLogEntryType.Warning);
            }
        }

        private static void ZapiszZdarzenie(string wiadomosc, EventLogEntryType typ)
        {
            try
            {
                EventLog.WriteEntry(nazwaZrodla, wiadomosc, typ);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Nie można zapisać do dziennika zdarzeń: {ex.Message}");
            }
        }
    }
    }
// fintempCopy
// dodac 2 dyski zmapowane
// dodac rok variable
// dodalbym generowanie listy folderow, a poznniej przechwytywanie konkretnego wyrazeniem lambda

using System;
using System.Collections.Generic;
using System.Linq;

namespace CopyDirectories
{
    class Program
    {
        static void Main(string[] args)
        {
			var watch = System.Diagnostics.Stopwatch.StartNew();
            Intro();
            Console.Write("Chcesz nadpisać pliki w swoim lokalnym folderze? Y/N? : ");
            string key1 = Console.ReadLine();
            int key2int;
            string key2;
            do
            {
                Console.Write("Podaj miesiąc (liczbę) z którego chcesz kopiować: ");
                key2 = Console.ReadLine();
                Int32.TryParse(key2, out key2int);
                if (!(key2int <= 12 && key2int >= 1))
                {
                    Console.WriteLine("!!! ERROR - Podaj poprawnie miesiąc! Liczba od 1 do 12.");
                }
            } while (!(key2int <= 12 && key2int >= 1));

            Console.WriteLine("\n*****************************************************");
            Console.WriteLine("* Aby rozpocząć proszę nacisnąć dowolny przycisk... *");
            Console.WriteLine("*****************************************************");
            Console.ReadKey();
            Console.WriteLine();
            bool overwrite = false;

            if (key1.Equals("y", StringComparison.OrdinalIgnoreCase)) { overwrite = true; }

            List<string> PCs = FileReader.load();
            foreach(string PC in PCs.Skip(3))
            {
                Console.WriteLine("Trwa kopiowanie PC: {0}", PC);
                DirCopy.Execute(PC, overwrite, key2);
            }

            Console.WriteLine("*=========================================*");
            Console.WriteLine("| Koniec! Pliki zostały zapisane na dysku.|");
            Console.WriteLine("*=========================================*");
			watch.Stop();
			var elapsedMs = watch.ElapsedMilliseconds;
			double tm = (double)elapsedMs/60000;
			Console.WriteLine("Time: {0} min", tm);
            Console.ReadKey();
        }
        public static void Intro()
        {
            Console.WriteLine(@" _____ _       _                        ____                  ");
            Console.WriteLine(@"|  ___(_)_ __ | |_ ___ _ __ ___  _ __  / ___|___  _ __  _   _ ");
            Console.WriteLine(@"| |_  | | '_ \| __/ _ \ '_ ` _ \| '_ \| |   / _ \| '_ \| | | |");
            Console.WriteLine(@"|  _| | | | | | ||  __/ | | | | | |_) | |__| (_) | |_) | |_| |");
            Console.WriteLine(@"|_|   |_|_| |_|\__\___|_| |_| |_| .__/ \____\___/| .__/ \__, |");
            Console.WriteLine(@"                                |_|              |_|    |___/ ");
            Console.WriteLine("| Witaj w programie fintempCopy :)");
            Console.WriteLine("| W tym samym folderze co plik programu (.exe) powinien znajdować się");
            Console.WriteLine("| plik PC.txt, tam wpisz swoje PC oraz ścieżkę do której chcesz kopiować");
            Console.WriteLine("| pliki z fintempa. Następnie konsola zapyta czy chcesz napisać pliki");
            Console.WriteLine("| oraz z którego miesiąca chcesz kopiować. Program działa w tle, możesz");
            Console.WriteLine("| bez obaw korzystać z Excela, SAPa i innych programów. W razie odkrycia");
            Console.WriteLine("| błędów lub jakichkolwiek innych problemów proszę o kontakt z Dominikiem");

        }
    }
}

using System;
using System.IO;

namespace CopyDirectories
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Kopiowanie plików z Fintemp. Witam :)");
            Console.WriteLine("UWAGA: Pamiętaj, że ponowne uruchomienie programu spowoduje nadpisanie danych.");
            Console.WriteLine("Aby rozpocząć proszę nacisnąć dowolny przycisk...");
            Console.ReadKey();
            string[] pcs = pcList.load();
            foreach(string PC in pcs)
            {
                Console.WriteLine("Trwa kopiowanie PC: {0}", PC);
                DirCopy.Execute(PC);
            }
            Console.WriteLine("Koniec! :)");
            Console.ReadKey();
        }
    }
}

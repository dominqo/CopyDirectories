using System;
using System.IO;

namespace CopyDirectories
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Witaj w programie fintempCopy by DHACZEK :)");
            Console.WriteLine("Wpisz wszystkie swoje PC w pliku PC.txt, który powinien się znajdować w tym samym folderze co ten program.");
            Console.Write("Chcesz (ewentualnie) nadpisać pliki? Program nadpisze wtedy zasoby w twoim lokalnym folderze. Y/N? : ");
            string key = Console.ReadLine();
            Console.WriteLine("Aby rozpocząć proszę nacisnąć dowolny przycisk...");
            Console.ReadKey();
            bool overwrite = false;

            if (key == "Y" || key == "y") { overwrite = true; }

            string[] pcs = pcList.getPC();
            foreach(string PC in pcs)
            {
                Console.WriteLine("Trwa kopiowanie PC: {0}", PC);
                DirCopy.Execute(PC, overwrite);
            }

            Console.WriteLine("Koniec! :)");
            Console.ReadKey();
        }
    }
}

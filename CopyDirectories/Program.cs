using System;
using System.Collections.Generic;
using System.Linq;

namespace CopyDirectories
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Witaj w programie fintempCopy by DHACZEK :)");
            Console.WriteLine("Ustaw ścieżkę do której chcesz kopiować zasoby z fintemp w pliku PC.txt.");
            Console.WriteLine("Wpisz wszystkie swoje PC w pliku PC.txt, który powinien się znajdować w tym samym folderze co ten program.");
            Console.Write("Chcesz nadpisać pliki w swoim lokalnym folderze? Y/N? : ");
            string key = Console.ReadLine();
            Console.Write("\nAby rozpocząć proszę nacisnąć dowolny przycisk...");
            Console.ReadKey();
            Console.WriteLine();
            bool overwrite = false;

            if (key == "Y" || key == "y") { overwrite = true; }

            List<string> PCs = FileReader.load();
            foreach(string PC in PCs.Skip(3))
            {
                Console.WriteLine("Trwa kopiowanie PC: {0}", PC);
                DirCopy.Execute(PC, overwrite);
            }

            Console.WriteLine("Koniec! :)");
            Console.ReadKey();
        }
    }
}

using System;
using System.IO;

namespace CopyDirectories
{
    static class Szukanie
    {
        public static string[] loadPC()
        {
            
            StreamReader file = null;
            try
            {
                file = new StreamReader("PC.txt");
                int a = 0;
                while (file.ReadLine() != null) { a++; }
                string[] tablica = new string[a];
                file.DiscardBufferedData();
                file.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
                for (int i = 0; i < a; i++)
                {
                    tablica[i] = file.ReadLine();
                }
                return tablica;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
                string[] strings = new string[] { "No file" };
                return strings;
            }
            finally
            {
                if (file != null)
                    file.Dispose();
            }
        }
    }
}

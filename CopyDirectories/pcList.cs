using System;
using System.IO;

namespace CopyDirectories
{
    static class pcList
    {
        private static string[] load()
        {
            StreamReader file = null;
            try 
            {
                file = new StreamReader("PC.txt");
                int a = 0;
                while (file.ReadLine() != null) { a++; }
                string[] tablica = new string[a];
                file.DiscardBufferedData();
                file.BaseStream.Seek(0, SeekOrigin.Begin);
                for (int i = 0; i < a; i++)
                {
                    tablica[i] = file.ReadLine();
                }
                return tablica;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Plik PC.txt nie istnieje!");
                string[] strings = new string[] { "No file present" };
                return strings;
            }
            finally
            {
                if (file != null)
                    file.Dispose();
            }
        }
        public static string[] getPC()
        {
            string[] tablicaCala = load();
            int count = tablicaCala.Length;
            string[] tablicaPC = new string[count - 3];
            for(int i=0; i<(count-3); i++)
            {
                tablicaPC[i] = tablicaCala[i + 3];
            }
            return tablicaPC;
        }
        public static string getPath()
        {
            string[] tablicaCala = load();
            string path = tablicaCala[1];
            return path;
        }
    }
}

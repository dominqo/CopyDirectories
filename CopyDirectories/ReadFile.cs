using System;
using System.IO;

namespace CopyDirectories
{
    static class ReadFile
    {
        //public static StreamReader file = new StreamReader("PC.txt");
        public static int loadPC(int num)
        {
            int[] tablica = new int[countPC()];
            StreamReader file = null;
            try
            {
                file = new StreamReader("PC.txt");
                int i = 0;
                while (file.Peek() >= 0)
                {
                    tablica[i] = Int32.Parse(file.ReadLine());
                    i++;
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
            finally
            {
                if (file != null)
                    file.Dispose();
            }
            return tablica[num];
        }
        public static int countPC()
        {
            StreamReader file = new StreamReader("PC.txt");
            int i = 0;
            while (file.ReadLine() != null) { i++; }
            return i;
        }
    }
}

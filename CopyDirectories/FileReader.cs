using System;
using System.Collections.Generic;
using System.IO;

namespace CopyDirectories
{
    static class FileReader
    {
        public static List<string> load()
        {
            List<string> profitcList = new List<string>();
            StreamReader file = null;
            try 
            {
                file = new StreamReader("PC.txt");
                while (!file.EndOfStream)
                {
                    profitcList.Add(file.ReadLine());
                }
            }
            catch (FileNotFoundException)
            {
                // TODO: Test try catch
                Console.WriteLine("Plik PC.txt nie istnieje!");
            }
            finally
            {
                if (file != null)
                    file.Dispose();
            }
            return profitcList;
        }
    }
}

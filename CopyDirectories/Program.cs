using System;
using System.IO;

namespace CopyDirectories
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] pcList = Szukanie.loadPC();
            foreach(string PC in pcList)
            {
                Console.WriteLine("Twoje PC: {0}", PC);
                //DirCopy.address(@"D:\Projekty\playground\lol", @"D:\Projekty\playground\zal", true);
            }
            Console.ReadKey();
        }
    }
}

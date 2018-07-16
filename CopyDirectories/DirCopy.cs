using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CopyDirectories
{
    static class DirCopy
    {
        private static void Address(string sourceDirName, string destDirName, bool copySubDirs, bool overwrite)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException("Source directory does not exist or could not be found: " + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it. 
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                try
                {
                    string temppath = Path.Combine(destDirName, file.Name);
                    file.CopyTo(temppath, overwrite);
                }
                catch (IOException)
                {
                    Console.WriteLine("[{0}] - Plik nie może zostać nadpisany, ponieważ nie wybrałeś tej opcji!", file.Name);
                }
                
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    Address(subdir.FullName, temppath, copySubDirs, overwrite);
                }
            }
        }
        public static void Execute(string ProfitCenter, bool overwrite)
        {
            List<string> myList = FileReader.load();
            string mainCopyTo = myList.ElementAt(1);
            const string mainCopyFrom = @"D:\Projekty\xfintemp\2018 File System\GFS_PLANTS";
            DirectoryInfo dirMain = new DirectoryInfo(mainCopyFrom);
            DirectoryInfo[] directories = dirMain.GetDirectories();

            // TODO: Simplify
            foreach (DirectoryInfo dir in directories)
            {
                if (dir.Name.Contains(ProfitCenter))
                {

                    DirectoryInfo[] dir2 = dir.GetDirectories();
                    foreach (DirectoryInfo nextdir in dir2)
                    {
                        Console.WriteLine("Kopiuję folder {0}", nextdir.Name);
                        DirectoryInfo[] dir3 = nextdir.GetDirectories();
                        foreach (DirectoryInfo nextdirx in dir3)
                        {
                            if (nextdirx.Name.Contains("06"))
                            {
                                Address(nextdirx.FullName, Path.Combine(mainCopyTo, ProfitCenter), true, overwrite);
                            }
                        }
                    }
                }
            }
        }

    }
}

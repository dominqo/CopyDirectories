using System;
using System.IO;

namespace CopyDirectories
{
    class DirCopy
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
            const string mainCopyTo = @"N:\var\www\html\playground";
            const string mainCopyFrom = @"D:\Projekty\playground\lol";
            DirectoryInfo dirMain = new DirectoryInfo(mainCopyFrom);
            DirectoryInfo[] directories = dirMain.GetDirectories();

            foreach (DirectoryInfo dir in directories)
            {
                if (dir.Name.Contains(ProfitCenter))
                {
                    Console.WriteLine("Proszę czekać...", dir.FullName);
                    Address(Path.Combine(dir.FullName, "RECON"), Path.Combine(mainCopyTo, ProfitCenter), true, overwrite);
                    Address(Path.Combine(dir.FullName, "SYSTEM_REPORTS"), Path.Combine(mainCopyTo, ProfitCenter), true, overwrite);
                }
            }
        }

    }
}

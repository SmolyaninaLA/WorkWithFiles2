using System;
using System.IO;



    public static class TaskDirectory
    {
        public static long GetDirSize(DirectoryInfo dir)
        {
            long size = 0;
            FileInfo[] fileInDir = dir.GetFiles();
            DirectoryInfo[] Dir = dir.GetDirectories();

            // посчитали размер файлов
            foreach(FileInfo f in fileInDir)
            {
                size = size + f.Length;
            }

            // размер в директории
            foreach (DirectoryInfo d in Dir)
            {
                size = size + GetDirSize(d);
            }

            return size;
        }
    }



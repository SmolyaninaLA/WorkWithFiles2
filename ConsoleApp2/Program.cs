using System;
using System.IO;
 

class Program
{
    static void Main(string[] args)
    {
        // получим папку

        Console.WriteLine("Введите путь ");
        string pathDir = Console.ReadLine();


        if (!Directory.Exists(pathDir))
        {
            Console.WriteLine("Нет указанго пути");
        }
        else
        {
            string[] subdir = Directory.GetDirectories(pathDir);
            DirectoryInfo dr;

            foreach (string sd in subdir)
            {
                dr = new DirectoryInfo(sd);
                try
                {
                    long size = GetDirSize(dr);
                    Console.WriteLine("Размер директории {0}", size);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при подсчете размера директории {0}", ex.Message);

                }
            }
        }
    }

    
    
    public static long GetDirSize(DirectoryInfo dir)
    {
        long size = 0;
        FileInfo[] fileInDir = dir.GetFiles();
       
        // посчитали размер файлов
        foreach(FileInfo f in fileInDir)
        {
            size += f.Length;
        }

        // размер в директории
        DirectoryInfo[] Dir = dir.GetDirectories();

        foreach (DirectoryInfo d in Dir)
        {
            size += GetDirSize(d);
        }

        return size;
    }
   
}




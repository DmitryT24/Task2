using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Policy;


class Task2
{
    static void Main(string[] args)
    {
        /// если путь небыл передан в программу, ввести в поле программы
        string pathCatalog = "";

        if (args.Length == 0)
        {

            Console.WriteLine("Пожалуйста, введите путь каталога:");
            pathCatalog = Console.ReadLine();
            // return;
        }
        else
        {
            if (!string.IsNullOrEmpty(args[0]))
            {
                pathCatalog = args[0];
            }
            else
            {
                Console.WriteLine("Путь введен не корректно! Перезапустите программу и попробуйте снова!");
                Console.ReadKey();
                return;
            }
        }

        if (!Directory.Exists(pathCatalog))
        {
            Console.WriteLine("Путь введен не корректно! Перезапустите программу и попробуйте снова!");
            Console.ReadKey();

            return;
        }
        try
        {
            Console.WriteLine($"Размер каталога -  {pathCatalog} составляет: {CountSizeFolder(pathCatalog)} байт");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Упс! Ошибка: {ex.Message}");
            Console.ReadKey();
        }
    }


    static long CountSizeFolder(string folderPath)
    {
        long sizeFolder = 0;
        DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
        foreach (FileInfo fileInfo in directoryInfo.GetFiles())
        {
            sizeFolder += fileInfo.Length;
        }


        foreach (DirectoryInfo dirInfo in directoryInfo.GetDirectories())
        {
            sizeFolder += CountSizeFolder(dirInfo.FullName);
        }

        return sizeFolder;
    }
}


using System;
using System.IO;

class FolderInspector
{
    public static void Inspect(string path)
    {
        Console.WriteLine("FILES:");

        foreach (var file in Directory.GetFiles(path))
        {
            FileInfo fi = new FileInfo(file);

            Console.WriteLine($"{fi.Name} | {fi.Length} bytes | {fi.CreationTime}");
        }

        Console.WriteLine("\nFOLDERS:");

        foreach (var dir in Directory.GetDirectories(path))
        {
            Console.WriteLine(dir);
        }
    }
}
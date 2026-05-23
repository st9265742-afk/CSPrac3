using System;
using System.IO;

class CacheCleaner
{
    public static (int files, long size) CleanRecursive(string path)
    {
        int count = 0;
        long size = 0;

        foreach (var file in Directory.GetFiles(path))
        {
            FileInfo fi = new FileInfo(file);

            size += fi.Length;
            fi.Delete();
            count++;
        }

        foreach (var dir in Directory.GetDirectories(path))
        {
            var result = CleanRecursive(dir);
            count += result.files;
            size += result.size;
        }

        return (count, size);
    }
}
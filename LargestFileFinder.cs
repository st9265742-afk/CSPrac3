using System;
using System.IO;

class LargestFileFinder
{
    public static FileInfo FindLargest(string path)
    {
        FileInfo largest = null;

        foreach (var file in Directory.GetFiles(path))
        {
            FileInfo fi = new FileInfo(file);

            if (largest == null || fi.Length > largest.Length)
                largest = fi;
        }

        foreach (var dir in Directory.GetDirectories(path))
        {
            FileInfo subLargest = FindLargest(dir);

            if (subLargest != null &&
                (largest == null || subLargest.Length > largest.Length))
            {
                largest = subLargest;
            }
        }

        return largest;
    }
}
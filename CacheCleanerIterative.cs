using System;
using System.Collections.Generic;
using System.IO;

class CacheCleanerIterative
{
    public static (int files, long size) Clean(string root)
    {
        Stack<string> stack = new Stack<string>();
        stack.Push(root);

        int count = 0;
        long size = 0;

        while (stack.Count > 0)
        {
            string current = stack.Pop();

            foreach (var file in Directory.GetFiles(current))
            {
                FileInfo fi = new FileInfo(file);

                size += fi.Length;
                fi.Delete();
                count++;
            }

            foreach (var dir in Directory.GetDirectories(current))
            {
                stack.Push(dir);
            }
        }

        return (count, size);
    }
}
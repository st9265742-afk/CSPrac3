using System;
using System.IO;

class TextAnalyzer
{
    public static void Analyze(string inputPath, string outputPath)
    {
        int lines = 0;
        int words = 0;
        int chars = 0;

        using (StreamReader sr = new StreamReader(inputPath))
        {
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                lines++;
                chars += line.Length;

                string[] splitWords = line.Split(
                    new char[] { ' ', '\t' },
                    StringSplitOptions.RemoveEmptyEntries);

                words += splitWords.Length;
            }
        }

        using (StreamWriter sw = new StreamWriter(outputPath))
        {
            sw.WriteLine($"Lines: {lines}");
            sw.WriteLine($"Words: {words}");
            sw.WriteLine($"Characters: {chars}");
        }

        Console.WriteLine("Report created.");
    }
}
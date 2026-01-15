using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Použití: program.exe znamky.txt vystup.txt");
            return;
        }

        string inputFile = args[0];
        string outputFile = args[1];

        if (!File.Exists(inputFile))
        {
            Console.WriteLine("Vstupní soubor neexistuje.");
            return;
        }

        string[] lines = File.ReadAllLines(inputFile);
        List<string> output = new List<string>();

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            string[] parts = line.Split(' ');
            string subject = parts[0];

            int sum = 0;
            int count = 0;

            for (int i = 1; i < parts.Length; i++)
            {
                sum += int.Parse(parts[i]);
                count++;
            }

            double average = (double)sum / count;
            output.Add($"{subject} {average:F2}");
        }

        File.WriteAllLines(outputFile, output);

        Console.WriteLine("Hotovo. Výstup uložen do " + outputFile);
    }
}



using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TreasuryChallenge.src.Extensions
{
    public static class ExportFileExtension
    {
        private const string Directory = @"..\..\..\ResultFiles";

        public static void ExportToTextFile<T>(this List<T> records, string fileName)
        {
            StringBuilder stringBuilder = new();

            foreach (var record in records)
            {
                stringBuilder.Append(record + "\n");
            }

            File.WriteAllText(Path.Combine(Directory, fileName), stringBuilder.ToString());

            Console.WriteLine($"A file {fileName} with {records.Count} codes was generated in the folder ResultFiles.");
        }
    }
}
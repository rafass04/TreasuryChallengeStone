using System;
using System.Collections.Generic;
using System.Linq;

namespace TreasuryChallenge.src.Services
{
    public class GenerateCodesService : IGenerateCodesService
    {
        private static readonly char[] Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(0, 26);
        private const int CodeSize = 7;

        public List<string> GenerateCodes(int numberOfLines)
        {
            var codes = new HashSet<string>(numberOfLines);
            var random = new Random();

            while (codes.Count != numberOfLines)
            {
                HashSet<char> chars = new HashSet<char>();

                while (chars.Count != CodeSize)
                {
                    int number = random.Next(Chars.Length);
                    chars.Add(Chars[number]);
                }

                codes.Add(string.Concat(chars));
            }
            return codes.ToList();
        }
    }
}
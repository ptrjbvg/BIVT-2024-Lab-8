using System;
using System.Collections.Generic;
using System.Globalization;

namespace Lab_8
{
    public class Blue_3 : Blue
    {
        private (char, double)[] _output = Array.Empty<(char, double)>();
        public (char, double)[] Output => _output;

        public Blue_3(string input) : base(input) {}

        public override void Review()
        {
            Dictionary<char, int> counts = new();
            int total = 0;
            string word = "";

            foreach (char c in Input)
            {
                if (char.IsLetter(c) || c == '-' || c == '\'')
                {
                    word += c;
                }
                else
                {
                    if (word != "")
                    {
                        char first = char.ToLower(word[0]);
                        if (char.IsLetter(first))
                        {
                            counts[first] = counts.GetValueOrDefault(first) + 1;
                            total++;
                        }
                        word = "";
                    }
                }
            }

            if (word != "")
            {
                char first = char.ToLower(word[0]);
                if (char.IsLetter(first))
                {
                    counts[first] = counts.GetValueOrDefault(first) + 1;
                    total++;
                }
            }

            var list = new List<(char, double)>();
            foreach (var pair in counts)
            {
                double percent = 100.0 * pair.Value / total;
                list.Add((pair.Key, percent));
            }

            list.Sort((a, b) =>
            {
                int cmp = b.Item2.CompareTo(a.Item2);
                return cmp != 0 ? cmp : a.Item1.CompareTo(b.Item1);
            });

            _output = list.ToArray();
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, Array.ConvertAll(Output,
                t => $"{t.Item1}-{t.Item2.ToString("0.###", CultureInfo.InvariantCulture)}"));
        }
    }
}

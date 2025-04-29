using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Lab_8
{
    public class Blue_3 : Blue
    {
        private (char Letter, double Percentage)[] _output;

        public (char Letter, double Percentage)[] Output => _output?.ToArray();

        public Blue_3(string input) : base(input)
        {
            _output = null;
        }

        public override void Review()
        {
            if (string.IsNullOrWhiteSpace(Input))
            {
                _output = Array.Empty<(char, double)>();
                return;
            }

            char[] separators = { ' ', '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };

            var words = Input
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .Where(w => w.Length > 0 && char.IsLetter(w[0]))
                .Select(w => char.ToLower(w[0]))
                .ToList();

            if (words.Count == 0)
            {
                _output = Array.Empty<(char, double)>();
                return;
            }

            var grouped = words
                .GroupBy(c => c)
                .Select(g => (Letter: g.Key, Percentage: Math.Round(g.Count() * 100.0 / words.Count, 4)))
                .OrderByDescending(item => item.Percentage)
                .ThenBy(item => item.Letter)
                .ToArray();

            _output = grouped;
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0)
                return string.Empty;

            return string.Join(Environment.NewLine,
                _output.Select(s =>
                    $"{s.Letter} - {s.Percentage:F4}".Replace('.', ',')
                ));
        }
    }
}

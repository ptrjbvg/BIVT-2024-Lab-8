using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Blue_3 : Blue
{
    private (char, double)[] _output;
    public (char, double)[] Output => _output ?? Array.Empty<(char, double)>();

    public Blue_3(string input) : base(input)
    {
        _output = null;
    }

    public override void Review()
    {
        var words = Regex.Matches(Input, @"\b[а-яёa-zA-Z'-]+\b", RegexOptions.IgnoreCase);
        int total = words.Count;

        var freq = new Dictionary<char, int>();

        foreach (Match word in words)
        {
            if (word.Length == 0) continue;
            char c = char.ToLower(word.Value[0]);
            if (!char.IsLetter(c)) continue;

            if (!freq.ContainsKey(c))
                freq[c] = 0;
            freq[c]++;
        }

        _output = freq
            .Select(pair => (pair.Key, Math.Round(100.0 * pair.Value / total, 4)))
            .OrderByDescending(t => t.Item2)
            .ThenBy(t => t.Item1)
            .ToArray();
    }

    public override string ToString()
    {
        return string.Join("\n", Output.Select(t => $"{t.Item1} - {t.Item2}"));
    }
}

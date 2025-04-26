using System;
using System.Text.RegularExpressions;

public class Blue_2 : Blue
{
    private string _output;
    public string Output => _output ?? "";

    private string _sequence;

    public Blue_2(string input, string sequence) : base(input)
    {
        _sequence = sequence;
        _output = null;
    }

    public override void Review()
    {
        string pattern = $@"\b\w*{Regex.Escape(_sequence)}\w*\b";
        string cleaned = Regex.Replace(Input, pattern, "", RegexOptions.IgnoreCase);
        cleaned = Regex.Replace(cleaned, @"\s+", " ").Trim();
        _output = cleaned;
    }

    public override string ToString()
    {
        return Output;
    }
}

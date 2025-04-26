using System;
using System.Collections.Generic;

namespace Lab_8
{
    public class Blue_2 : Blue
    {
        private string _sequence;
        private string _output = "";
        public string Output => _output;

        public Blue_2(string input, string sequence) : base(input)
        {
            _sequence = sequence ?? "";
        }

        public override void Review()
        {
            List<string> words = new();
            string word = "";

            foreach (char c in Input)
            {
                if (char.IsWhiteSpace(c))
                {
                    if (word != "")
                    {
                        if (!word.Contains(_sequence, StringComparison.OrdinalIgnoreCase))
                            words.Add(word);
                        word = "";
                    }
                }
                else
                {
                    word += c;
                }
            }

            if (word != "" && !word.Contains(_sequence, StringComparison.OrdinalIgnoreCase))
                words.Add(word);

            _output = string.Join(" ", words);
        }

        public override string ToString() => Output;
    }
}

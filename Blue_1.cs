using System;
using System.Collections.Generic;

namespace Lab_8
{
    public class Blue_1 : Blue
    {
        private string[]? _output;
        public string[]? Output => _output;

        public Blue_1(string input) : base(input) {}

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = null;
                return;
            }

            var words = new List<string>();
            var current = "";

            foreach (char c in Input)
            {
                if (char.IsWhiteSpace(c))
                {
                    if (current != "") words.Add(current);
                    current = "";
                }
                else
                {
                    current += c;
                }
            }

            if (current != "") words.Add(current);

            var lines = new List<string>();
            string line = "";

            foreach (var word in words)
            {
                if (word.Length > 50)
                {
                    if (line != "") 
                    {
                        lines.Add(line);
                        line = "";
                    }
                    lines.Add(word);
                }
                else if ((line.Length == 0 ? 0 : line.Length + 1) + word.Length <= 50)
                {
                    line += (line == "" ? "" : " ") + word;
                }
                else
                {
                    if (line != "") lines.Add(line);
                    line = word;
                }
            }

            if (line != "") lines.Add(line);

            _output = lines.Count > 0 ? lines.ToArray() : null;
        }

        public override string ToString()
        {
            return _output == null ? "" : string.Join(Environment.NewLine, _output);
        }
    }
}

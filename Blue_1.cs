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
            if (Input == null)
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
                if ((line + (line == "" ? "" : " ") + word).Length <= 50)
                {
                    line += (line == "" ? "" : " ") + word;
                }
                else
                {
                    lines.Add(line);
                    line = word;
                }
            }

            if (line != "") lines.Add(line);

            _output = lines.ToArray();
        }

        public override string ToString()
        {
            return _output == null ? "" : string.Join(Environment.NewLine, _output);
        }
    }
}

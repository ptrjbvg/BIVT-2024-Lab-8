using System;
using System.Collections.Generic;

namespace Lab_8
{
    public class Blue_1 : Blue
    {
        private string[]? _output;
        
        public string[]? Output
        {
            get
            {
                if (_output == null) return null;
                string[] copy = new string[_output.Length];
                Array.Copy(_output, copy, _output.Length);
                return copy;
            }
        }

        public Blue_1(string input) : base(input) {}

        public override void Review()
        {
            if (string.IsNullOrWhiteSpace(Input))
            {
                _output = null;
                return;
            }

            var words = new List<string>();
            var currentWord = "";

            foreach (char c in Input)
            {
                if (char.IsWhiteSpace(c))
                {
                    if (currentWord != "")
                    {
                        words.Add(currentWord);
                        currentWord = "";
                    }
                }
                else
                {
                    currentWord += c;
                }
            }

            if (currentWord != "")
            {
                words.Add(currentWord);
            }

            var lines = new List<string>();
            string currentLine = "";

            foreach (var word in words)
            {
                if (word.Length > 50)
                {
                    if (currentLine != "")
                    {
                        lines.Add(currentLine);
                        currentLine = "";
                    }
                    lines.Add(word);
                }
                else
                {
                    if (currentLine.Length + (currentLine == "" ? 0 : 1) + word.Length <= 50)
                    {
                        currentLine += (currentLine == "" ? "" : " ") + word;
                    }
                    else
                    {
                        if (currentLine != "")
                        {
                            lines.Add(currentLine);
                        }
                        currentLine = word;
                    }
                }
            }

            if (currentLine != "")
            {
                lines.Add(currentLine);
            }

            _output = lines.Count > 0 ? lines.ToArray() : null;
        }

        public override string ToString()
        {
            return _output == null ? "" : string.Join(Environment.NewLine, _output);
        }
    }
}

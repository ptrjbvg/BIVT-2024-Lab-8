using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_8
{
    public class Blue_2 : Blue
    {
        private string _sequence;
        private string? _output;

        public string? Output => _output;

        public Blue_2(string input, string sequence) : base(input)
        {
            _sequence = sequence ?? "";
            _output = null;
        }

        public override void Review()
        {
            if (Input == null)
            {
                _output = null;
                return;
            }

            StringBuilder result = new StringBuilder();
            StringBuilder word = new StringBuilder();
            bool lastCharWasLetter = false;

            foreach (char c in Input)
            {
                if (char.IsLetter(c) || c == '-' || c == '\'')
                {
                    word.Append(c);
                    lastCharWasLetter = true;
                }
                else
                {
                    if (word.Length > 0)
                    {
                        string currentWord = word.ToString();
                        if (!currentWord.Contains(_sequence, StringComparison.OrdinalIgnoreCase))
                        {
                            result.Append(currentWord);
                        }
                        word.Clear();
                    }
                    result.Append(c);
                    lastCharWasLetter = false;
                }
            }

            if (word.Length > 0)
            {
                string currentWord = word.ToString();
                if (!currentWord.Contains(_sequence, StringComparison.OrdinalIgnoreCase))
                {
                    result.Append(currentWord);
                }
            }

            _output = CleanSpaces(result.ToString());
        }

        private string CleanSpaces(string text)
        {
            StringBuilder cleaned = new StringBuilder();
            bool lastWasSpace = false;

            foreach (char c in text)
            {
                if (char.IsWhiteSpace(c))
                {
                    if (!lastWasSpace)
                    {
                        cleaned.Append(' ');
                        lastWasSpace = true;
                    }
                }
                else
                {
                    cleaned.Append(c);
                    lastWasSpace = false;
                }
            }

            return cleaned.ToString().Trim();
        }

        public override string ToString()
        {
            return Output ?? "";
        }
    }
}

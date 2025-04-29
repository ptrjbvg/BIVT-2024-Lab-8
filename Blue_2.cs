using System;
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
            bool insideWord = false;
            bool insideQuotes = false;
            bool lastWasDeleted = false;

            foreach (char c in Input)
            {
                if (c == '"')
                {
                    result.Append(c);
                    insideQuotes = !insideQuotes;
                    continue;
                }

                if (char.IsLetter(c) || c == '-' || c == '\'')
                {
                    word.Append(c);
                    insideWord = true;
                }
                else
                {
                    if (insideWord)
                    {
                        string currentWord = word.ToString();
                        if (!currentWord.Contains(_sequence, StringComparison.OrdinalIgnoreCase))
                        {
                            result.Append(currentWord);
                            lastWasDeleted = false;
                        }
                        else
                        {
                            lastWasDeleted = true;
                        }
                        word.Clear();
                        insideWord = false;
                    }

                    if (IsPunctuation(c))
                    {
                        result.Append(c);
                    }
                    else if (char.IsWhiteSpace(c))
                    {
                        if (!lastWasDeleted && result.Length > 0 && result[^1] != ' ')
                        {
                            result.Append(' ');
                        }
                    }
                    else
                    {
                        result.Append(c);
                    }
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

        private bool IsPunctuation(char c)
        {
            return char.IsPunctuation(c) && c != '"';
        }

        public override string ToString()
        {
            return Output ?? "";
        }
    }
}

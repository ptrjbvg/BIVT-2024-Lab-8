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

            foreach (char c in Input)
            {
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
                        }
                        word.Clear();
                        insideWord = false;
                    }
                    result.Append(c);
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

            _output = CleanSpacesAndPunctuation(result.ToString());
        }

        private string CleanSpacesAndPunctuation(string text)
        {
            StringBuilder cleaned = new StringBuilder();
            bool lastWasSpace = false;

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

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
                    if (IsPunctuation(c) && cleaned.Length > 0 && cleaned[^1] == ' ')
                    {
                        cleaned.Length--;
                    }

                    cleaned.Append(c);
                    lastWasSpace = false;
                }
            }

            return cleaned.ToString().Trim();
        }

        private bool IsPunctuation(char c)
        {
            return c == '.' || c == ',' || c == ';' || c == ':' || c == '?' || c == '!' || c == '–' || c == '—' || c == '"';
        }

        public override string ToString()
        {
            return Output ?? "";
        }
    }
}

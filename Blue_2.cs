using System;
using System.Text;

namespace Lab_8
{
    public class Blue_2 : Blue
    {
        private string _output;
        private string _tool;

        public string Output => _output;

        private string Tool => _tool;

        public Blue_2(string input, string tool) : base(input)
        {
            _tool = tool;
            _output = null;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input) || string.IsNullOrEmpty(_tool))
            {
                _output = string.Empty;
                return;
            }

            StringBuilder result = new StringBuilder();
            StringBuilder word = new StringBuilder();
            bool insideWord = false;

            for (int i = 0; i < Input.Length; i++)
            {
                char c = Input[i];

                if (char.IsLetterOrDigit(c) || c == '-' || c == '\'')
                {
                    word.Append(c);
                    insideWord = true;
                }
                else
                {
                    if (insideWord)
                    {
                        string w = word.ToString();
                        if (!w.Contains(_tool))
                        {
                            result.Append(w);
                        }
                        word.Clear();
                        insideWord = false;
                    }
                    result.Append(c);
                }
            }

            if (insideWord)
            {
                string w = word.ToString();
                if (!w.Contains(_tool))
                {
                    result.Append(w);
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
            return _output;
        }
    }
}

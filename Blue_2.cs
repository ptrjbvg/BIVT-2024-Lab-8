using System;
using System.Text;

namespace Lab_8
{
    public class Blue_2 : Blue
    {
        private string _output;
        private string _tool;

        public string Output => _output;

        public string Tool => _tool;

        public Blue_2(string input, string tool) : base(input)
        {
            _output = "";
            _tool = tool;
        }

        public override void Review()
        {
            StringBuilder result = new StringBuilder();
            StringBuilder word = new StringBuilder();
            bool insideWord = false;
            bool lastWasDeleted = false;

            foreach (char c in Input)
            {
                if (Char.IsLetterOrDigit(c) || c == '-' || c == '\'')
                {
                    word.Append(c);
                    insideWord = true;
                }
                else
                {
                    if (insideWord)
                    {
                        if (!word.ToString().Contains(_tool))
                        {
                            result.Append(word.ToString());
                        }
                        else
                        {
                            lastWasDeleted = true;
                        }
                        word.Clear();
                        insideWord = false;
                    }

                    if (Char.IsPunctuation(c) || Char.IsWhiteSpace(c))
                    {
                        if (lastWasDeleted && Char.IsWhiteSpace(c) && result.Length > 0 && result[result.Length - 1] != ' ')
                        {
                            result.Append(" "); // Добавляем пробел, если предыдущий был удален
                        }
                        result.Append(c);
                    }
                }
            }

            if (insideWord && !word.ToString().Contains(_tool))
            {
                result.Append(word.ToString());
            }

            _output = CleanSpaces(result.ToString().Trim());
        }

        private string CleanSpaces(string text)
        {
            StringBuilder cleaned = new StringBuilder();
            bool lastWasSpace = false;

            foreach (char c in text)
            {
                if (Char.IsWhiteSpace(c))
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

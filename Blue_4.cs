using System;

public class Blue_4 : Blue
{
    private int _output = 0;
    public int Output => _output;

    public Blue_4(string input) : base(input) {}

    public override void Review()
    {
        int sum = 0;
        string current = "";
        foreach (char c in Input)
        {
            if (char.IsDigit(c))
            {
                current += c;
            }
            else
            {
                if (current != "")
                {
                    sum += ManualParse(current);
                    current = "";
                }
            }
        }

        if (current != "")
        {
            sum += ManualParse(current);
        }

        _output = sum;
    }

    private int ManualParse(string num)
    {
        int result = 0;
        foreach (char c in num)
        {
            result = result * 10 + (c - '0');
        }
        return result;
    }

    public override string ToString() => Output.ToString();
}

using System;

public abstract class Blue
{
    private string _input;
    public string Input => _input;

    protected Blue(string input)
    {
        _input = input;
    }

    public abstract void Review();
}

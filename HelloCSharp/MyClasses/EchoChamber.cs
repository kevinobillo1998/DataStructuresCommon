using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses;

public class EchoChamber
{
    int _repeat;
    public int Repeat
    {
        get
        {
            return _repeat;
        }
        set
        {
            if (value < 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            _repeat = value;
        }
    }

    private string _last;

    public string Last
    {
        get
        {
            return _last;
        }
    }

    public EchoChamber()
    {
        Repeat = 3;
    }

    public EchoChamber(int repeat)
    {
        Repeat = repeat;
    }

    public string Echo(string text)
    {
        string echoedText = "";
        for (int i = 0; i < Repeat; i++)
        {
            echoedText = echoedText + text;
        }
        return echoedText;
    }
}

namespace MyClasses;

public class SayStuffClass
{
    public static void SayGoodbye()
    {
        System.Console.WriteLine("Goodbye");
    }

    public static void SayAnything(string thingToSay)
    {
        System.Console.WriteLine(thingToSay);
    }

    public static string CreateGoodbye(string name)
    {
        string goodbyeString = "Goodbye " + name;
        return goodbyeString;
    }
}


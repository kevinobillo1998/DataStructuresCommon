using System;
using MyClasses;

public class Hello
{
    public static void Main(string[] args)
    {
        Console.WriteLine("hello, world!");
        System.Console.WriteLine("Calling System.Console explicitly!");

        int i = 3;
        Console.WriteLine("i is " + i);

        i++;
        int j = i * 3;
        Console.WriteLine("i is {0}, and j is {1}", i, j);

        /*Console.WriteLine("What is your name?");
        string name;
        name = Console.ReadLine();
        Console.WriteLine("Hello, {0}!!", name);

        if (name == "Wade")
        {
            Console.WriteLine("Hello instructor!");
        } else
        {
            Console.WriteLine("Hello student!");
        }*/

        int[] numbers = { 1, 5, 7 };

        for (int l = 0; l < numbers.Length; l++)
        {
            Console.WriteLine(numbers[l]);
        }

        SayStuffClass.SayGoodbye();
        SayStuffClass.SayAnything("Anything!");
        string returnedString = SayStuffClass.CreateGoodbye("Wade");
        Console.WriteLine(returnedString);

        Console.WriteLine("The magic numbers is {0}", StrangeMath.GetMagicnumber());
        Console.WriteLine("I add 7 and 13 and get {0}", StrangeMath.AddInts(7, 13));

        int a = 11;
        int b = 27;
        Console.WriteLine("Before swapints a is {0} and b is {1}", a, b);
        StrangeMath.SwapInt(a, b);
        Console.WriteLine("After swapints a is {0} and b is {1}", a, b);

        Console.WriteLine("Before swapintsbyref a is {0} and b is {1}", a, b);
        StrangeMath.SwapIntsByRef(ref a, ref b);
        Console.WriteLine("After swapintsbyref a is {0} and b is {1}", a, b);

        MyString ms1 = new MyString("Hi there!");
        MyString ms3 = new MyString("3");
        Console.WriteLine("ms1 is {0} and ms3 is {1}", ms1, ms3);
        Console.WriteLine("ms1's string is {0}",ms1.StringField);
        ms1.StringField = "New String!";
        Console.WriteLine("ms1's string is now {0}", ms1.StringField);
        Console.WriteLine("ms1's length is {0}", ms1.StringLength);

        Console.WriteLine("before swap ms1 is {0} and ms3 is {1}", ms1, ms3);
        SwapMyStrings(ms1, ms3);
        Console.WriteLine("After swap ms1 is {0} and ms3 is {1}", ms1, ms3);

        Console.WriteLine("before swap values ms1 is {0} and ms3 is {1}", ms1, ms3);
        SwapMyStringsValues(ms1, ms3);
        Console.WriteLine("After swap values ms1 is {0} and ms3 is {1}", ms1, ms3);


        Console.WriteLine("before swap refs ms1 is {0} and ms3 is {1}", ms1, ms3);
        SwapMyStringsByRef(ref ms1, ref ms3);
        Console.WriteLine("After swap refs ms1 is {0} and ms3 is {1}", ms1, ms3);

        MyString first = new MyString("One");
        MyString second = new MyString("Two");
        MyString third = new MyString("Three");
        Console.WriteLine("First compareto second is {0}", first.CompareTo(second));
        Console.WriteLine("Is First > Second? {0}", first > second);

        EchoChamber myEcho = new EchoChamber(5);
        string echoed = myEcho.Echo("Hello");
        Console.WriteLine(echoed);
    }

    public static void SwapMyStrings(MyString left, MyString right)
    {
        MyString temp = left;
        left = right;
        right = temp;
        Console.WriteLine("Inside the swap left is {0} and right is {1}", left, right);
    }

    public static void SwapMyStringsValues(MyString left, MyString right)
    {
        string temp = left.StringField;
        left.StringField = right.StringField;
        right.StringField = temp;
        Console.WriteLine("Inside the swap values left is {0} and right is {1}", left, right);
    }

    public static void SwapMyStringsByRef(ref MyString left, ref MyString right)
    {
        MyString temp = left;
        left = right;
        right = temp;
        Console.WriteLine("Inside the swap strings by ref left is {0} and right is {1}", left, right);
    }
}
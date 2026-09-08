namespace MyClasses;

static public class StrangeMath
{
    static public int GetMagicnumber()
    {
        return 3;
    }

    static public long AddInts(int left, int right)
    {
        return (long)left + (long)right;
    }

    static public void SwapInt(int left, int right)
    {
        int temp = left;
        left = right;
        right = temp;
        Console.WriteLine("SwapInts: Left is {0}, right is {1}", left, right);
    }

    static public void SwapIntsByRef(ref int left, ref int right)
    {
        int temp = left;
        left = right;
        right = temp;
        Console.WriteLine("SwapIntsByRef: Left is {0}, right is {1}", left, right);
    }
}

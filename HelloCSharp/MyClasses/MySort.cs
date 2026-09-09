using System.Security.Cryptography.X509Certificates;

namespace MyClasses;

public static class MySort
{
    public enum SortDirection { Ascending,Descending };

    public static void Sort(string[] strings, SortDirection direction)
    {
        // Do a Bubble Sort!
        // Go through the array
        // Look at an item
        // Go through the array looking at that item and swapping it
        //   if it needs to 'bubble' to the end        

    }

    public static void swapItems(ref string left, ref string right)
    {
        string tmp = left;
        left = right;
        right = tmp;
    }

    public static bool shouldSwap(string left, string right, SortDirection direction)
    {
        bool result = false;

        if (direction == SortDirection.Ascending)
        {
            result = left.CompareTo(right) > 0;
        }
        else if(direction == SortDirection.Descending)
        {
            result = right.CompareTo(left) > 0;
        }

        return result;
    }
}

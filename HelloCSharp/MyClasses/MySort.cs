using System.Security.Cryptography.X509Certificates;

namespace MyClasses;

public static class MySort
{
    public enum SortDirection { Ascending,Descending };

    public delegate void dMySort<A>(A[] myItems, SortDirection direction);

    public static void Sort<X>(X[] aItems, SortDirection dir, dMySort<X> sortMethod)
    {
        sortMethod(aItems, dir);
    }

    public static void BubbleSort<T>(T[] items, SortDirection direction) where T: IComparable
    {
        // Do a Bubble Sort!
        // Go through the array
        for (int i = 0; i < items.Length; i++)
        {
            // Look at an item
            // Go through the array looking at that item and swapping it
            //   if it needs to 'bubble' to the end
            for (int j = i + 1; j < items.Length; j++)
            {
                if (shouldSwap<T>(items[i], items[j], direction))
                {
                    swapItems<T>(ref items[i], ref items[j]);
                }
            }
        }
    }

    // Bozo Sort's algorithm is very simple:
    // while the array is not sorted:
    //    swap the position of two random items
    //    check if the list is sorted
    public static void BozoSort<T>(T[] items, SortDirection dir) where T: IComparable
    {
        Random rnd = new Random();
        while (! IsInOrder(items, dir))
        {
            swapItems(ref items[rnd.Next(items.Length)], ref items[rnd.Next(items.Length)]);
        }

    }

    public static bool IsInOrder<T>(T[] aItems, SortDirection dir) where T: IComparable
    {
        // Write a method which returns true if the array passed in is already in order
        // false, otherwise

        // Go through every item in the array
        for (int i = 0; i < (aItems.Length - 1); i++)
        {
            // Compare it to the item after it
            // return false if they're out of order
            int compare = aItems[i].CompareTo(aItems[i + 1]);
            if ((dir == SortDirection.Ascending) && (compare > 0))
            {
                return false;
            }
            if ((dir == SortDirection.Descending) && (compare < 0))
            {
                return false;
            }
        }
        // If you get through the whole array and nothing is out of order, return true
        return true;
    }

    public static void swapItems<T>(ref T left, ref T right)
    {
        T tmp = left;
        left = right;
        right = tmp;
    }

    public static bool shouldSwap<T>(T left, T right, SortDirection direction) where T: IComparable
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

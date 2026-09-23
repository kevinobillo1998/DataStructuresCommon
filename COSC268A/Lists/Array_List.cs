using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lists;

/// <summary>
/// an implementation of a list using arrays
/// </summary>
/// <typeparam name="T"> The  type the list stroed</typeparam>
public class Array_List<T>: A_List<T> where T : IComparable<T>
{
    //private attribute to actually hold our values, initialized to empty:
    private T[] values = new T[0];

    public override int Count
    {
        get { return values.Length; }
    }


    public override void Add(T data)
    {
        // to add, we'll need to create a new array one bigger thanthe old one
        T[] newValues = new T[values.Length+1];
        //Loop through the old array and copy the values over
        for (int i = 0; i < values.Length; i++)
        {
            newValues[i] = values[i];
        }
        //The last slot of the new array, which doesnt have anything in it yet,
        // is where we'll add the new value:
        newValues[newValues.Length - 1] = data;

        //dont forget to set out internal values to the new array:
        values = newValues;
    }

    public override void Clear()
    {
        //Clearing arrays
        values = new T[0];
    }

    public override IEnumerator<T> GetEnumerator()
    {
        return new Enumerator(this);
    }

    public override int IndexOf(T data)
    {
        //For index of we'll just iterate through the array until we find the item
        // were looking for
        for (int i = 0; i < values.Length; i++)
        {
            if (data.Equals(values[i]))
            {
                return i;
            }
        }
        throw new ApplicationException("Could not find item " + data + " in the list");

    }

    public override void Insert(int index, T data)
    {
        // Make a new bigger array
        // Loop through the old array, copying values over

        if(index < 0 || index >= values.Length)
        {
            throw new IndexOutOfRangeException("Index " + index + " out of range of the list");
        }

        T[] newValues = new T[values.Length + 1];

        int j = 0; // the index for the new array

        // "i" is the index for the old array
        for (int i = 0; i < values.Length; i++)
        {
            if (i < index)
            {
                newValues[i] = values[i];
            }
            else if (i == index)
            {
                newValues[i] = data;
            }
            else
            {
                newValues[i] = values[i - 1];
            }
        }

        values = newValues;


        //if ( index < 0 || index >= values.Length)
        //{
        //    throw new IndexOutOfRangeException("Index " + index + " out of range of the list");
        //}

        ////Wades solution
        //T[] newValues = new T[values.Length + 1];

        //int j = 0; // the index for the new array

        //// "i" is the index for the old array
        //for (int i = 0; i < values.Length; i++)
        //{

        //    // when you get to the insertion index, add the new value
        //    // (After this point, the indexes in the old array, amd new array will
        //    //If were at the insertion point, we'll do something different:
        //    if (i == index)
        //    {
        //        newValues[j] = data;
        //        j++;
        //    }

        //    newValues[j] = values[i];
        //    j++;
        //}

        //values = newValues;
    }

    public override bool Remove(T data)
    {
        try
        {
            int indexOfElementToRemove = IndexOf(data);
            RemoveAt(indexOfElementToRemove);
            return true;
        }
        catch (ApplicationException e)
        {

            return false;
        }
    }

    public override T RemoveAt(int index)
    {
        //Keep track of the element removed (because we need to return it)
        T data = default(T);
        //T tReturn = default(T);

        //Create a new array one shorter than the last one
        T[] rtnArray = new T[values.Length - 1];

        int j = 0;

        //Loop through the old array copying every value except the one being replaced
        for (int i = 0; i < values.Length; i++)
        {
            if(i == index) 
            {
                data = values[i]; 
            }
            else
            {
                rtnArray[j++] = values[i];
            }
        }

        //Dont forget to set values to the new array
        values = rtnArray;

        //Return the item that was removed
        return data;
    }

    public override T ReplaceAt(int index, T data)
    {
        T tReturn = values[index];
        values[index] = data;
        return tReturn;
    }

    private class Enumerator : IEnumerator<T>
    {
        //keep track of a reference to the outer class parent we're enumerating:
        private Array_List<T> list;
        // keep track of where in the array we're looking at:
        private int index;

        //The constructor is just going to store that reference to the outer class:
        public Enumerator(Array_List<T> l)
        {
            this.list = l;
            Reset();
        }

        //Return the current value the enumerator is pointing at
        public T Current
        {
            get
            {
                return list.values[index];
            }
        }

        object IEnumerator.Current => Current;

        //Just free up any references so they can be GC'd
        public void Dispose()
        {
            list = null;
        }
        //Reset should set the enumerator to be looking at just before the start
        public void Reset()
        {
            index = -1;
        }

        public bool MoveNext()
        {
            if ((index + 1) < list.values.Length)
            {
                index++;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

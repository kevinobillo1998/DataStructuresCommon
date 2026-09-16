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
        throw new NotImplementedException();
    }

    public override IEnumerator<T> GetEnumerator()
    {
        return new Enumerator(this);
    }

    public override void Insert(int index, T data)
    {
        throw new NotImplementedException();
    }

    public override bool Remove(T data)
    {
        throw new NotImplementedException();
    }

    public override T RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    public override T ReplaceAt(int index, T data)
    {
        throw new NotImplementedException();
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

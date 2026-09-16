using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresCommon;

/// <summary>
/// Abstract partial implementation of common collection functionality
/// </summary>
/// <typeparam name="T">The type stored in the collection</typeparam>
public abstract class A_Collection<T>: I_Collection<T> where T: IComparable<T>
{
    // How can we count the items in a collection without knowing how they're stored?
    // We know we can foreach over the collection because it must implement
    // IEnumerable. While it is inefficient potentially, we can just foreach
    // over the whole collection and count.
    // We'll mark our implementation as virtual because our children may
    // want to override it
    public virtual int Count
    {
        get
        {
            int count = 0;
            foreach (T item in this)
            {
                count++;
            }
            return count;
            
        }
    }

    // We can also implement Contains by just iterating over the whole
    // collection looking for a match
    // Again, mark as virtual because some implementations might have
    // more efficient ways of doing this
    public virtual bool Contains(T data)
    {
        bool found = false;

        // Foreach works by getting an enumerator from an IEnumerable class
        // We can get that enumerator directly if we want:
        IEnumerator<T> myEnumerator = this.GetEnumerator();
        // Go to the start of the the thing we're enumerating:
        myEnumerator.Reset();

        // Loop through the items in the collection until I find the data
        // The MoveNext() method of an enumerator will return true if
        // the enumerator is able to advance to the next item
        while (!found && myEnumerator.MoveNext())
        {
            // The Current property of the enumerator is whatever object
            // we're currently looking at
            found = myEnumerator.Current.Equals(data);
        }

        // Tell the enumerator to clean up:
        myEnumerator.Dispose();

        // Return whether or not we found the item:
        return found;
    }

    // We will override the ToString method
    // Most data collection don't actually need a tostring method,
    // but for learning and debugging purposes it could be useful
    public override string ToString()
    {
        // StringBuilder is just a way to add strings together
        StringBuilder sb = new StringBuilder("[");
        string seperator = ", ";

        foreach (T item in this)
        {
            sb.Append(item + seperator);            
        }

        // I'll remove the hanging comma at the end, assuming our collection wasn't empty
        if (Count > 0)
        {
            sb.Remove(sb.Length - seperator.Length, seperator.Length);
        }

        sb.Append("]");
        return sb.ToString();
    }

    // If someone calls the non-generic version of GetEnumerator,
    // just return the generic version of the enumerator
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public abstract void Add(T data);
    public abstract void Clear();
    public abstract bool Remove(T data);
    public abstract System.Collections.Generic.IEnumerator<T> GetEnumerator();
}

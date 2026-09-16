using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructuresCommon;

namespace Lists;

public abstract class A_List<T> : A_Collection<T>, I_List<T> where T : IComparable<T>
{
    public virtual T ElementAt(int index)
    {
        //The default operator in C# returns a default of the type
        //If you call default(int) it'll give 0, if you call default(bool) it'll give
        //false, if you call it on a reference type you'll get a null, etc.
        T tReturn = default(T);

        if(index < 0 || index >= this.Count)
        {
            throw new IndexOutOfRangeException("Invalid index (" + index + ")");
        }

        int count = 0;
        IEnumerator<T> myEnum  = this.GetEnumerator();
        myEnum.Reset();

        //Loop while there are more data items and we're not at the current index
        while (myEnum.MoveNext() && count != index)
        {
            count++;
        }

        //Once the count equals the index, we know we're at the rink index!
        tReturn = myEnum.Current;


        return tReturn;
    }

    //Frequently people will create a method body and just throw an exception
    //If they don;t want to write the method yet
    public virtual int IndexOf(T data)
    {
        throw new NotImplementedException();
    }
    public abstract void Insert(int index, T data);
    public abstract T RemoveAt(int index);
    public abstract T ReplaceAt(int index, T data);
}

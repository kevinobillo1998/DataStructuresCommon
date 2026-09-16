using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructuresCommon;

namespace Lists;

public abstract class A_List<T> : A_Collection<T>, I_List<T> where T : IComparable<T>
{
    public abstract T ElementAt(int index);
    public abstract int IndexOf(T data);
    public abstract void Insert(int index, T data);
    public abstract T RemoveAt(int index);
    public abstract T ReplaceAt(int index, T data);
}

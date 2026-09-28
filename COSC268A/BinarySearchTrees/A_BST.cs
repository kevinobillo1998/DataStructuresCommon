using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructuresCommon;

namespace BinarySearchTrees;

public abstract class A_BST<T> : A_Collection<T>, I_BST<T> where T : IComparable<T>
{
    public abstract T Find(T data);
    public abstract int Height();
    public abstract void Iterate(ProcessData<T> pd, TRAVERSALORDER order);
}

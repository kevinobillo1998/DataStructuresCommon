using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
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

    //All BSTs are going to need to store a reference to the root node of the tree:
    protected Node<T> nRoot;

    //Keep a counter to track the number of items in the tree
    protected int iCount = 0;
    
    //A_Collection counts the items by enumerating the entire data structure
    //Thats pretty slow, so let us just return our count:
    public override int Count { get => iCount; }
}

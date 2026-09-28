using System;
using DataStructuresCommon;

namespace BinarySearchTrees;

// Define a delegate type that will point to a method
// that will perform some action on a data member of type T
public delegate void ProcessData<T>(T data);

public enum TRAVERSALORDER { PRE_ORDER, IN_ORDER, POST_ORDER};

public interface I_BST<T>: I_Collection<T> where T: IComparable<T>
{
    /// <summary>
    /// Given a data element , find the corresponding element of equal value
    /// 
    /// </summary>
    /// <param name="data">An item equal to the item to be found</param>
    /// <returns>A refernce to the item found</returns>
    T Find(T data);


    /// <summary>
    /// Returns the height of the tree
    /// </summary>
    /// <returns>The number of edges from the root to the deepest leaf</returns>
    /// I've chosen to do this as a method, but it would also make sense as a property.
    /// I prefer a method because this can be computationally expensive.
    int Height();

    void Iterate(ProcessData<T> pd, TRAVERSALORDER order);




}

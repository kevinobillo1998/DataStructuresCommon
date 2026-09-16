using System;
using DataStructuresCommon;

namespace Lists;

/// <summary>
/// Interface for implementations of the List ADT
/// </summary>
/// <typeparam name="T">The type the list stores</typeparam>
public interface I_List<T>: I_Collection<T> where T: IComparable<T>
{
    // What operations must every list have?
    /// <summary>
    /// Fetches an item in a specific position in the list
    /// </summary>
    /// <param name="index">The location of the item to retrieve</param>
    /// <returns>The item that is at that index</returns>
    T ElementAt(int index);

    /// <summary>
    /// Given a data item, return its index
    /// </summary>
    /// <param name="data">The data to find</param>
    /// <returns>The index of that data item</returns>
    int IndexOf(T data);

    /// <summary>
    /// Inserts an item into the list
    /// </summary>
    /// <param name="index">Where to insert it</param>
    /// <param name="data">What to insert</param>
    void Insert(int index, T data);

    /// <summary>
    /// Removes the item at a specified index
    /// </summary>
    /// <param name="index">Where to remove the item from</param>
    /// <returns>The removed item</returns>
    T RemoveAt(int index);

    /// <summary>
    /// Replaces the item at a specified index
    /// </summary>
    /// <param name="index">Where to replace the item</param>
    /// <param name="data">The item to replace with</param>
    /// <returns>The replaced item</returns>
    T ReplaceAt(int index, T data);
}

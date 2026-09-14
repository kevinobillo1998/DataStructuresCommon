using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresCommon;

/// <summary>
/// Common interface for collection data types
/// </summary>
/// <typeparam name="T">The type the collection stores</typeparam>
public interface I_Collection<T> : IEnumerable<T> where T: IComparable<T>
{
    // These operations pretty much every collection will have:

    /// <summary>
    /// Adds an item to the collection
    /// </summary>
    /// <param name="data">The item to add</param>
    void Add(T data);

    /// <summary>
    /// Remove all items from the collection
    /// </summary>
    void Clear();

    /// <summary>
    /// Determine if the given data item is in the collection
    /// </summary>
    /// <param name="data">Item to check for</param>
    /// <returns>True if the item is present, false otherwise</returns>
    bool Contains(T data);

    /// <summary>
    /// Removes an item from the collection
    /// </summary>
    /// <param name="data">The item to Remove</param>
    /// <returns>True if the item was removed, false if the item wasn't in the collection</returns>
    bool Remove(T data);

    /// <summary>
    /// The number of items in the collection
    /// </summary>
    int Count
    {
        get;
    }
}

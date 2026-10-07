using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees;

public class BST<T> : A_BST<T>, ICloneable where T : IComparable<T>
{
    public BST()
    {
        //Initialize the root:
        nRoot = null;
        //Set the count to 0:
        iCount = 0;
    }
    public override void Add(T data)
    {
        //Where do we add a new node? where it belongs!
        //The really easy case is when the tree is empty:
        if (nRoot == null)
        {
            nRoot = new Node<T>(data);
        }
        else
        {
            // Otherwise we'll use recursion to solve this:
            recAdd(data, nRoot);
            nRoot = Balance(nRoot);
        }
        iCount++;
    }

    //Helper method to recursively add a Node to a tree:
    private void recAdd(T data, Node<T> nCurrent)
    {
        //Comparthe data we're adding to the current node and see if the new
        // Data belong to the left or right.
        int iCompare = data.CompareTo(nCurrent.Data);

        //If the data were adding belongs on the left (iCompare < 0):
        if (iCompare < 0)
        {
            //Base case: it belongs on the left, and nCurrent doesnt have a left Child
            if (nCurrent.Left == null)
            {
                //Create the new node and add it as the current Node's left child
                nCurrent.Left = new Node<T>(data);
            }
            else
            {
                //Recursive case: it belongs on the left but nCurrent already has a left child:
                //Recursively call on our left child
                recAdd(data, nCurrent.Left);
                nCurrent.Left = Balance(nCurrent.Left);
            }
        }
        //Otherwise it belongs on the right (iCompare > 0):
        if (iCompare > 0)
        {
            //Base case: it belongs on the right, and nCurrent doesnt have a right Child
            if (nCurrent.Right == null)
            {
                //Create the new node and add it as the current Node's right child
                nCurrent.Right = new Node<T>(data);
            }
            else
            {
                //Recursive case: it belongs on the right but nCurrent already has a right child:
                //Recursively call on our right child
                recAdd(data, nCurrent.Right);
                nCurrent = Balance(nCurrent.Right);
            }
        }
    }

    internal virtual Node<T> Balance(Node<T> nCurrent)
    {
        return nCurrent;
    }

    public override void Clear()
    {
        throw new NotImplementedException();
    }

    public object Clone()
    {
        throw new NotImplementedException();
    }

    public override T Find(T data)
    {
        return recFind(data, nRoot);
    }

    protected T recFind(T data, Node<T> nCurrent)
    {
        T tReturn = default(T);
        // First base case - if nCurrent is null, the item isn't in the tree
        if (nCurrent == null)
        {
            //     So throw a new ApplicationException saying we haven't found it
            throw new ApplicationException("Item " + data + " not in tree.");
        }
        else
        {
            // Otherwise, if nCurrent isn't null...
            //     Use CompareTo to check where the data item we're looking for will be
            int iResult = data.CompareTo(nCurrent.Data);
            //     Second Base Case - if the compareto is 0, we've found our item! So return the current item.
            if (iResult == 0)
            {
                tReturn = nCurrent.Data;
            }
            else if (iResult < 0)
            {
                //     Otherwise if it is less than, recurse on the lefthand of the tree
                tReturn = recFind(data, nCurrent.Left);
            }
            else
            {
                //     Otherwise if it is greater than, recurse on the righthand of the tree
                tReturn = recFind(data, nCurrent.Right);
            }
        }
        // Return the found object:
        return tReturn;
    }

    /// <summary>
    /// Returns the data of the node furthers right in the tree
    /// </summary>
    /// <returns>The largest node in the tree</returns>
    public T FindLargest()
    {
        //If the root is null the tree is empty and there is no largest, so exception
        if(nRoot == null)
        {
            throw new ApplicationException("Root is null, cant find the largest in empty tree");
        }
        else
        {
            return recFindLargest(nRoot);
        }
    }

    protected T recFindLargest(Node<T> nCurrent)
    {
        T tReturn = default(T);
        if (nCurrent.Right == null)
        {
            tReturn = nCurrent.Data;
        }
        else
        {
            tReturn = recFindLargest(nCurrent.Right);
        }
        return tReturn;
    }


    /// <summary>
    /// Returns the data of the data further left in the tree
    /// </summary>
    /// <returns>The small node in the tree</returns>
    public T FindSmallest()
    {
        //If the root is null the tree is empty and there is no smallest, so exception

        if (nRoot == null)
        {
            throw new ApplicationException("Root is null, cant find the smallest in empty tree");
        }
        else
        {
            return recFindSmallest(nRoot);
        }
    }
    protected T recFindSmallest(Node<T> nCurrent)
    {
        T tReturn = default(T);
        if (nCurrent.Left == null)
        {
            tReturn = nCurrent.Data;
        }
        else
        {
            tReturn = recFindSmallest(nCurrent.Left);
        }
        return tReturn;
    }
    
    

    //The height of the tree is the number of edges from the deepest leaf node
    // to root node
    // If there is only a root node and no children, the height will be 0
    public override IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    // The height of the tree is the number of edges from the deepest leaf node
    // to root node
    // If there is only a root node and no children, the height will be 0
    // If there is no root node - a completely empty tree - we'll say height is -1
    public override int Height()
    {
        // Easy case: if the tree is empty, height is -1
        int iHeight = -1;
        // Almost as easy, if the root node has not children, the height is 0
        // If the root node HAS children, the height of the tree will be equal to
        // the greater of the height on the left and the height on the right PLUS 1
        // How do we find out the height of the left child?
        //   If the left child has no children, its height is 0!
        //   If the left child has at least one child, its height will be equal to
        //     the height of the tallest child plus one
        // And so on
        if (nRoot != null)
        {
            iHeight = recHeight(nRoot);
        }

        return iHeight;
    }
    protected static int recHeight(Node<T> nCurrent)
    {
        int iHeightLeft = 0;
        int iHeightRight = 0;
        if (nCurrent.Left != null)
        {
            iHeightLeft = recHeight(nCurrent.Left) + 1;
        }
        if (nCurrent.Right != null )
        {
            iHeightRight = recHeight(nCurrent.Right) + 1;
        }
        int iGreaterHeight = iHeightLeft > iHeightRight ? iHeightLeft : iHeightRight;
        return iGreaterHeight;
    }

    public override void Iterate(ProcessData<T> pd, TRAVERSALORDER order)
    {
        throw new NotImplementedException();
    }

    public override bool Remove(T data)
    {
        // We do need to keep track of whether or not we removed the node:
        bool bRemoved = false;
        // We need to alter the tree to remove the node:
        nRoot = recRemove(nRoot, data, ref bRemoved);
        //I passed bRemoved in as a ref so the method can change its value
        return bRemoved;
    }

    private Node<T> recRemove(Node<T> nCurrent, T data, ref bool bRemoved)
    {
        //We only need to do something if the current node isnt full. If it is null,
        // we know we couldnt find the node to remove, so bRemoved can stay false
        if(nCurrent != null)
        {
            int iCompare = data.CompareTo(nCurrent.Data);
            if(iCompare < 0)
            {
                //if it isnt the right node and the node we want to remove is on the left,
                // recurse on the left:
                nCurrent.Left = recRemove(nCurrent.Left, data, ref bRemoved);
            }
            else if(iCompare > 0) 
            {
                nCurrent.Right = recRemove(nCurrent.Right, data, ref bRemoved);
            }
            else
            {
                //Base case: weve found the node the remove!
                bRemoved = true;
                if(nCurrent.IsLeaf())
                {
                    nCurrent = null;
                    iCount--;
                }
                else if (nCurrent.Left != null && nCurrent.Right != null)
                {
                    //If it has TWO Children:
                    //We will need to pull up a node from beneath us to take out place.
                    //What nodes are viable candidates? either the biggest node on the left,
                    //Or the smallest node on the right
                    //We'll use the largest on the left - so we need to grab a referance to it
                    T tReplacement = recFindLargest(nCurrent.Left);
                    //Replace the current nodes data value with out replacement:
                    nCurrent.Data= tReplacement;
                    // Now of course that replacement node exists in the tree twice...
                    // so go ahead and remove the original replacement
                    nCurrent.Left = recRemove(nCurrent.Left, tReplacement, ref bRemoved);

                }else if (nCurrent.Left != null)
                {
                    nCurrent = nCurrent.Left;
                    iCount--;
                }
                else
                {
                    nCurrent = nCurrent.Right;
                    iCount--;
                }
            }
        }
        return nCurrent;

    }

    public override string ToString()
    {
        return "Tree : " + nRoot;
    }
}

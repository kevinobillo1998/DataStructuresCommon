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
        throw new NotImplementedException();
    }

    //The height of the tree is the number of edges from the deepest leaf node
    // to root node
    // If there is only a root node and no children, the height will be 0
    public override IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public override int Height()
    {

        
        
        //Easy case: If the tree is empty, height is -1
        if (nRoot == null)
        {
            return -1;
        }
        //Almost as easy, if the root node has no children, the ehight is 0;
        if (nRoot.Left == null && nRoot.Right == null )
        {
            return 0;
        }
        //If the root node HAS children, the height of the tree will be equal to
        // The greater of the height on the left and the height on the right PLUS 1
        //How do we find out the height of the left child?
        //  If the left child has no children, it sheight is 0!
        // If the left child has at least one child, its height will be equal to
        // the height of the tallest child plus one
        // and so on
    }
    private void recHeight()

    public override void Iterate(ProcessData<T> pd, TRAVERSALORDER order)
    {
        throw new NotImplementedException();
    }

    public override bool Remove(T data)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return "Tree : " + nRoot;
    }
}

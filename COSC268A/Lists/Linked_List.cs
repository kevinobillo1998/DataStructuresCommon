using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists;

public class Linked_List<T> : A_List<T> where T : IComparable<T>
{

    // A reference to the head of the Linked List:
    private Node head;

    public override void Add(T data)
    {
        //Just call the recursive add method:
        //head = recAdd(head, data);

        // Let us try writing and iteratively instead!
        // If the list is empty, thats easy -just create a new node and point head at it
        //Otherwise:
        // Progress through the list going from next to next until you find the last node
        // The last nodes next value should be null

        // Once you reach a node whose next is null, create a new node, and set the old
        // last nodes next value to point at the new node
        Node current = head;

        if(head != null)
        {
            while(current.next != null)
            {
             current = current.next;
            }
            current.next= new Node(data);
        }
        else
        {
            head = new Node(data);
        }
    }


    /// <summary>
    /// Recursive helper method for add.
    /// Takes in a node and a data item to add to the end of the chain
    /// </summary>
    /// <param name="current">The current node we're looking at</param>
    /// <param name="data">The data to add to the end of the list</param>
    /// <returns>The current node</returns>
    private Node recAdd(Node current, T data)
    {
        // Base case is that we're at the end of the chain:
        if(current == null)
        {
            //add in the new data
            current = new Node(data);
        }
        else
        {
            //the recursive case is that we're not at the end of the list:
            current.next = recAdd(current.next, data);
        }

        return current;
    }

    public override void Clear()
    {
        head = null;
    }

    public override IEnumerator<T> GetEnumerator()
    {
        return new LinkedListEnumerator(this);
    }

    public override void Insert(int index, T data)
    {
        throw new NotImplementedException();
    }

    //public override bool Remove(T data)
    //{
    //    //Let us try remove with an iterative version:
    //    // keep track of whatever or not we were able to find the item to remove:
    //    bool bRemoved = false;

    //    //if the list is empty, theres nothing to remove:
    //    if (head == null)
    //    {
    //        return bRemoved = true;
    //    }

    //    //next case we need to consider - if the data we're removinhg is at
    //    // the head of the list
    //    if (head.data.CompareTo(data) == 0)
    //    {
    //        head = head.next;
    //        bRemoved = true;
    //    }
    //    else
    //    {
    //        // if its not at the head of the list, we need to use a loop 
    //        // to move through the list. Since we're singly linked, we need to keep
    //        // track of not only the node we want to remove, but also its previous neighbour
    //        Node currentNode = head;
    //        Node scoutNode;
    //        // We'll keep looping while two things are true:
    //        // * we haven't removed the item yet
    //        // * there are still items in the list we haven't looked at
    //        while (!bRemoved && currentNode != null)
    //        {
    //            //Keep track of the next node in the sequence
    //            scoutNode = currentNode.next;
    //            // Is the next node in the sequence the node I need to remove?
    //            if (scoutNode != null && scoutNode.data.CompareTo(data) == 0 {
    //                //We'll sset our current nodes next to be the target node's next
    //                bRemoved = true;
    //                currentNode.next = scoutNode.next;
    //            }
    //            else
    //            {
    //                currentNode = scoutNode;
    //            }
    //        }



    //        //return if we were able to successfully remove or not:
    //        return bRemoved;
    //    }
    //}
    public override bool Remove(T data)
    {
        return recRemove(ref head, data);
    }

    private bool recRemove(ref Node current, T data)
    {
        //we'll need to keep track of whether or not the node was found and remove
        bool bRemoved = false;
        //We'll have two base cases to consider:
        //One base case is current is null, which means the item isnt present and
        //cant be removed
        if(current == null)
        {
            bRemoved = false;
        }

       else if(current.data.CompareTo(data) == 0)
        {
            
            current = current.next;
            bRemoved = true;
        }
        else
        {
            bRemoved = recRemove(ref current.next, data);
        }
            // The other base case if we've FOUND the item to revome
            // If weve found it, mark that we've found it
            // Cut out the item to remove
            //If neither of those base cases were met, recurse on the next node
            // We always retyrn whether or nit we were able to remove it eventually

         return bRemoved;
    }

    public override T RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    public override T ReplaceAt(int index, T data)
    {
        throw new NotImplementedException();
    }
    /// <summary>
    /// A single node in a linked list which stores data of Type T
    /// </summary>
    private class Node
    {
        public T data;
        public Node next;
        public Node(T data, Node next)
        {
            this.data = data;
            this.next = next;
        }

        public Node(T data) : this(data, null) { }

    }
    private class LinkedListEnumerator : IEnumerator<T>
    {
        //We'll keep a reference to the linked list we're enumerating
        private Linked_List<T> list;

        //Keep a reference to the Node we've ecently visited:
        private Node lastVisited;

        //Keep a reference to the next node we're going to visit
        private Node scout;


        public T Current
        {
            get
            {
                //return the value of the node we're currently looking at:
                return lastVisited.data;
            }

        }
        object IEnumerator.Current => Current;

        public LinkedListEnumerator(Linked_List<T> list)
        {
            this.list = list;
            Reset();
        }

        public void Dispose()
        {
            list = null;
            scout = null;
            lastVisited = null;
        }

        public bool MoveNext()
        {
            bool bWasAbleToMove = false;

            //We'll return true if we are able to move, false otherwise:
            if(scout != null)
            {
                bWasAbleToMove = true;
                //Since theres a next node, advace our lastvisited to point at
                //next, and advance scout to point at the one after:
                lastVisited = scout;
                scout = lastVisited.next;
            }
            return bWasAbleToMove;
            
        }

        public void Reset()
        {
            //remember a reset call should point us at before the start of the collection
            //whuch means we arent currently visitng any nodes:
            lastVisited = null;

            //The next node we're going to visit - the scout - is gping to be the head of the 
            // list:
            scout = list.head;
        }
    }
      

}

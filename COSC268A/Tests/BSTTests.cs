using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinarySearchTrees;

namespace TreeTests;

public class NodeTests
{
    [Test]
    public void TestNode()
    {
        Node<string> root = new Node<string>("Root");
        root.Left = new Node<string>("Left");
        root.Right = new Node<string>("Right");
        root.Right.Left = new Node<string>("RightLeft");
        root.Right.Right = new Node<string>("RightRight");
        Assert.IsFalse(root.IsLeaf());
        Assert.IsFalse(root.Right.IsLeaf());
        Assert.IsTrue(root.Left.IsLeaf());
        string treeString = "(Root L((Left)) R((Right L((RightLeft)) R((RightRight)))))";
        Assert.AreEqual(treeString, root.ToString());
    }
}

public class BSTTests
{
    private BST<int> iBST;

    [SetUp]

    public void BSTTEstSetup()
    {
        iBST = new BST<int>();
        iBST.Add(50);
        iBST.Add(20);
        iBST.Add(27);
        iBST.Add(77);
        iBST.Add(22);
        iBST.Add(90);
        iBST.Add(89);
        iBST.Add(91);
        /*
         *                  50  
         *             /        \
         *            20         77   
         *              \         \
         *               27         90
         *                /         /   \  
         *              22          89      91
         */

    }

    [Test]
    public void TestHeight()
    {
        Assert.AreEqual(3, sBST);
        BST<string> sBST = new BST<string>();
        Assert.AreEqual(0, sBST);
        sBST.Add("A");
        sBST.Add("B");
        sBST.Add("C");
        sBST.Add("D");
        sBST.Add("E");
        Assert.AreEqual(4, sBST);

    }
    [Test]
    public void TestAdd()
    {
        BST<string> bst = new BST<string>();
        Assert.AreEqual(0,bst.Count);
        bst.Add("Root");
        Assert.AreEqual(1,bst.Count);
        bst.Add("ALeft");
        bst.Add("ZRightN");
        bst.Add("ZRightA");
        bst.Add("ZRightZ");
        Assert.AreEqual(5, bst.Count);
        string treeString = "Tree: (Root L((ALeft)) R((ZRight L((ZRightA)) R((ZRightZ))))";
        Assert.AreEqual(treeString, bst.ToString());
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
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
    private BST<Student> stuBST;

    [SetUp]
    public void BSTTestSetup()
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
         *       50
         *     /     \
         *    20      77
         *      \       \
         *      27      90
         *     /       /  \
         *     22     89   91
         *
         */
        stuBST = new BST<Student>();
        stuBST.Add(new Student("Mandy", 501, "Mandy@hotmail.com"));
        stuBST.Add(new Student("Hu", 133, "hu@gmail.com"));
        stuBST.Add(new Student("Nancy", 613, "nancy@saskpolytech.ca"));
        stuBST.Add(new Student("Ahmed", 189, "ahmed@gmail.com"));
        stuBST.Add(new Student("Jane", 648, "jane@outlook.com"));
        /*                  Mandy
         *                /      \
         *               Hu      Nancy
         *                 \         \
         *                 Ahmed    Jane
         */
    }

    [Test]
    public void TestBSTDepthFirstEnumerator()
    {
        // Default enumerator is Depth first:
        IEnumerator<int> myEnum = iBST.GetEnumerator();
        myEnum.Reset();
        Assert.IsTrue(myEnum.MoveNext());
        Assert.AreEqual(50, myEnum.Current);
        // We'll assume left child first
        Assert.IsTrue(myEnum.MoveNext());
        Assert.AreEqual(20, myEnum.Current);
        Assert.IsTrue(myEnum.MoveNext());
        Assert.AreEqual(27, myEnum.Current);
        Assert.IsTrue(myEnum.MoveNext());
        Assert.AreEqual(22, myEnum.Current);
        Assert.IsTrue(myEnum.MoveNext());
        Assert.AreEqual(77, myEnum.Current);
        Assert.IsTrue(myEnum.MoveNext());
        Assert.AreEqual(90, myEnum.Current);
        Assert.IsTrue(myEnum.MoveNext());
        Assert.AreEqual(89, myEnum.Current);
        Assert.IsTrue(myEnum.MoveNext());
        Assert.AreEqual(91, myEnum.Current);
        // We've enumerated the whole tree, so MoveNext should return false:
        Assert.IsFalse(myEnum.MoveNext());
        Assert.AreEqual(91, myEnum.Current);
        // May as well dispose at the end:
        myEnum.Dispose();
    }

    [Test]
    public void TestBSTRemove()
    {
        Assert.IsFalse(iBST.Remove(9999));
        Assert.AreEqual(8, iBST.Count);
        Assert.IsTrue(iBST.Remove(91));
        Assert.AreEqual(7, iBST.Count);
        Assert.Throws<ApplicationException>(() => iBST.Find(91));
        Assert.AreEqual(90, iBST.Find(90));
        Assert.IsTrue(iBST.Remove(50));
        Assert.AreEqual(6, iBST.Count);
        Assert.Throws<ApplicationException>(() => iBST.Find(50));
        Assert.AreEqual(20, iBST.Find(20));
        Assert.AreEqual(77, iBST.Find(77));
    }

    [Test]
    public void TestBSTFindLargest()
    {
        Assert.AreEqual(91, iBST.FindLargest());
        Assert.AreEqual("Jane", stuBST.FindLargest().Name);
        BST<string> emptyBST = new BST<string>();
        Assert.Throws<ApplicationException>(() => emptyBST.FindLargest());
    }

    [Test]
    public void TestBSTFindSmallest()
    {
        Assert.AreEqual(20, iBST.FindSmallest());
        Assert.AreEqual("Hu", stuBST.FindSmallest().Name);
        BST<string> emptyBST = new BST<string>();
        Assert.Throws<ApplicationException>(() => emptyBST.FindSmallest());
    }

    [Test]
    public void TestBSTFind()
    {
        Student jane = stuBST.Find(new Student(null, 648, null));
        Assert.AreEqual("Jane", jane.Name);
        Assert.AreEqual(648, jane.StudentNumber);
        Assert.AreEqual("jane@outlook.com", jane.Email);

        // If we try to find something that isn't in the tree,
        // we should get an ApplicationException:
        Assert.Throws<ApplicationException>(() => stuBST.Find(new Student(null, 999, null)));

        Assert.AreEqual(50, iBST.Find(50));
        Assert.AreEqual(90, iBST.Find(90));
        Assert.AreEqual(22, iBST.Find(22));
        Assert.AreEqual(91, iBST.Find(91));
        Assert.Throws<ApplicationException>(() => iBST.Find(1000));
    }

    [Test]
    public void TestHeight()
    {
        Assert.AreEqual(3, iBST.Height());
        BST<string> sBST = new BST<string>();
        Assert.AreEqual(-1, sBST.Height());
        sBST.Add("A");
        sBST.Add("B");
        sBST.Add("C");
        sBST.Add("D");
        sBST.Add("E");
        Assert.AreEqual(4, sBST.Height());
    }

    [Test]
    public void TestAdd()
    {
        BST<string> bst = new BST<string>();
        Assert.AreEqual(0, bst.Count);
        bst.Add("Root");
        Assert.AreEqual(1, bst.Count);
        bst.Add("ALeft");
        bst.Add("ZRightN");
        bst.Add("ZRightA");
        bst.Add("ZRightZ");
        Assert.AreEqual(5, bst.Count);
        string treeString = "Tree : (Root L((ALeft)) R((ZRightN L((ZRightA)) R((ZRightZ)))))";
        Assert.AreEqual(treeString, bst.ToString());
        Console.WriteLine(treeString);
    }
}

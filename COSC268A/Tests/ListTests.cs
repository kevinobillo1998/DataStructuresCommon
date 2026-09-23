using System;
using System.Collections.Generic;
using Lists;

namespace ListTests;

public class ArrayListTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestAdd()
    {
        Array_List<int> list = new Array_List<int>();
        Assert.AreEqual(0, list.Count);
        list.Add(1);
        Assert.AreEqual(1, list.Count);
        list.Add(2);
        Assert.AreEqual(2, list.Count);
        list.Add(3);
        Assert.AreEqual(3, list.Count);
    }

    [Test]
    public void TestElementAt()
    {
        Array_List<string> list = new Array_List<string>();
        list.Add("a");
        list.Add("b");
        list.Add("c");
        list.Add("d");
        list.Add("e");
        Assert.AreEqual("a", list.ElementAt(0));
        Assert.AreEqual("c", list.ElementAt(2));
        Assert.AreEqual("e", list.ElementAt(4));
        Assert.Throws<IndexOutOfRangeException>(() => list.ElementAt(5));
        Assert.Throws<IndexOutOfRangeException>(() => list.ElementAt(-1));
    }

    [Test]
    public void TestClear()
    {
        Array_List<string> list = new Array_List<string>();
        list.Add("a");
        list.Add("b");
        list.Add("c");
        list.Add("d");
        list.Add("e");
        Assert.AreEqual(5, list.Count);
        list.Clear();
        Assert.AreEqual(0, list.Count);
    }

    [Test]
    public void TestReplaceAt()
    {
        Array_List<string> list = new Array_List<string>();
        list.Add("a");
        list.Add("b");
        list.Add("c");
        list.Add("d");
        list.Add("e");
        Assert.AreEqual("c", list.ReplaceAt(2, "z"));
        Assert.AreEqual("z", list.ElementAt(2));
    }

    [Test]

    public void TestInsert()
    {
        Array_List<string> list = new Array_List<string>();
        list.Add("a");
        list.Add("b");
        list.Add("c");
        list.Add("d");
        list.Add("e");
        list.Insert(3, "Z");
        Assert.AreEqual("Z", list.ElementAt(3));
        Assert.AreEqual(6, list.Count);
        Assert.AreEqual("c", list.ElementAt(2));
        Assert.AreEqual("d", list.ElementAt(4));

        Assert.Throws<IndexOutOfRangeException>(() => { list.Insert(-1, "a"); });
        Assert.Throws<IndexOutOfRangeException>(() => { list.Insert(7, "a"); });
    }

    [Test]

    public void TestIndexOf()
    {
        Array_List<string> list = new Array_List<string>();
        list.Add("a");
        list.Add("b");
        list.Add("c");
        list.Add("d");
        list.Add("e");
        Assert.AreEqual(0, list.IndexOf("a"));
        Assert.AreEqual(4, list.IndexOf("e"));
        Assert.AreEqual(2, list.IndexOf("c"));
        Assert.Throws<ApplicationException>(() => { list.IndexOf("z"); });
    }

    [Test]
    public void TestRemove()
    {
        Array_List<string> list = new Array_List<string>();
        list.Add("a");
        list.Add("b");
        list.Add("c");
        list.Add("d");
        list.Add("e");
        Assert.IsTrue(list.Remove("c"));
        Assert.AreEqual(4, list.Count);
        Assert.IsFalse(list.Remove("z"));
        Assert.AreEqual(4, list.Count);
    }

    [Test]
    public void TestRemoveAt()
    {
        Array_List<string> list = new Array_List<string>();
        list.Add("a");
        list.Add("b");
        list.Add("c");
        list.Add("d");
        list.Add("e");
        Assert.AreEqual("c", list.RemoveAt(2));
        Assert.AreEqual("b", list.ElementAt(1));
        Assert.AreEqual("d", list.ElementAt(2));
        Assert.AreEqual(4, list.Count);

        Assert.Throws<IndexOutOfRangeException>(() => { list.RemoveAt(-1); });
        Assert.Throws<IndexOutOfRangeException>(() => { list.RemoveAt(7); });
    }


    public class LinkedListTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestAdd()
        {
            Linked_List<int> list = new Linked_List<int>();
            Assert.AreEqual(0, list.Count);
            list.Add(1);
            Assert.AreEqual(1, list.Count);
            list.Add(2);
            Assert.AreEqual(2, list.Count);
            list.Add(3);
            Assert.AreEqual(3, list.Count);
        }

        [Test]
        public void TestElementAt()
        {
            Linked_List<string> list = new Linked_List<string>();
            list.Add("a");
            list.Add("b");
            list.Add("c");
            list.Add("d");
            list.Add("e");
            Assert.AreEqual("a", list.ElementAt(0));
            Assert.AreEqual("c", list.ElementAt(2));
            Assert.AreEqual("e", list.ElementAt(4));
            Assert.Throws<IndexOutOfRangeException>(() => list.ElementAt(5));
            Assert.Throws<IndexOutOfRangeException>(() => list.ElementAt(-1));
        }

        [Test]
        public void TestClear()
        {
            Linked_List<string> list = new Linked_List<string>();
            list.Add("a");
            list.Add("b");
            list.Add("c");
            list.Add("d");
            list.Add("e");
            Assert.AreEqual(5, list.Count);
            list.Clear();
            Assert.AreEqual(0, list.Count);
        }

        [Test]
        public void TestReplaceAt()
        {
            Linked_List<string> list = new Linked_List<string>();
            list.Add("a");
            list.Add("b");
            list.Add("c");
            list.Add("d");
            list.Add("e");
            Assert.AreEqual("c", list.ReplaceAt(2, "z"));
            Assert.AreEqual("z", list.ElementAt(2));
        }

        [Test]

        public void TestInsert()
        {
            Linked_List<string> list = new Linked_List<string>();
            list.Add("a");
            list.Add("b");
            list.Add("c");
            list.Add("d");
            list.Add("e");
            list.Insert(3, "Z");
            Assert.AreEqual("Z", list.ElementAt(3));
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("c", list.ElementAt(2));
            Assert.AreEqual("d", list.ElementAt(4));

            Assert.Throws<IndexOutOfRangeException>(() => { list.Insert(-1, "a"); });
            Assert.Throws<IndexOutOfRangeException>(() => { list.Insert(7, "a"); });
        }

        [Test]

        public void TestIndexOf()
        {
            Linked_List<string> list = new Linked_List<string>();
            list.Add("a");
            list.Add("b");
            list.Add("c");
            list.Add("d");
            list.Add("e");
            Assert.AreEqual(0, list.IndexOf("a"));
            Assert.AreEqual(4, list.IndexOf("e"));
            Assert.AreEqual(2, list.IndexOf("c"));
            Assert.Throws<ApplicationException>(() => { list.IndexOf("z"); });
        }

        [Test]
        public void TestRemove()
        {
            Linked_List<string> list = new Linked_List<string>();
            list.Add("a");
            list.Add("b");
            list.Add("c");
            list.Add("d");
            list.Add("e");
            Assert.IsTrue(list.Remove("c"));
            Assert.AreEqual(4, list.Count);
            Assert.IsFalse(list.Remove("z"));
            Assert.AreEqual(4, list.Count);
        }

        [Test]
        public void TestRemoveAt()
        {
            Linked_List<string> list = new Linked_List<string>();
            list.Add("a");
            list.Add("b");
            list.Add("c");
            list.Add("d");
            list.Add("e");
            Assert.AreEqual("c", list.RemoveAt(2));
            Assert.AreEqual("b", list.ElementAt(1));
            Assert.AreEqual("d", list.ElementAt(2));
            Assert.AreEqual(4, list.Count);

            Assert.Throws<IndexOutOfRangeException>(() => { list.RemoveAt(-1); });
            Assert.Throws<IndexOutOfRangeException>(() => { list.RemoveAt(7); });
        }

    }


 }
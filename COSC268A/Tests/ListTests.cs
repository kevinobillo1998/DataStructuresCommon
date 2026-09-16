using System;
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
        Assert.Throws<IndexOutOfRangeException>(()=>  list.ElementAt(-1));
    }
}
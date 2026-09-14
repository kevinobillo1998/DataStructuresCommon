using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClasses;

namespace TestProjectHello;

internal class TestMySort
{
    [Test]
    public void TestShouldSwap()
    {
        Assert.AreEqual(false, MySort.shouldSwap<string>("a", "z", MySort.SortDirection.Ascending));
        Assert.AreEqual(true, MySort.shouldSwap<string>("a", "z", MySort.SortDirection.Descending));
        Assert.AreEqual(false, MySort.shouldSwap<string>("a", "a", MySort.SortDirection.Descending));
        Assert.AreEqual(false, MySort.shouldSwap<string>("a", "a", MySort.SortDirection.Ascending));
    }

    [Test]
    public void TestSwapItems()
    {
        string[] myStrings = { "a", "b", "c", "d", "e" };
        Assert.AreEqual("a", myStrings[0]);
        Assert.AreEqual("c", myStrings[2]);
        MySort.swapItems<string>(ref myStrings[0], ref myStrings[2]);
        Assert.AreEqual("c", myStrings[0]);
        Assert.AreEqual("a", myStrings[2]);
        MySort.swapItems<string>(ref myStrings[1], ref myStrings[4]);
        Assert.AreEqual("e", myStrings[1]);
        Assert.AreEqual("b", myStrings[4]);
        int[] myInts = { 1, 2, 3, 4, 5 };
        MySort.swapItems<int>(ref myInts[0], ref myInts[2]);
        Assert.AreEqual(3, myInts[0]);
        Assert.AreEqual(1, myInts[2]);
    }

    [Test]
    public void TestBubblesort()
    {
        string[] myStrings = { "b", "a", "f", "e", "z", "c" };
        MySort.BubbleSort<string>(myStrings, MySort.SortDirection.Ascending);
        int i = 0;
        for (int j = 0; j < myStrings.Length; j++)
        {
            Console.WriteLine(myStrings[j]);
        }
        // After sorting the array should be a, b, c, e, f, z
        Assert.AreEqual("a", myStrings[i++]);
        Assert.AreEqual("b", myStrings[i++]);
        Assert.AreEqual("c", myStrings[i++]);
        Assert.AreEqual("e", myStrings[i++]);
        Assert.AreEqual("f", myStrings[i++]);
        Assert.AreEqual("z", myStrings[i++]);
    }

    [Test]
    public void TestSortWithDelegate()
    {
        string[] myStrings = { "b", "a", "f", "e", "z", "c" };
        MySort.Sort<string>(myStrings, MySort.SortDirection.Ascending, MySort.BubbleSort<string>);
        int i = 0;
        // After sorting the array should be a, b, c, e, f, z
        Assert.AreEqual("a", myStrings[i++]);
        Assert.AreEqual("b", myStrings[i++]);
        Assert.AreEqual("c", myStrings[i++]);
        Assert.AreEqual("e", myStrings[i++]);
        Assert.AreEqual("f", myStrings[i++]);
        Assert.AreEqual("z", myStrings[i++]);
    }

    [Test]
    public void TestIsInOrder()
    {
        string[] myStrings = { "a", "f", "m", "z" };
        Assert.IsTrue(MySort.IsInOrder<string>(myStrings, MySort.SortDirection.Ascending));
        int[] myInts = { 5, 7, 3, 3, 99, 2 };
        Assert.IsFalse(MySort.IsInOrder<int>(myInts, MySort.SortDirection.Ascending));

    }

    [Test]
    public void TestSortWithDelegateBozoSort()
    {
        string[] myStrings = { "b", "a", "f", "e", "z", "c" };
        MySort.Sort<string>(myStrings, MySort.SortDirection.Ascending, MySort.BozoSort<string>);
        int i = 0;
        // After sorting the array should be a, b, c, e, f, z
        Assert.AreEqual("a", myStrings[i++]);
        Assert.AreEqual("b", myStrings[i++]);
        Assert.AreEqual("c", myStrings[i++]);
        Assert.AreEqual("e", myStrings[i++]);
        Assert.AreEqual("f", myStrings[i++]);
        Assert.AreEqual("z", myStrings[i++]);
    }
}

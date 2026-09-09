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
        Assert.AreEqual(false, MySort.shouldSwap("a", "z", MySort.SortDirection.Ascending));
        Assert.AreEqual(true, MySort.shouldSwap("a", "z", MySort.SortDirection.Descending));
        Assert.AreEqual(false, MySort.shouldSwap("a", "a", MySort.SortDirection.Descending));
        Assert.AreEqual(false, MySort.shouldSwap("a", "a", MySort.SortDirection.Ascending));
    }

    [Test]
    public void TestSwapItems()
    {
        string[] myStrings = { "a", "b", "c", "d", "e" };
        Assert.AreEqual("a", myStrings[0]);
        Assert.AreEqual("c", myStrings[2]);
        MySort.swapItems(ref myStrings[0], ref myStrings[2]);
        Assert.AreEqual("c", myStrings[0]);
        Assert.AreEqual("a", myStrings[2]);
        MySort.swapItems(ref myStrings[1], ref myStrings[4]);
        Assert.AreEqual("e", myStrings[1]);
        Assert.AreEqual("b", myStrings[4]);
    }

    [Test]
    public void TestBubblesort()
    {
        string[] myStrings = { "b", "a", "f", "e", "z", "c" };
        MySort.Sort(myStrings, MySort.SortDirection.Descending);
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

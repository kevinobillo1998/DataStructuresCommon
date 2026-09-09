namespace TestProjectHello;
using MyClasses;

public class Tests
{
    EchoChamber testChamber;

    [SetUp]
    public void Setup()
    {
        testChamber = new EchoChamber(4);        
    }

    [Test]
    public void TestGetandSetRepeat()
    {
        EchoChamber test = new EchoChamber();
        Assert.AreEqual(3, test.Repeat);
        EchoChamber test5 = new EchoChamber(5);
        Assert.AreEqual(5, test5.Repeat);
        test5.Repeat = 77;
        Assert.AreEqual(77,test5.Repeat);
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            test.Repeat = -5;
        });        
    }

    [Test]
    public void TestEcho()
    {
        Assert.AreEqual("HiHiHiHi", testChamber.Echo("Hi"));
        string testEcho = testChamber.Echo("bye");
        Console.WriteLine("The echo resulted in:");
        Console.WriteLine(testEcho);
    }
}
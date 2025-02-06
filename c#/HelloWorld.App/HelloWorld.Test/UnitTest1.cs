using System;
using HelloWorld.App;

namespace HelloWorld.Test;
public class Tests : Program
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test_Empty()
    {
        Assert.That(Program.Process([]), Is.EqualTo("Got empty input"));
    }

    [Test]
    public void Test_Invalid()
    {
        Assert.That(Program.Process(["-t", "Test", "Test"]), Is.EqualTo("Got non-matching input"));
    }

    [Test]
    public void Test_UpperCase()
    {
        Assert.That(Program.Process(["-u", "Test"]), Is.EqualTo("TEST"));
    }

    [Test]
    public void Test_LowerCase()
    {
        Assert.That(Program.Process(["-l", "TeSt"]), Is.EqualTo("test"));
    }
}

namespace Lexer.Tests;

public class Tests
{
    int variable;
    [SetUp]
    public void Setup()
    {
        variable = 0;
    }

    [TestCase(0)]
    [TestCase(2)]
    [TestCase(3)]
    public void Test1(int value)
    {
        var testing = variable + 3;
        Assert.That(testing, Is.EqualTo(value));
    }
}
using NUnit.Framework;

namespace MarsRover
{
    public class Tests
    {
        MarsRover _rover;
        [SetUp]
        public void Setup()
        {
            _rover = new MarsRover(0,0,'N');
        }


        [TestCase("R", ExpectedResult = "0:0:E")]
        [TestCase("RR", ExpectedResult = "0:0:S")]
        [TestCase("RRR", ExpectedResult = "0:0:W")]
        [TestCase("RRRR", ExpectedResult = "0:0:N")]
        public string TurnRight(string command)
        {
            return _rover.Execute(command);
        }

        [TestCase("L", ExpectedResult = "0:0:W")]
        [TestCase("LL", ExpectedResult = "0:0:S")]
        [TestCase("LLL", ExpectedResult = "0:0:E")]
        [TestCase("LLLL", ExpectedResult = "0:0:N")]
        public string TurnLeft(string command)
        {
            return _rover.Execute(command);
        }

        [TestCase("M", ExpectedResult = "0:1:N")]
        [TestCase("MMM", ExpectedResult = "0:3:N")]
        [TestCase("MMMMMMMMMM", ExpectedResult = "0:0:N")]
        [TestCase("MMMMMMMMMMMMMMM", ExpectedResult = "0:5:N")]
        [TestCase("RM", ExpectedResult = "1:0:E")]
        [TestCase("RMMMMM", ExpectedResult = "5:0:E")]
        [TestCase("LM", ExpectedResult = "9:0:W")]
        [TestCase("LLMMMMM", ExpectedResult = "0:5:S")]
        public string Move(string command)
        {
            return _rover.Execute(command);
        }
    }
}
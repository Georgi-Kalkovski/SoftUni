namespace Computers.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class ComputerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestForPart()
        {
            var part = new Part("Chip", 10);
            Assert.AreEqual("Chip", part.Name);
            Assert.AreEqual(10, part.Price);
        }

        [Test]
        public void Test2()
        {
            var part = new Part("Chip", 10);
            var computer = new Computer("Toshiba");
            Assert.AreEqual("Toshiba", computer.Name);
            Assert.Throws<ArgumentNullException>(() => new Computer(null), "Name cannot be null or empty!");
            Assert.Throws<ArgumentNullException>(() => new Computer(""), "Name cannot be null or empty!");
            Assert.Throws<ArgumentNullException>(() => new Computer(" "), "Name cannot be null or empty!");
        }

        [Test]
        public void Test3()
        {
            var part = new Part("Chip", 10);
            var computer = new Computer("Toshiba");
            Assert.That(computer.Parts.Count == 0);
            computer.AddPart(part);
            Assert.That(computer.Parts.Count == 1);
            Assert.Throws<InvalidOperationException>(() => computer.AddPart(null), "Cannot add null!");
        }
        [Test]
        public void Test4()
        {
            var part = new Part("Chip", 10);
            var part2 = new Part("Chip", 10);
            var computer = new Computer("Toshiba");
            computer.AddPart(part);
            computer.AddPart(part2);
            Assert.AreEqual(20, computer.TotalPrice);
            Assert.That(computer.RemovePart(part));
        }

        [Test]
        public void Test5()
        {
            var part = new Part("Chip", 10);
            var computer = new Computer("Toshiba");
            computer.AddPart(part);
            var checkPart = computer.GetPart("Chip");
            Assert.AreEqual(checkPart, part);
        }
    }
}
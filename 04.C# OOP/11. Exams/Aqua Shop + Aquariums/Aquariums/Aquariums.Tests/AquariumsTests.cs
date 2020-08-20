namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    public class AquariumsTests
    {
        private Aquarium aquarium;

        [Test]
        public void TestCorrectConstruct()
        {
            var fish = new Fish("Peshi");
            var aquarium = new Aquarium("maluk", 1);
            aquarium.Add(fish);
            Assert.That(aquarium.Count == 1);
        }

        [Test]
        public void TestCorrectName()
        {
            var fish = new Fish("Peshi");
            var aquarium = new Aquarium("maluk", 1);
            aquarium.Add(fish);
            Assert.That(aquarium.Name == "maluk");
        }

        [Test]
        [TestCase("", 1)]
        [TestCase(null, 1)]
        public void EmptyOrWhitespacerNameShouldThrowException(string name, int count)
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(name, count), "value (Parameter 'Invalid aquarium name!'");
        }

        [Test]
        public void TestCorrectCapacity()
        {
            var fish = new Fish("Peshi");
            var aquarium = new Aquarium("maluk", 1);
            Assert.That(aquarium.Capacity == 1);
        }

        [Test]
        [TestCase("maluk", -1)]
        public void IsLessThanZeroShouldThrowException(string name, int count)
        {
            Assert.Throws<ArgumentException>(() => new Aquarium(name, count), "Invalid aquarium capacity!");
        }

        [Test]
        public void AssertInCorrectCountThrowsException()
        {
            var fishOne = new Fish("Peshi");
            var fishTwo = new Fish("Goshi");
            var aquarium = new Aquarium("maluk", 1);
            aquarium.Add(fishOne);
            Assert.Throws<InvalidOperationException>(() => aquarium.Add(fishTwo), ($"Fish with the name {fishTwo.Name} doesn't exist!"));
        }

        [Test]
        public void AssertRemoveIsCorrect()
        {
            var fish = new Fish("Peshi");
            var aquarium = new Aquarium("maluk", 1);
            aquarium.Add(fish);
            aquarium.RemoveFish(fish.Name);
        }

        [Test]
        public void AssertRemoveThrowsExceptionWhenFishDoesNotExist()
        {
            var aquarium = new Aquarium("maluk", 1);
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Goshi"), $"Fish with the name {"Goshi"} doesn't exist!");
        }

        [Test]
        public void AssertSellIsCorrect()
        {
            var fish = new Fish("Peshi");
            var aquarium = new Aquarium("maluk", 1);
            aquarium.Add(fish);
            aquarium.SellFish(fish.Name);
        }

        [Test]
        public void AssertSellThrowsExceptionWhenFishDoesNotExist()
        {
            var aquarium = new Aquarium("maluk", 1);
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("Goshi"), $"Fish with the name {"Goshi"} doesn't exist!");
        }

        [Test]
        public void CorrectReportTest()
        {
            var fish = new Fish("Peshi");
            var aquarium = new Aquarium("maluk", 1);
            aquarium.Add(fish);
            Assert.That(aquarium.Report()== $"Fish available at {aquarium.Name}: {fish.Name}");
        }
    }
}

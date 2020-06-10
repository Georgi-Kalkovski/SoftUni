using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void TestForMoto()
        {
            var motorcycle = new UnitMotorcycle("Honda", 100, 150);
            Assert.AreEqual("Honda", motorcycle.Model);
            Assert.AreEqual(100, motorcycle.HorsePower);
            Assert.AreEqual(150, motorcycle.CubicCentimeters);
        }
        [Test]
        public void TestForRider()
        {
            var motorcycle = new UnitMotorcycle("Honda", 100, 150);
            var rider = new UnitRider("Joro", motorcycle);
            Assert.AreEqual("Joro", rider.Name);
            Assert.AreEqual(motorcycle, rider.Motorcycle);
        }

        [Test]
        public void TestForAddingRider()
        {
            var motorcycle = new UnitMotorcycle("Honda", 100, 150);
            var rider = new UnitRider("Joro", motorcycle);
            var race = new RaceEntry();
            Assert.Throws<InvalidOperationException>(() => race.AddRider(null));
            Assert.That(race.Counter == 0);
            race.AddRider(rider);
            Assert.That(race.Counter == 1);
            Assert.Throws<InvalidOperationException>(() => race.AddRider(rider));
            Assert.That(race.Counter == 1);
        }

        [Test]
        public void TestForCalculateAverageHorsePower()
        {
            var motorcycle = new UnitMotorcycle("Honda", 100, 150);
            var rider = new UnitRider("Joro", motorcycle);
            var race = new RaceEntry();
            race.AddRider(rider);
            Assert.Throws<InvalidOperationException>(() => race.CalculateAverageHorsePower());
            race.AddRider(new UnitRider("Magi", motorcycle));
            Assert.AreEqual(100, race.CalculateAverageHorsePower());
        }
    }
}
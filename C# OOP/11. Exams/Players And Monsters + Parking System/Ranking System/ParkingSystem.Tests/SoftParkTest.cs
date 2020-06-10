namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    public class SoftParkTest
    {
        private Car carOne;
        private Car carTwo;
        private SoftPark softPark;

        [SetUp]
        public void Setup()
        {
            carOne = new Car("BMW", "ABC123");
            carTwo = new Car("Citroen", "LOL456");
            softPark = new SoftPark();
        }

        [Test]
        public void A()
        {
            softPark.ParkCar("A1", carOne);
            softPark.ParkCar("A2", carTwo);
            Assert.IsNotNull(softPark.Parking);
        }

        [Test]
        public void B()
        {
            softPark.ParkCar("A1", carOne);
            softPark.ParkCar("A2", carTwo);
            Assert.That(softPark.Parking.TryGetValue("A1", out carOne));
            Assert.That(softPark.Parking.TryGetValue("A2", out carTwo));
        }
        [Test]
        public void C()
        {
            Assert.Throws<ArgumentException>(() => softPark.ParkCar("A5", carOne), "Parking spot doesn't exists!");
        }

        [Test]
        public void D()
        {
            softPark.ParkCar("A1", carOne);
            Assert.Throws<ArgumentException>(() => softPark.ParkCar("A1", carTwo), "Parking spot is already taken!");
        }

        [Test]
        public void E()
        {
            softPark.ParkCar("A1", carOne);
            Assert.Throws<InvalidOperationException>(() => softPark.ParkCar("A2", carOne), "Car is already parked!");
        }

        [Test]
        public void F()
        {
            Assert.Throws<ArgumentException>(() => softPark.RemoveCar("A5", carOne), "Parking spot doesn't exists!");
        }
        [Test]
        public void G()
        {
            Assert.Throws<ArgumentException>(() => softPark.RemoveCar("A1", carOne), "Car for that spot doesn't exists!");
        }
        [Test]
        public void H()
        {
            softPark.ParkCar("A1", carOne);
            softPark.RemoveCar("A1", carOne);
            Assert.That(!softPark.Parking.Values.Contains(carOne));

        }
       // [Test]
        public void I()
        {
            softPark.ParkCar("A1", carOne);
            softPark.ParkCar("A2", carOne);
            Assert.That(softPark.Parking.Count.Equals(1));

        }
    }
}
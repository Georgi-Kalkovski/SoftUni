namespace Presents.Tests
{
    using NUnit.Framework;
    using System;

    public class PresentsTests
    {

        [Test]
        public void TestForCorrectCreate()
        {
            var present = new Present("Train", 10);
            Present incorrectPresent = null;
            Assert.AreEqual("Train", present.Name);
            Assert.AreEqual(10, present.Magic);
            var bag = new Bag();
            bag.Create(present);
            Assert.Throws<ArgumentNullException>(() => bag.Create(incorrectPresent), "Present is null");
            Assert.Throws<InvalidOperationException>(() => bag.Create(present), "This present already exists!");
        }

        [Test]
        public void TestForCorrectRemove()
        {
            var present = new Present("Train", 10);
            var bag = new Bag();
            bag.Create(present);
            Assert.IsTrue(bag.Remove(present));
            bag.Remove(present);
            Assert.IsFalse(bag.Remove(present));
        }

        [Test]
        public void TestForGettingPresentWithLeastMagic()
        {
            var presentWithLess = new Present("Train", 10);
            var presentWithMore = new Present("Plane", 15);
            var bag = new Bag();
            bag.Create(presentWithLess);
            bag.Create(presentWithMore);
            var output = bag.GetPresentWithLeastMagic();
            Assert.AreEqual(presentWithLess, output);
        }

        [Test]
        public void TestForGettingPresent()
        {
            var present = new Present("Train", 10);
            var bag = new Bag();
            bag.Create(present);
            var outputPresent = bag.GetPresent(present.Name);
            Assert.AreEqual(present, outputPresent);
        }

        [Test]
        public void TestForGettingPresents()
        {
            var presentWithLess = new Present("Train", 10);
            var presentWithMore = new Present("Plane", 15);
            var anotherBag = new Bag();
            anotherBag.Create(presentWithLess);
            anotherBag.Create(presentWithMore);
            var bag = new Bag();
            bag.Create(presentWithLess);
            bag.Create(presentWithMore);
            var presents = bag.GetPresents();
            Assert.AreEqual(anotherBag.GetPresents(), presents);
        }
    }
}

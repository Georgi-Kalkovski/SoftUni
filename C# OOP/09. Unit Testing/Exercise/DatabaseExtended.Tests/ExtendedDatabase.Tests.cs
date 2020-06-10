using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace ExtendedDatabase.Tests
{

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private const int DatabaseCapacity = 16;
        private Person pesho;
        private Person gosho;

        [SetUp]
        public void Setup()
        {
            pesho = new Person(11223344, "Pesho");
            gosho = new Person(55667788, "Gosho");
        }

        [Test]
        public void ConstructorExtendedDBShouldInitializeCollection()
        {
            var expected = new Person[] { pesho, gosho };

            var db = new ExtendedDatabase(expected);

            Assert.IsNotNull(db);
        }

        [Test]
        public void TestAddRangeNormalConditions()
        {
            var persons = new Person[] { pesho, gosho };

            var db = new ExtendedDatabase(persons);

            int expectedCount = 2;

            Assert.AreEqual(expectedCount, db.Count);
        }

        [Test]
        public void CanNotUseAddOperatioWhenDatabaseIsFull()
        {
            // Act
            this.AddNumbers(DatabaseCapacity);

            // Assert
            Assert.Throws<InvalidOperationException>(() => this.database.Add(5));
        }

        [Test]
        public void TestShouldAddPerson()
        {
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase(persons);
            var newPerson = new Person(123456789, "Stamat");
            db.Add(newPerson);

            int expectedCount = 3;

            Assert.AreEqual(expectedCount, db.Count);
        }

        [Test]
        public void AddSameUsernameShouldThrow()
        {
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase(persons);
            var newPerson = new Person(11223344, "Gosho");

            Assert.That(() => db.Add(newPerson), Throws.InvalidOperationException);
        }

        [Test]
        public void AddSameIdShouldThrow()
        {
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase(persons);
            var newPerson = new Person(11223344, "Stamat");

            Assert.That(() => db.Add(newPerson), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveShouldRemove()
        {
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase(persons);
            db.Remove();

            var expectedCount = 1;

            Assert.AreEqual(expectedCount, db.Count);
        }

        [Test]
        public void RemoveEmptyCollectionShouldThrow()
        {
            var persons = new Person[] { };
            var db = new ExtendedDatabase(persons);

            Assert.That(() => db.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsernameExistingPersonShouldReturnPerson()
        {
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase(persons);

            var expected = pesho;
            var actual = db.FindByUsername("Pesho");

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void FindByUsernameNonExistingPersonShouldThrow()
        {
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase(persons);

            Assert.That(() => db.FindByUsername("Stamat"), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsernameNullArgumentShouldThrow()
        {
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase(persons);

            Assert.That(() => db.FindByUsername(null), Throws.ArgumentNullException);
        }
        [Test]
        public void FindByUsernameIsCaseSensitive()
        {
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase(persons);

            Assert.That(() => db.FindByUsername("GOSHO"), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByIdExistingPersonShouldReturnPerson()
        {
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase(persons);

            var expected = pesho;
            var actual = db.FindById(11223344);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void FindByIdNonExistingPersonShouldThrow()
        {
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase(persons);

            Assert.That(() => db.FindById(123456789), Throws.InvalidOperationException);
        }
        
        [Test]
        public void FindByUsernameNegativeArgumentShouldThrow()
        {
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase(persons);

            Assert.That(() => db.FindById(-5), Throws.Exception);
        }
    }
}
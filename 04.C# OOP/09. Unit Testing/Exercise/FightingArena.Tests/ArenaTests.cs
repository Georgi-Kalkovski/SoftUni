using NUnit.Framework;
using FightingArena;
using System;

namespace Tests
{
    public class ArenaTests
    {
        Warrior firstWarr;    // we have first warrior
        Warrior secondWarr;   // we have second warrior
        Arena theArena;       // we have arena where warriors fight

        [SetUp] // place to SetUp the warriors and the arena
        public void Setup()
        {
            firstWarr = new Warrior("Koko", 20, 100); // we have first war with correct given stats
            secondWarr = new Warrior("Poly", 25, 75); // we have second war with correct given stats
            theArena = new Arena(); // we have new arena
        }

        [Test] // Test for correct count
        public void ArenaMethodEnrollShouldReturnCorrectCount()
        {
            theArena.Enroll(firstWarr); // first warrior enters the arena
            theArena.Enroll(secondWarr); // second warrior enters the arena
            Assert.AreEqual(2, theArena.Warriors.Count); // make sure the warriors on the arena are two
            Assert.AreEqual(2, theArena.Count); // make sure the arena knows there are two warriors on it
        }

        [Test] // Test if more warrior with same name exists
        public void ArenaMethodEnrollShouldThrowInvalidOperationExceptionIfYouTryToEnrollWarriorWithAlreadyExistingName()
        {
            theArena.Enroll(firstWarr); // first warr
            theArena.Enroll(secondWarr); // second warr
            var thirdWarr = new Warrior("Poly", 200, 500); // third warr with same name as existing one
            Assert.Throws<InvalidOperationException>(() => theArena.Enroll(thirdWarr)); // throw exception if same names occur
        }

        [Test] // Test if warrior exists in the list for the fight
        [TestCase("InvalidName", "Koko")] // invalid first warrior with vailid second warrior
        [TestCase("Poly", "Django")]      //valid first warrior with invalid second warrior
        public void ArenaMethodFightShouldThrowInvalidOperationExceptionIfGivenWarriorNameDoesntExist(string attackerName, string defenderName)
        {
            theArena.Enroll(firstWarr);    // pick the first warrior
            theArena.Enroll(secondWarr);   // pick the second warrior
            Assert.Throws<InvalidOperationException>(() => theArena.Fight(attackerName, defenderName));    // throw exception if warriors aren't existing in list
            Assert.Throws<InvalidOperationException>(() => theArena.Fight(attackerName, defenderName));    // throw exception if warriors aren't existing in list
        }

        [Test] // Test for correct fight 
        public void ArenaMethodFightShouldWorkCorrectly()
        {
            theArena.Enroll(firstWarr);            // pick first warrior
            theArena.Enroll(secondWarr);           // pick second warrior
            theArena.Fight("Koko", "Poly");        // pick correct names for the fight
            Assert.AreEqual(75, firstWarr.HP);     // fighter have correct hp
            Assert.AreEqual(55, secondWarr.HP);    // fighter have correct hp
        }
    }
}

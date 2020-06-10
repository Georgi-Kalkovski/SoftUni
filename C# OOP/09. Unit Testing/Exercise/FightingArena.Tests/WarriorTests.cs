using NUnit.Framework;
using FightingArena;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test] // Test for incorrect warrior
        [TestCase(null, 15, 100)]          // ifWarriorHasNullName
        [TestCase("", 15,100)]             // ifWarriorHasEmptyName
        [TestCase(" ", 15,100)]            // ifWarriorHasWhitespaceName
        [TestCase("Skelet", 0, 100)]       // ifWarriorHasZeroAttack
        [TestCase("Skelet", -10, 100)]     // ifWarriorHasNegativeAttack
        [TestCase("Skelet", 15, -15)]      // ifWarriorHasNegativeHP
        
        public void IfConstrucorRecieveInvalidNameDamageOrHPItShouldThrowsArgumentException(string name, int damage, int hp) 
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp)); // Throw exception if above stats are given
        }

        [Test]  // Test for correct warrior
        public void ConstructorShouldWokrNormallyWithValidParameters()
        {
            var warr = new Warrior("Nikolay", 15, 100);   // example of a warrior
            Assert.AreEqual("Nikolay", warr.Name);        // isNameString?
            Assert.AreEqual(15, warr.Damage);             // isDamageInt?
            Assert.AreEqual(100, warr.HP);                // isHPInt?
        }

        [Test] // Test for incorrect fights
        [TestCase("Nikolay", 50, 100, "SecondWarr", 18, 49)]   // weak attack from enemy
        [TestCase("Nikolay", 12, 100, "SecondWarr", 18, 30)]   // enemy with strong attack but not enough hp to fight
        [TestCase("Nikolay", 12, 100, "SecondWarr", 18, 20)]   // enemy with strong attack but not enough hp to fight
        [TestCase("Nikolay", 12, 30, "SecondWarr", 20, 55)]    // enemy with strong attack but you dont have enough hp
        [TestCase("Nikolay", 12, 11, "SecondWarr", 20, 55)]    // enemy with strong attack but you dont have enough hp
        public void WarriorMethodAttackShouldThrowInvalidOperationExceptionIfYouTryToAttackStrongerEnemy
            (string firstWarrName, int firstWarrDamage, int firstWarrHP,          // attacked warrior
            string secondWarrName, int secondWarrDamage, int secondWarrHp)        // attacking warrior
        {
            var parameterWarr = new Warrior(firstWarrName, firstWarrDamage, firstWarrHP);   // attacked warrior
            var callerWarr = new Warrior(secondWarrName, secondWarrDamage, secondWarrHp);   // attacking warrior
            Assert.Throws<InvalidOperationException>(() => callerWarr.Attack(parameterWarr));  // throw exception if above stats are given
        }

        [Test]  // Test for correct HP loss
        public void WarriorMethodAttackShouldWorkCorrectly()
        {
            var stronger = new Warrior("Nikolay", 20, 100);     // stronger attacking warrior 
            var weaker = new Warrior("Peshkata", 20, 100);      // weaker attacked warrior
            var expectedHp = 80; // expected HP after the damage (100 HP - 20 DMG == 80 HP)
            weaker.Attack(stronger);  // attacking
            Assert.AreEqual(expectedHp, weaker.HP);  // make sure expected HP is equal with the HP after the attack
        }

        [Test] // Test for correct damage stats
        public void WarriorMethodAttackShouldWorkCorrectlyIfDamageIsMoreThanHealth()
        {
            var stronger = new Warrior("Nikolay", 50, 100); // stronger warrior
            var weaker = new Warrior("Peshkata", 20, 83); // weaker warrior
            stronger.Attack(weaker); // attack
            Assert.AreEqual(80, stronger.HP); // stronger loses 20 hp -> 80 hp left
            Assert.AreEqual(33, weaker.HP); // weaker loses 50 hp -> 33 hp left
            stronger.Attack(weaker); // attack
            Assert.AreEqual(60, stronger.HP); // stronger loses 20 hp -> 60 hp left
            Assert.AreEqual(0, weaker.HP); // weaker loses all his hp -> 0 hp left
        }
    }
}
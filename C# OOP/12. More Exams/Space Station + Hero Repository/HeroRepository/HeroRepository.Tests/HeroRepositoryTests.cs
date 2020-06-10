using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [Test]
    public void TestForCorrectName()
    {
        var hero = new Hero("Joro", 80);
        Assert.AreEqual("Joro", hero.Name);
        Assert.AreEqual(80, hero.Level);
    }

    [Test]
    public void TestForCorrectCreate()
    {
        var hero = new Hero("Joro", 80);
        var data = new HeroRepository();
        Assert.Throws<ArgumentNullException>(() => data.Create(null), "Hero is null");
        data.Create(hero);
        Assert.Throws<InvalidOperationException>(() => data.Create(hero), $"Hero with name {hero.Name} already exists");
    }

    [Test]
    public void TestForCorrectRemove()
    {
        var hero = new Hero("Joro", 80);
        var data = new HeroRepository();
        data.Create(hero);
        Assert.Throws<ArgumentNullException>(() => data.Remove(null), "Name cannot be null");
        data.Remove(hero.Name);
    }

    [Test]
    public void TestForCorrectGetHeroWithHighestLevel()
    {
        var hero = new Hero("Joro", 80);
        var heroAgain = new Hero("Magi", 90);
        var data = new HeroRepository();
        data.Create(hero);
        data.Create(heroAgain);
        var answer = data.GetHeroWithHighestLevel();
        Assert.AreEqual(90, answer.Level);
    }

    [Test]
    public void TestForCorrectGetHero()
    {
        var hero = new Hero("Joro", 80);
        var data = new HeroRepository();
        data.Create(hero);
        var answer = data.GetHero(hero.Name);
        Assert.AreEqual("Joro", answer.Name);
    }

    [Test]
    public void TestForCorrectIReadOnlyCollection()
    {
        var hero = new Hero("Joro", 80);
        var data = new HeroRepository();
        data.Create(hero);
        Assert.AreEqual(hero.Name, data.Heroes.FirstOrDefault().Name);
    }
}
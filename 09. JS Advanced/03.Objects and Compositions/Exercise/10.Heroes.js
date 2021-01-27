function solve() {

    let thisFighter;
    let thisMage;

    function mage(name) {
        thisMage.name = name;
        thisMage.health = 100;
        thisMage.mana = 100;
    }

    function cast(spell) {
        thisMage.mana--;
        console.log(`${thisMage.name} cast ${spell}`);
    }

    function fighter(name) {
        thisFighter.name = name;
        thisFighter.name;
        thisFighter.health = 100;
        thisFighter.stamina = 100;

    }

    function fight() {
        thisFighter.stamina--;
        console.log(`${thisFighter.name} slashes at the foe!`);
    }
    return {
        mage,
        fighter,
        cast,
        fight,
    }
}

let create = solve();
const scorcher = create.mage("Scorcher");
scorcher.cast("fireball")
scorcher.cast("thunder")
scorcher.cast("light")

const scorcher2 = create.fighter("Scorcher 2");
scorcher2.fight()

console.log(scorcher2.stamina);
console.log(scorcher.mana);

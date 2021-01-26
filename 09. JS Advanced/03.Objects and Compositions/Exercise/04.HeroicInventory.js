function HeroicInventory(input) {

    let result = [];

    for (let i = 0; i < input.length; i++) {
        let current = input[i].split(' / ');
        let obj = {};
        obj.name = current[0];
        obj.level = Number(current[1]);
        if (current[2] != null) {
            obj.items = current[2].split(', ');
        }
        else{
            obj.items = [];
        }
        result[i] = obj;
    }

    result = JSON.stringify(result);

    return result;
}

console.log(HeroicInventory(
    ['Isacc / 25 / Apple, GravityGun',
        'Derek / 12 / BarrelVest, DestructionSword',
        'Hes / 1 / Desolator, Sentinel, Antara']
));
console.log(HeroicInventory(['Jake / 1000 / Gauss, HolidayGrenade']));
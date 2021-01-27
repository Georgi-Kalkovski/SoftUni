function StoreCatalogue(input) {

    let arr = input.sort();
    let result = [];

    for (let row of arr) {
        if (!result.includes(row.charAt(0))) {
            result.push(row.charAt(0));
        }
        result.push(`  ${row.replace(' : ', ': ')}`);
    }

    return result.join('\n');
}

console.log(StoreCatalogue(
    ['Appricot : 20.4',
        'Fridge : 1500',
        'TV : 1499',
        'Deodorant : 10',
        'Boiler : 300',
        'Apple : 1.25',
        'Anti-Bug Spray : 15',
        'T-Shirt : 10']
));
console.log(StoreCatalogue(
    ['Banana : 2',
        'Rubic\'s Cube : 5',
        'Raspberry P : 4999',
        'Rolex : 100000',
        'Rollon : 10',
        'Rali Car : 2000000',
        'Pesho : 0.000001',
        'Barrel : 10']
));

function LowestPrices(input) {

    let arr = [];

    for (let i = 0; i < input.length; i++) {
        let current = input[i].split(' | ');
        if (arr.includes(current[0] && arr.includes(current[1]))) {
        } else {
            arr.push(current);
        }
    }



    let result = [];
    for (const key of arr) {
        result.push(
            console.log(`${key[1]} -> ${key[2]} (${key[0]})`));
    }

    return result;
}

LowestPrices(
    ['Sample Town | Sample Product | 1000',
        'Sample Town | Orange | 2',
        'Sample Town | Peach | 1',
        'Sofia | Orange | 3',
        'Sofia | Peach | 2',
        'New York | Sample Product | 1000.1',
        'New York | Burger | 10']
);
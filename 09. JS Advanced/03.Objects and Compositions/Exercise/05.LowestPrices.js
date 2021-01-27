function LowestPrices(input) {

    let obj = {};

    for (const element of input) {
        let current = element.split(' | ');
        const [town, product, price] = current;

        if (obj.hasOwnProperty(product)) {
            if (obj[product][0] > Number(price)) {
                obj[product][0] = price;
                obj[product][1] = town;
            }
            if (obj[product][1] === town) {
                obj[product][0] = price;
            }
        } else {
            obj[product] = [Number(price), town];
        }
    }

    let output = Object.entries(obj);

    for (let i = 0; i < output.length; i++) {
        console.log(`${output[i][0]} -> ${output[i][1][0]} (${output[i][1][1]})`)
    }
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
LowestPrices(
    ['Sofia City | Audi | 100000',
        'Sofia City | BMW | 100000',
        'Sofia City | Mitsubishi | 10000',
        'Sofia City | Mercedes | 10000',
        'Sofia City | NoOffenseToCarLovers | 0',
        'Mexico City | Audi | 1000',
        'Mexico City | BMW | 99999',
        'New York City | Mitsubishi | 10000',
        'New York City | Mitsubishi | 1000',
        'Mexico City | Audi | 100000',
        'Washington City | Mercedes | 1000']);
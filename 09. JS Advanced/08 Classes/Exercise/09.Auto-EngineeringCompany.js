function AutoEngineeringCompany(inputArr) {

    let cars = {}

    for (const info of inputArr) {
        const token = info.split(' | ');
        const brand = token[0];
        const model = token[1];
        const produced = Number(token[2]);

        if (!cars[brand]) {
            cars[brand] = [{ model: model, produced: produced }];
        } else {
            if (cars[brand].some(c => c.model === model)) {
                let car = cars[brand].find(c => c.model === model);

                car.produced += produced;
            } else {
                cars[brand].push({ model: model, produced: produced })
            }
        }
    }

    let result = '';
    for (const [key, value] of Object.entries(cars)) {
        result += `${key}\n`;
        for (const car of value) {
            result += `###${car.model} -> ${car.produced}\n`
        }
    }
    return result;
}

console.log(AutoEngineeringCompany(
    ['Audi | Q7 | 1000',
        'Audi | Q6 | 100',
        'BMW | X5 | 1000',
        'BMW | X6 | 100',
        'Citroen | C4 | 123',
        'Volga | GAZ-24 | 1000000',
        'Lada | Niva | 1000000',
        'Lada | Jigula | 1000000',
        'Citroen | C4 | 22',
        'Citroen | C5 | 10']));
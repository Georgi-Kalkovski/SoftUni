function AutoEngineeringCompany(inputArr) {

    let cars = {};
    for (let line of inputArr) {
        let [brand, model, qty] = line.split(' | ')
        qty = Number(qty)
        if (!cars[brand]) {
            cars[brand] = {}
        }
        if (!cars[brand][model]) {
            cars[brand][model] = 0
        }
        cars[brand][model] += qty
    }
    
    let result = '';
    for (let key in cars) {
        result += `${key}\n`
        for (let mod in cars[key]) {
            result += `###${mod} -> ${cars[key][mod]}\n`;
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
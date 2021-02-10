function JuiceFlavours(inputJuices) {
    let juices = {};
    let bottles = {};

    inputJuices.forEach(el => {
        let [name, qty] = el.split(' => ');

        if (!juices[name]) {
            juices[name] = Number(qty);
        } else {
            juices[name] += Number(qty);
        }

        while (juices[name] >= 1000) {
            juices[name] -= 1000
            if (!bottles[name]) {
                bottles[name] = 1;
            } else {
                bottles[name] += 1;
            }

        }
    });

    let result = '';
    for (const key of Object.entries(bottles)) {
        result += `${key} => ${value}\n`;
    }
    return result;
}

console.log(JuiceFlavours(
    ['Orange => 2000',
        'Peach => 1432',
        'Banana => 450',
        'Peach => 600',
        'Strawberry => 549']));

console.log(JuiceFlavours(
    ['Kiwi => 234',
        'Pear => 2345',
        'Watermelon => 3456',
        'Kiwi => 4567',
        'Pear => 5678',
        'Watermelon => 6789']));

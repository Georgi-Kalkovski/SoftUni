function Fruit(fruit, weight, money) {

    let trueWeigth = (weight / 1000);

    console.log(`I need $${(trueWeigth * money).toFixed(2)} to buy ${trueWeigth.toFixed(2)} kilograms ${fruit}.`);
}

Fruit('orange', 2500, 1.80);
Fruit('apple', 1563, 2.35);
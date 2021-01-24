function CalorieObject(arr) {
    let element = {};

    for (let i = 0; i < arr.length - 1; i+=2) {
            element.name.grams = arr[i];
            element.grams = arr[i + 1] * 100;
    }

    return element;
}

console.log(CalorieObject(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']));
console.log(CalorieObject(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']));
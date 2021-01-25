function CalorieObject(arr) {
    let element = {};

    for (let i = 0; i < arr.length; i+=2) {
            element[arr[i]] = Number(arr[i + 1]);
    }

    return element;
}

console.log(CalorieObject(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']));
console.log(CalorieObject(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']));
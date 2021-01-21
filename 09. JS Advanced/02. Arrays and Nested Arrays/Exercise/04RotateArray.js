function RotateArray(arr, rotation) {
    let myArr = arr;

    for (let i = 0; i < rotation; i++) {
        let lastElement = myArr.pop();
        myArr.unshift(lastElement);
    }

    return myArr.join(' ');
}

console.log(RotateArray(['1', '2', '3', '4'],
    2
));
console.log(RotateArray(['Banana', 'Orange', 'Coconut', 'Apple'],
    15
));
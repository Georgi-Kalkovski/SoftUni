function NegativePositiveNumbers(arr) {

    let positive = arr.filter(x => x >= 0);
    let negative = arr.filter(x => x < 0);

    let myArr = (negative.reverse() + ',' + positive)
    .split(',').join('\n');

    return myArr;
}

console.log(NegativePositiveNumbers([7, -2, 8, 9]));
console.log(NegativePositiveNumbers([3, -2, 0, -1]));
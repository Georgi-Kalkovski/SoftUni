function OddPositions(arr) {

    let result = '';

    for (let i = arr.length; i > 0; i--) {
        if (i % 2 != 0) {
            result += Number(arr[i] * 2) + ' ';
        }
    }

    return result;
}

console.log(OddPositions([10, 15, 20, 25]));
console.log(OddPositions([3, 0, 10, 4, 7, 3]));

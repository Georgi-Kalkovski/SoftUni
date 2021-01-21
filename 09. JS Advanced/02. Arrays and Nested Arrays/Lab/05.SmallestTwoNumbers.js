function BiggerHalf(arr) {

let myArr = arr.sort(function sortNums(a, b){return a - b;});

    return myArr[0] + ' ' + myArr[1];
}

console.log(BiggerHalf([30, 15, 50, 5]));
console.log(BiggerHalf([3, 0, 10, 4, 7, 3]));

function BiggerHalf(arr) {

    let myArr = arr.sort(function sortNums(a, b) { return a - b; });
    let newArr = [];
    if (myArr % 2 == 0) {
        for (let i = myArr.length / 2; i < myArr.length; i++) {
            newArr += myArr[i];
        }
    } else {
        for (let i = Math.floor(myArr.length / 2); i < myArr.length; i++) {
            newArr += myArr[i];
        }
    }

    return newArr;
}

console.log(BiggerHalf([4, 7, 2, 5]));
console.log(BiggerHalf([3, 19, 14, 7, 2, 19, 6]));

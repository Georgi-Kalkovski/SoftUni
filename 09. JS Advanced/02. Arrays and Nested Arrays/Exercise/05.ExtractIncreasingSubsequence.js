function ExtractIncreasingSubsequence(arr) {

    let myArr = [arr[0]];
    let currentHighestNum = arr[0];

    for (let i = 1; i < arr.length; i++) {
        if (currentHighestNum <= arr[i]) {
            currentHighestNum = arr[i];
            myArr.push(arr[i]);
        }
    }
    return myArr;
}

console.log(ExtractIncreasingSubsequence([1, 3, 8, 4, 10, 12, 3, 2, 24]));
console.log(ExtractIncreasingSubsequence([1, 2, 3, 4]));
console.log(ExtractIncreasingSubsequence([20, 3, 2, 15, 6, 1]));
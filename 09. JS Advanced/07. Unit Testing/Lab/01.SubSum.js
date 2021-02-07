function SubSum(arr, startIndex, endIndex) {
    if (startIndex < 0) {
        startIndex = 0;
    }
    if (endIndex > arr.length - 1) {
        endIndex = arr.length - 1;
    }
    if (!Array.isArray(arr)) {
        return NaN;
    }
    return arr
        .slice(startIndex, endIndex + 1)
        .map(Number)
        .reduce((acc, x) => acc + x, 0)
}

console.log(SubSum([10, 20, 30, 40, 50, 60], 3, 300));
console.log(SubSum([1.1, 2.2, 3.3, 4.4, 5.5], -3, 1));
console.log(SubSum([10, 'twenty', 30, 40], 0, 2));
console.log(SubSum([], 1, 2));
console.log(SubSum('text', 0, 2));
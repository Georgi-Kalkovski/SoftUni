function BiggestElement(arrs) {

    let biggestNumber = Number.MIN_SAFE_INTEGER;
    let arr = [];

    for (let i = 0; i < arrs.length; i++) {
        arr = arrs[i];
        
        for (let j = 0; j < arr.length; j++) {
            if (biggestNumber < Number(arr[j])) {
                biggestNumber = Number(arr[j]);
            }
        }
    }
    return biggestNumber;
}

console.log(BiggestElement(
    [[20, 50, 10],
    [8, 33, 145]]
));
console.log(BiggestElement(
    [[20, 50, 10],
    [8, 33, 145]]
));
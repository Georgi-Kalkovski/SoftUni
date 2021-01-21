function SortingNumbers(arr) {

    arr = arr.sort((a, b) => a - b);
    let myArr = [];
    let itterations = arr.length / 2;
    
    for (let i = 0; i < itterations; i++) {
        myArr.push(arr.shift())
        myArr.push(arr.pop());
    }

    return myArr;
}

console.log(SortingNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));
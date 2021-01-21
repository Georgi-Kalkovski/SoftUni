function ArrayWithGivenDelimiter(arr, symbol) {

    let myArr = arr[0];
    
    for (let i = 1; i < arr.length; i++) {
        myArr += symbol + arr[i];
    }

    return myArr;
}

console.log(ArrayWithGivenDelimiter(
    ['One', 'Two', 'Three', 'Four', 'Five'],
    '-'
));
console.log(ArrayWithGivenDelimiter(
    ['How about no?', 'I', 'will', 'not', 'do', 'it!'],
    '_'
));
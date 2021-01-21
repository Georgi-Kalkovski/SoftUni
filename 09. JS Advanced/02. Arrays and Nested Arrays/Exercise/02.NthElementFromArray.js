function NthElementFromArray(arr, num) {

    let myArr = [];

    for (let i = 0; i < arr.length; i += num) {
        myArr.push(arr[i]);
    }

    return myArr;
}


console.log(NthElementFromArray(
    ['5', '20', '31', '4', '20'],
    2
));
console.log(NthElementFromArray(
    ['dsa', 'asd', 'test', 'tset'],
    2
));
console.log(NthElementFromArray(
    ['1', '2', '3', '4', '5'],
    6
)); 
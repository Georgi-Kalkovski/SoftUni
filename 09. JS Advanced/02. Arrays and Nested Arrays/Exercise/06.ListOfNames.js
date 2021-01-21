function ListOfNames(arr) {

    arr = arr.sort((a, b) => a.localeCompare(b));
    let myArr = '';

    for (i = 0; i < arr.length; i++) {
        myArr += (i + 1) + '.' + arr[i] + '\n';
    }
    return myArr.trimEnd();
}

console.log(ListOfNames(["John", "Bob", "Christina", "Ema"]));
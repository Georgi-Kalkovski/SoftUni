function ListOfNames(arr) {

    let result = arr
        .slice(0)
        .sort((a, b) => a.localeCompare(b))
        .map((name, index, initialArr) => {
            let result = `${index + 1}.${name}`;
            return result;
        });
    return result.join('\n');
    // arr = arr.sort((a, b) => a.localeCompare(b));
    // let myArr = '';
    // 
    // for (i = 0; i < arr.length; i++) {
    //     myArr += (i + 1) + '.' + arr[i] + '\n';
    // }
    // return myArr.trimEnd();
}

console.log(ListOfNames(["John", "Bob", "Christina", "Ema"]));
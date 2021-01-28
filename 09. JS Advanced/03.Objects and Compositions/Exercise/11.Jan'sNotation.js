function JansNotations(arr) {
    let number1 = 0;
    let number2 = 0;
    let operator = '';

    while (arr.length != 1) {
        for (const element of arr) {
            let index = arr.findIndex(element, 1);
            if (Number(element)) {
                number1 = Number(element);
                continue;
            }
            arr.splice(index);
            break;
        }
        for (const element of arr) {
            if (element === Number) {
                number2 = Number(element)
            }
            else if (element === String) {
                if (element == '+') { number1 + number2 }
                else if (element == '-') number1 - number2
            }
            else if (element == '/') { number1 / number2 }
            else if (element == '*') { number1 * number2 }
        }
    }
    return arr;
}

//console.log(JansNotations([3, 4, '+']));
console.log(JansNotations([5, 3, 4, '*', '-']));
console.log(JansNotations([7, 33, 8, '-']));
console.log(JansNotations([15, '/']));
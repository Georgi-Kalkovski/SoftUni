function SameNumbers(input) {

    let arr = String(input).split('');
    let firstDigit = input % 10;
    let sum =0;
    let isTrue = true;

    for(let i = 0;i < arr.length; i++) {
        sum += +arr[i];

        if (arr[i] != firstDigit){
            isTrue = false;
        }
    }

    console.log(isTrue);
    console.log(sum);
}

SameNumbers(2222222);
SameNumbers(1234);

// function solve(number) {
//     const string = number.ToString();
//     let isSame = true;
//     let sum = 0;
//     
//     for (let i = 0; i < string.length; i++) {
//         let current = Number(string[i]);
//         let next = string[i + 1];
//         if (string[i] !== string[i + 1] && next !== undefined){
//             isSame = false;
//         }
//         
//         sum += current;
//     }
//     
//     return `${isSame}\n${sum}`;
// }
// 
// console.log(solve(2222222));
// console.log(solve(1234));

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
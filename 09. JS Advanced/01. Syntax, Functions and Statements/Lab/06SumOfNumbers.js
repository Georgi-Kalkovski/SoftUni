function SumOfNumbers(num1, num2) {

    let result = 0;

    for (let i = Number(num1); i <= Number(num2); i++) {
        result += i;
    }

    console.log(result);
}

SumOfNumbers('1', '5');
SumOfNumbers('-8', '20');
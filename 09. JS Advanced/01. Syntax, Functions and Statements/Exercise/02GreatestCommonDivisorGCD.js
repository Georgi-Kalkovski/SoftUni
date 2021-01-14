function GCD(num1, num2) {

    num1 = Math.abs(num1);
    num2 = Math.abs(num2);

    let gcd;

    while (num2) {
        gcd = num2;
        num2 = num1 % num2;
    }

    console.log(gcd)
}

GCD(15, 5);
GCD(2154, 458);
function LargestNumber(a, b, c) {
    let input;
    if (a > b && a > c) { input = a; }
    else if (b > a && b > c) { input = b; }
    else { input = c; }
    console.log(`The largest number is ${input}.`);
}

LargestNumber(5, -3, 16);
LargestNumber(-3, -5, -22.5);
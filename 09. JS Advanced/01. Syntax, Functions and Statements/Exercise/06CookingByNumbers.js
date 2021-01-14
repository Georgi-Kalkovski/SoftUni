function CookingByNumbers(input, input1, input2, input3, input4, input5) {

    let number = Number(input);
    switch (input1) {
        case 'chop': number /= 2; break;
        case 'dice': number = Math.sqrt(number); break;
        case 'spice': number += 1; break;
        case 'bake': number *= 3; break;
        case 'fillet': number = number - (number * 0.20); break;
    }
    console.log(number);

    switch (input2) {
        case 'chop': number /= 2; break;
        case 'dice': number = Math.sqrt(number); break;
        case 'spice': number += 1; break;
        case 'bake': number *= 3; break;
        case 'fillet': number = number - (number * 0.20); break;
    }
    console.log(number);

    switch (input3) {
        case 'chop': number /= 2; break;
        case 'dice': number = Math.sqrt(number); break;
        case 'spice': number += 1; break;
        case 'bake': number *= 3; break;
        case 'fillet': number = number - (number * 0.20); break;
    }
    console.log(number);

    switch (input4) {
        case 'chop': number /= 2; break;
        case 'dice': number = Math.sqrt(number); break;
        case 'spice': number += 1; break;
        case 'bake': number *= 3; break;
        case 'fillet': number = number - (number * 0.20); break;
    }
    console.log(number);

    switch (input5) {
        case 'chop': number /= 2; break;
        case 'dice': number = Math.sqrt(number); break;
        case 'spice': number += 1; break;
        case 'bake': number *= 3; break;
        case 'fillet': number = number - (number * 0.20); break;
    }
    console.log(number);
}

CookingByNumbers('32', 'chop', 'chop', 'chop', 'chop', 'chop');
CookingByNumbers('9', 'dice', 'spice', 'chop', 'bake', 'fillet');
function CircleArea(input) {

    if (typeof (input) == 'number') {
        console.log((Math.PI * input * input).toFixed(2));
    }

    else {
        console.log(`We can not calculate the circle area, because we receive a ${typeof (input)}.`);
    }
}

CircleArea(5);
CircleArea('name');
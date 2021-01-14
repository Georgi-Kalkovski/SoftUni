function SquareOfStars(input) {

    if (typeof (input) == "number") {
        for (let i = 0; i < input; i++) {
            console.log('* '.repeat(input))
        }
    }

    else {
        for (let i = 0; i < 5; i++) {
            console.log('* '.repeat(5))
        }
    }
}

SquareOfStars(1);
SquareOfStars(2);
SquareOfStars(5);
SquareOfStars();
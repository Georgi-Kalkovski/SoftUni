function CarFactory(car) {

    function getEngine(power) {

        let engines;
        if (power <= 90) {
            engines = { power: 90, volume: 1800 };
        }
        else if (power <= 120) {
            engines = { power: 120, volume: 2400 };
        } else {
            engines = { power: 200, volume: 3500 };
        }

        return engines;
    };

    function getCarriage(carriage, color) {
        return {
            type: carriage,
            color
        }
    };

    function getWheels(wheelsize) {
        let wheels;
        if (Math.floor(wheelsize) % 2 == 0) {
            wheels = Math.floor(wheelsize) - 1;
        } else {
            wheels = Math.floor(wheelsize);
        }

        return [wheels, wheels, wheels, wheels];
    };

    return {
        model: car.model,
        engine: getEngine(car.power),
        carriage: getCarriage(car.carriage, car.color),
        wheels: getWheels(car.wheelsize)
    };
}

console.log(CarFactory({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}
));
console.log(CarFactory({
    model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17
}
));
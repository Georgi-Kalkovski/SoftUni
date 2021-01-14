function RoadRadar(speed, area) {

    let speedLimit;
    let isTrue = false;

    switch (area) {
        case 'motorway':
            speedLimit = 130; if (speed <= 130) { isTrue = true } break;
        case 'interstate':
            speedLimit = 90; if (speed <= 90) { isTrue = true } break;
        case 'city':
            speedLimit = 50; if (speed <= 50) { isTrue = true } break;
        case 'residential':
            speedLimit = 20; if (speed <= 20) { isTrue = true } break;
    }

    if (isTrue) {
        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
    }

    else {
        let difference = speed - speedLimit;
        let status;

        if (difference <= 20) {status = 'speeding';}
        else if (difference <= 40) {status = 'excessive speeding';}
        else {status = 'reckless driving';}

        console.log(`The speed is ${difference} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
    }
}

RoadRadar(40, 'city');
RoadRadar(21, 'residential');
RoadRadar(120, 'interstate');
RoadRadar(200, 'motorway');
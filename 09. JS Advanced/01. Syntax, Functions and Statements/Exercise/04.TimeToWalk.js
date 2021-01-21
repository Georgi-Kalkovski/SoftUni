function TimeToWalk(steps, footprint, speed) {

    let rest = Math.floor((steps * footprint) / 500);
    let distance = steps * footprint;
    let time = distance / speed / 1000 * 60;
    let timeInSeconds = Math.ceil((rest + time) * 60);
    let output = new Date(null, null, null, null , null, timeInSeconds);

    console.log(output.toTimeString().split(' ')[0]);
}

TimeToWalk(4000, 0.60, 5);
TimeToWalk(2564, 0.70, 5.5);
function AssemblyLine() {
    const result = {
        hasClima: (car) => {
            car.temp = 21;
            car.tempSettings = 21;
            car.adjustTemp = () => {
                if (car.temp < car.tempSettings) { car.temp++; }
                if (car.temp > car.tempSettings) { car.temp--; }
            };
        },
        hasAudio: (car) => {
            car.currentTrack = {
                name: null,
                artist: null,
            }
            car.nowPlaying = () => {
                if (car.currentTrack.name != null && car.currentTrack.artist != null)
                    console.log(`Now playing '${currentTrack.name}' by ${currentTrack.artist}`);
            }
        },
        hasParktronic: (car) => {
            car.checkDistance = (distance) => {
                let num = distance;
                if (num < 0.1) { console.log("Beep! Beep! Beep!"); }
                else if (num < 0.25) { console.log("Beep! Beep!"); }
                else if (num < 0.5) { console.log("Beep!"); }
            }
        },
    }

    return result;
}

const assemblyLine = AssemblyLine();

const myCar = {
    make: 'Toyota',
    model: 'Avensis'
};


assemblyLine.hasClima(myCar);
console.log(myCar.temp);
myCar.tempSettings = 18;
myCar.adjustTemp();
console.log(myCar.temp);

assemblyLine.hasAudio(myCar);
myCar.currentTrack = {
    name: 'Never Gonna Give You Up',
    artist: 'Rick Astley'
};
myCar.nowPlaying();

assemblyLine.hasParktronic(myCar);
myCar.checkDistance(0.4);
myCar.checkDistance(0.2);


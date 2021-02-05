function attachEventsListeners() {
   

    document.getElementById('convert').addEventListener('click', function () {

        const input = Number(document.getElementById('inputDistance').value);
        const inputUnits = document.getElementById('inputUnits').value;

        let output = 0;
        switch (inputUnits) {
            case 'km': output = input * 1000; break;
            case 'm': output = input * 1; break;
            case 'cm': output = input * 0.01; break;
            case 'mm': output = input * 0.001; break;
            case 'mi': output = input * 1609.34; break;
            case 'yrd': output = input * 0.9144; break;
            case 'ft': output = input * 0.3048; break;
            case 'in': output = input * 0.0254; break;
        }
        
        const outputUnits = document.getElementById('outputUnits').value;

        switch (outputUnits) {
            case 'km': output /= 1000; break;
            case 'm': output /= 1; break;
            case 'cm': output /= 0.01; break;
            case 'mm': output /= 0.001; break;
            case 'mi': output /= 1609.34; break;
            case 'yrd': output /= 0.9144; break;
            case 'ft': output /= 0.3048; break;
            case 'in': output /= 0.0254; break;
        }

        const outputDistance = document.getElementById('outputDistance').value = output;
    });
}
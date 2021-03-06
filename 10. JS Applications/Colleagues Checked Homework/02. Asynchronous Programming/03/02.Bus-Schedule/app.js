function solve() {
    const deptButton = document.getElementById('depart');
    const arvButton = document.getElementById('arrive');
    const infoTable = document.querySelector('#info span');

    let stop = {
        next: 'depot'
    };

    async function depart() {
        const url = `http://localhost:3030/jsonstore/bus/schedule/${stop.next}`;

        const response = await fetch(url);
        const jsonData = await response.json();
        console.log(jsonData);

        stop = jsonData;

        infoTable.textContent = `Next stop ${stop.name}`;

        deptButton.disabled = true;
        arvButton.disabled = false;
    }

    function arrive() {
        infoTable.textContent = `Arriving at ${stop.name}`;

        deptButton.disabled = false;
        arvButton.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();
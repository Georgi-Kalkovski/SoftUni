function solve() {

    const departBtn = document.getElementById('depart');
    const arriveBtn = document.getElementById('arrive');
    const infoBar = document.querySelector('#info span');

    let stop = { next: 'depot' };

    async function depart() {

        departBtn.disabled = true;
        arriveBtn.disabled = false;

        const url = 'http://localhost:3030/jsonstore/bus/schedule/' + stop.next;

        const response = await fetch(url);
        const data = await response.json();

        stop = data;

        infoBar.textContent = `Next stop ${stop.name}`;
    }

    function arrive() {

        departBtn.disabled = false;
        arriveBtn.disabled = true;

        infoBar.textContent = `Arriving at ${stop.name}`;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();
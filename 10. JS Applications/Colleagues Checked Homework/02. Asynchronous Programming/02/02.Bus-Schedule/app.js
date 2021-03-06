function solve() {
    const departBtn = document.getElementById("depart");
    const arriveBtn = document.getElementById("arrive");
    const banner = document.querySelector("#info span");

    let stop = {
        next: 'depot'
    }

    async function depart() {
        const url = 'http://localhost:3030/jsonstore/bus/schedule/' + stop.next;
        const res = await fetch(url);
        console.log(res)
        const data = await res.json();

        stop = data;

        banner.textContent = `Next stop ${stop.name}`;
        departBtn.disabled = true;
        arriveBtn.disabled = false;
    }

    function arrive() {
        banner.textContent = `Arriving at ${stop.name}`;
        departBtn.disabled = false;
        arriveBtn.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();

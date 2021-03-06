// valid Id's for the app to work : 1287, 1308, 1327 and 2334

function getInfo() {
    const stopId = document.getElementById('stopId');
    const url = `http://localhost:3030/jsonstore/bus/businfo/${stopId.value}`;
    const stopNameDiv = document.getElementById('stopName');
    const stopsUl = document.getElementById('buses');
    let stopsUlChildren = stopsUl.childNodes;

    fetch(url).then(res => res.json().then(data => {
        clearUlFromLis(stopsUlChildren);
        stopNameDiv.textContent = data.name;
        const busesIds = Object.keys(data.buses);
        const busesTimes = Object.values(data.buses);
        for (let i=0; i < busesIds.length; i++) {
            let li = document.createElement('li');
            li.textContent = `Bus ${busesIds[i]} arrives in ${busesTimes[i]}`;
            stopsUl.appendChild(li);
        }
    })).catch(err => {
        clearUlFromLis(stopsUlChildren);
        stopNameDiv.textContent = 'Error';
        console.log(err)
    })

    function clearUlFromLis(childrenNodes) {
        let childrenArr = Array.from(childrenNodes);
        for (let i = 0; i < childrenArr.length; i++) {
            childrenArr[i].remove()
        }
    }
}

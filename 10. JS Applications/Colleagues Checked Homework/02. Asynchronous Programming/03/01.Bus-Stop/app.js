async function getInfo() {
    const input = document.getElementById('stopId');

    const stopName = document.getElementById('stopName');
    const buses = document.getElementById('buses');

    const url = `http://localhost:3030/jsonstore/bus/businfo/${input.value}`;

    stopName.innerHTML = '';
    buses.innerHTML = '';

    try {
        const response = await fetch(url);
        const jsonData = await response.json();
        
        stopName.textContent = jsonData.name;

        Object.entries(jsonData.buses)
            .forEach(([busNumber, minutesArrive]) => {
                const li = document.createElement('li');
                li.textContent = 
                    `Bus ${busNumber} arrives in ${minutesArrive} minutes`;

                buses.appendChild(li);
        });
    } catch (err) {
        stopName.textContent = 'Error';
    }

    input.value = '';
}
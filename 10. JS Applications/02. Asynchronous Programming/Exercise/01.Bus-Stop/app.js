async function getInfo() {
    try {
        const id = document.getElementById('stopId').value;
        const url = 'http://localhost:3030/jsonstore/bus/businfo/' + id;
        const response = await fetch(url);
        const data = await response.json();

        document.getElementById('stopName').textContent = data.name;

        const buses = document.getElementById('buses');
        buses.textContent = '';

        for (const bus in data.buses) {
            const li = document.createElement('li');
            const time = data.buses[bus];
            li.textContent = `Bus ${bus} arrives in ${time}`;
            buses.appendChild(li);
        }
    } catch {
        document.getElementById('stopName').textContent = 'Error';
    }
    
    document.getElementById('stopId').value = '';
}
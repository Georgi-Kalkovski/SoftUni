function attachEvents() {

    getStudents();
}

attachEvents();

async function getStudents() {
    const response = await fetch('http://localhost:3030/jsonstore/collections/students');
    const data = await response.json();

    const body = document.querySelector('#results tbody');

    for (const key in data) {
        const id = key;
        const token = data[key];
        const tr = document.createElement('tr')
        tr.id = id;
        tr.appendChild(td(token.firstName));
        tr.appendChild(td(token.lastName));
        tr.appendChild(td(token.facultyNumber));
        tr.appendChild(td(token.grade));
        body.appendChild(tr);
    }
    
    const tFoot = document.createElement('tfoot');
    tFoot.style.backgroundColor = 'black'
    const lowerTr = document.createElement('tr');
    tFoot.appendChild(lowerTr);
    document.querySelector('#results').appendChild(tFoot);
}

function td(input) {
    const td = document.createElement('td');
    td.textContent = input;
    return td;
}
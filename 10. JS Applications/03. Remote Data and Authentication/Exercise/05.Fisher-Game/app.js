function attachEvents() {
    const link = 'http://localhost:3030/data/catches/';
    const token = sessionStorage.getItem('authToken');

    // Cleans the token upon Logout
    document.getElementById('logged').addEventListener('click', sessionStorage.clear());

    // Populating the Catches table on Load button click
    document.getElementById('load').addEventListener('click', (event) => {
        event.preventDefault();
        getCatches(link, token);
    });

    if (!token) {
        document.getElementById('guest').style.display = 'inline-block';
        document.getElementById('logged').style.display = 'none';
        document.querySelector("#addForm > button").disabled = true;
    } else {
        document.getElementById('guest').style.display = 'none';
        document.getElementById('logged').style.display = 'inline-block';
        document.querySelector("#addForm > button").disabled = false;

        // Adding of new Catch on Add button click
        document.querySelector("#addForm button").addEventListener('click', (e) => {
            e.preventDefault();
            const current = e.target.parentNode;
            postCatch(link, current, token);
        })

        // Updating/Deleting a Catch with the Update/Delete button
        document.querySelectorAll('#catches').forEach((btn) => btn.addEventListener('click', (e) => {
            e.preventDefault();
            if (e.target.nodeName == "BUTTON") {
                const current = e.target.parentNode;
                if (e.target.className === 'update') {
                    updateCatch(link, current, token);
                }
                if (e.target.className === 'delete') {
                    deleteCatch(link, current, token);
                }
            }
        }))
    }
}

attachEvents();

// Getting the Catches table
async function getCatches(link, tokenBtn) {
    const response = await fetch(link);
    const data = await response.json();

    const catches = document.getElementById('catches');
    catches.innerHTML = '';
    for (const key in data) {
        const token = data[key];

        const catchDiv = e('div', 'catch');
        catchDiv.id = token._id;
        const labelAngler = e('label', 'Angler');
        const inputAngler = e('input', 'text', 'angler', token.angler);
        const labelWeigth = e('label', 'Weight');
        const inputWeigth = e('input', 'text', 'weight', token.weight);
        const labelSpecies = e('label', 'Species');
        const inputSpecies = e('input', 'text', 'species', token.species);
        const labelLocation = e('label', 'Location');
        const inputLocation = e('input', 'text', 'location', token.location);
        const labelBait = e('label', 'Bait');
        const inputBait = e('input', 'text', 'bait', token.bait);
        const labelCaptureTime = e('label', 'Capture Time');
        const inputCaptureTime = e('input', 'text', 'captureTime', token.captureTime);
        const updateBtn = e('button', 'update', 'Update', tokenBtn);
        const deleteBtn = e('button', 'delete', 'Delete', tokenBtn);

        catchDiv.append(
            labelAngler, inputAngler, e('hr'),
            labelWeigth, inputWeigth, e('hr'),
            labelSpecies, inputSpecies, e('hr'),
            labelLocation, inputLocation, e('hr'),
            labelBait, inputBait, e('hr'),
            labelCaptureTime, inputCaptureTime, e('hr'),
            updateBtn, deleteBtn);
        catches.appendChild(catchDiv);
    }
}

// Adding of a new Catch to the table
async function postCatch(link, current, token) {

    const angler = current.children[2].value;
    const weight = current.children[4].value;
    const species = current.children[6].value;
    const location = current.children[8].value;
    const bait = current.children[10].value;
    const captureTime = current.children[12].value;

    nullCheck(angler, weight, species, location, bait, captureTime);

    await post(link, { angler, weight, species, location, bait, captureTime });

    for (let i = 2; i <= 12; i += 2) {
        current.children[i].value = '';
    }

    async function post(link, data) {
        await fetch(link, {
            method: 'post',
            headers: { 'Content-type': 'application/json', 'X-Authorization': token },
            body: JSON.stringify(data),
        });
        getCatches(link, token);
    }
}

// Updating Catch from the table
async function updateCatch(link, current, token) {
    const angler = current.children[1].value;
    const weight = current.children[4].value;
    const species = current.children[7].value;
    const location = current.children[10].value;
    const bait = current.children[13].value;
    const captureTime = current.children[16].value;

    nullCheck(angler, weight, species, location, bait, captureTime);

    await update(link, current, { angler, weight, species, location, bait, captureTime });

    async function update(link, current, data) {
        await fetch(link + current.id, {
            method: 'put',
            headers: { 'Content-type': 'application/json', 'X-Authorization': token },
            body: JSON.stringify(data),
        });
        getCatches(link, token);
    }
}

// Deleting Catch from the table
async function deleteCatch(link, current, token) {
    await fetch(link + current.id, {
        method: 'delete',
        headers: { 'X-Authorization': token },
    });
    getCatches(link, token);
}

// Function dealing with elements
function e(type, attribute1, attribute2, attribute3) {
    const element = document.createElement(type);
    if (type == 'div') {
        element.className = attribute1;
    } if (type == 'label') {
        element.textContent = attribute1;
    } if (type == 'input') {
        element.type = attribute1;
        element.className = attribute2;
        element.setAttribute('value', attribute3);
    } if (type == 'button') {
        element.className = attribute1;
        element.textContent = attribute2;
        if (attribute3 == null) {
            element.disabled = true;
        }
    }
    return element;
}

// Function dealing with null inputs
function nullCheck(angler, weight, species, location, bait, captureTime) {
    if (angler == '' || weight == '' || species == '' || location == '' || bait == '' || captureTime == '') {
        if (angler == '') { alert('Write Angler'); }
        else if (weight == '') { alert('Write Weight'); }
        else if (species == '') { alert('Write Species'); }
        else if (location == '') { alert('Write Location'); }
        else if (bait == '') { alert('Write Bait'); }
        else if (captureTime == '') { alert('Write Capture Time'); }
        throw new Error('Empty input');
    }
}
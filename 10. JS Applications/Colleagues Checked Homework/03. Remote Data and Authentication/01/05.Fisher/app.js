function isUserLogged() {
    if (sessionStorage.getItem('userToken')) {
        document.getElementById('user').style.display = 'block';
        document.getElementById('guest').style.display = 'none';

        document.getElementsByClassName('add')[0].disabled = false;
    } else {
        document.getElementById('user').style.display = 'none';
        document.getElementById('guest').style.display = 'block';
    }
}

isUserLogged();

function attachEvents() {
    document.querySelector('.load').addEventListener('click', () => getAllCatches());
    document.getElementById('logout').addEventListener('click', onLogout);
    document.getElementsByClassName('add')[0].addEventListener('click', createNewCatch);
}

attachEvents();

async function getAllCatches(ownerId) {
    try {
        const data = await request('http://localhost:3030/data/catches');
        render(data, ownerId);
    } catch (error) {
        const el = createHtmlElements('p', undefined, error.message);
        document.getElementById('catches').appendChild(el);
    }
}

async function getOneCatch(id) {

}

async function createNewCatch() {
    const form = document.querySelector('#addForm');
    const inputs = form.querySelectorAll('input');
    const [angler, weight, species, location, bait, captureTime] = [...inputs].map(e => e.value);

    if (!angler || !weight || !species || !location || !bait || !captureTime) {
        return alert('All fields are required!');
    }

    const url = 'http://localhost:3030/data/catches';
    const token = sessionStorage.getItem('userToken');

    try {
        await request(url, {
            method: 'post',
            headers: { 'Content-Type': 'aplication/json',
                        'X-Authorization': token },
            body: JSON.stringify({ angler, weight, species, location, bait, captureTime })
        });
        getAllCatches();
    } catch (error) {
        return alert(error.message);
    }
}

async function updateCatch(div) {
    const [angler, weight, species, location, bait, captureTime] = [...div.querySelectorAll('input')].slice(1).map(i => i.value);
    
    const url = 'http://localhost:3030/data/catches/' + div.id;
    const token = sessionStorage.getItem('userToken');
    try {
        await fetch(url, {
            method: 'put',
            headers: { 'X-Authorization': token },
            body: JSON.stringify({ angler, weight, species, location, bait, captureTime })
        });
        alert('Your changes are successfuly updated!');
        getAllCatches();
    } catch (error) {
        return alert(error.message);
    }
}

async function deleteCatch(id) {
    const url = 'http://localhost:3030/data/catches/' + id;

    const token = sessionStorage.getItem('userToken');

    try {
        await request(url, {
            method: 'delete',
            headers: {'X-Authorization': token }
        });
        confirm('Do you want to delete this item?')
    } catch (error) {
        return alert(error.message);
    }

    getAllCatches();
}

async function request(url, options) {
    const response = await fetch(url, options);

    if (response.ok == false) {
        const error = await response.json();
        throw new Error(error.message);
    }

    const data = await response.json();
    return data;
}

function render(data) {
    const parentDiv = document.getElementById('catches');
    parentDiv.innerHTML = '';

    data.map(el => {
        const div = createHtmlElements('div', 'catch', undefined, undefined, { id: el._id });
        const hiddenInput = createHtmlElements('input', undefined, undefined, undefined, { id: el._ownerId, type: 'hidden', disabled: true });
        const label = createHtmlElements('label', undefined, 'Angler');
        const anglerInput = createHtmlElements('input', 'angler', undefined, el.angler, {
            type: 'text'
        });
        const hr = createHtmlElements('hr');
        const weightLabel = createHtmlElements('label', undefined, 'Weight');
        const weightInput = createHtmlElements('input', 'weight', undefined, el.weight, {
            type: 'number'
        });
        const hr2 = createHtmlElements('hr');
        const speciesLabel = createHtmlElements('label', undefined, 'Species');
        const speciesInput = createHtmlElements('input', 'species', undefined, el.species, {
            type: 'text'
        });
        const hr3 = createHtmlElements('hr');
        const locationLabel = createHtmlElements('label', undefined, 'Location');
        const locationInput = createHtmlElements('input', 'location', undefined, el.location, {
            type: 'text'
        });
        const hr4 = createHtmlElements('hr');
        const baitLabel = createHtmlElements('label', undefined, 'Bait');
        const baitInput = createHtmlElements('input', 'bait', undefined, el.bait, {
            type: 'text'
        });
        const hr5 = createHtmlElements('hr');
        const captureLabel = createHtmlElements('label', undefined, 'Capture Time');
        const captureInput = createHtmlElements('input', 'captureTime', undefined, el.captureTime, {
            type: 'number'
        });
        const hr6 = createHtmlElements('hr');

        let updateButton;
        let deleteButton;

        const ownerId = sessionStorage.getItem('userId');

        if (ownerId && ownerId == el._ownerId) {
            updateButton = createHtmlElements('button', 'update', 'Update');
            deleteButton = createHtmlElements('button', 'delete', 'Delete');
        } else {
            updateButton = createHtmlElements('button', 'update', 'Update', undefined, {
                disabled: true
            });
            deleteButton = createHtmlElements('button', 'delete', 'Delete', undefined, {
                disabled: true
            });
        }

        updateButton.addEventListener('click', () => updateCatch(div));
        deleteButton.addEventListener('click', () => deleteCatch(el._id));

        const arrayOfElements = [
            hiddenInput, label, anglerInput, hr, weightLabel, weightInput,
            hr2, speciesLabel, speciesInput, hr3, locationLabel,
            locationInput, hr4, baitLabel, baitInput, hr5,
            captureLabel, captureInput, hr6, updateButton, deleteButton
        ];

        appendElements(div, arrayOfElements);
        appendElements(parentDiv, [div]);
    });
}

function appendElements(parent, elements) {
    elements.map(el => parent.appendChild(el));
}

function createHtmlElements(type, className, content, value, attributes) {
    const el = document.createElement(type);

    if (className) {
        el.className = className;
    }

    if (content) {
        el.textContent = content;
    }

    if (value) {
        el.value = value;
    }

    if (attributes) {
        Object.entries(attributes).map(([key, value]) => {
            el[key] = value;
        });
    }

    return el;
}

//Pseudo logout
async function onLogout() {
    sessionStorage.clear();
    isUserLogged();
}
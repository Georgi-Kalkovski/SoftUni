const catches = document.getElementById('catches');

function attachEvents() {
    catches.innerHTML = '';

    if (!sessionStorage.getItem('token')) {
        document.getElementById('guest').style.display = 'inline-block';
        document.getElementById('logged').style.display = 'none';
    } else {
        document.getElementById('guest').style.display = 'none';
        document.getElementById('logged').style.display = 'inline-block';

        document.getElementById('addCatchBtn').disabled = false;
        document.getElementById('addCatchBtn').addEventListener('click', async() => {
            const angler = document.querySelector('#addForm [class="angler"]').value;
            const weight = document.querySelector('#addForm [class="weight"]').value;
            const species = document.querySelector('#addForm [class="species"]').value;
            const location = document.querySelector('#addForm [class="location"]').value;
            const bait = document.querySelector('#addForm [class="bait"]').value;
            const captureTime = document.querySelector('#addForm [class="captureTime"]').value;

            if (!angler || !Number(weight) || !species || !location || !bait || !Number(captureTime)) {
                return;
            }

            document.querySelector('#addForm [class="angler"]').value = '';
            document.querySelector('#addForm [class="weight"]').value = '';
            document.querySelector('#addForm [class="species"]').value = '';
            document.querySelector('#addForm [class="location"]').value = '';
            document.querySelector('#addForm [class="bait"]').value = '';
            document.querySelector('#addForm [class="captureTime"]').value = '';

            const newCatch = { angler, weight: Number(weight), species, location, bait, 'captureTime ': Number(captureTime) };
            registerNewCatch(newCatch);
        });

        document.getElementById('logged').addEventListener('click', () => {
            sessionStorage.clear();
        });
    }

    document.querySelector('.load').addEventListener('click', loadAllCatches);
}

attachEvents();

async function loadAllCatches() {
    catches.innerHTML = '';
    const response = await fetch('http://localhost:3030/data/catches');
    const data = await response.json();

    Object.values(data).forEach(c => {
        const element = e('div', { className: 'catch' },
            e('label', {}, 'Angler'),
            e('input', { type: 'text', className: 'angler', value: `${c.angler}` }),
            e('hr', {}),
            e('label', {}, 'Weight'),
            e('input', { type: 'number', className: 'weight', value: `${c.weight}` }),
            e('hr', {}),
            e('species', {}, 'Species'),
            e('input', { type: 'text', className: 'species', value: `${c.species}` }),
            e('hr', {}),
            e('label', {}, 'Location'),
            e('input', { type: 'text', className: 'location', value: `${c.location}` }),
            e('hr', {}),
            e('label', {}, 'Bait'),
            e('input', { type: 'text', className: 'bait', value: `${c.bait}` }),
            e('hr', {}),
            e('label', {}, 'Capture Time'),
            e('input', { type: 'number', className: 'captureTime', value: `${c['captureTime ']}` }),
            e('hr', {}),
            e('button', { disabled: true, className: 'update' }, 'Update'),
            e('button', { disabled: true, className: 'delete' }, 'Delete')
        );

        if (c._ownerId == sessionStorage.getItem('id')) {
            element.querySelector('.update').disabled = false;
            element.querySelector('.delete').disabled = false;

            element.querySelector('.update').addEventListener('click', async(event) => {
                const form = event.target.parentNode.children;

                const angler = form[1].value;
                const weight = form[4].value;
                const species = form[7].value;
                const location = form[10].value;
                const bait = form[13].value;
                const captureTime = form[16].value;

                if (!angler || !Number(weight) || !species || !location || !bait || !Number(captureTime)) {
                    return;
                }

                const updatedCatch = { angler, weight: Number(weight), species, location, bait, 'captureTime ': Number(captureTime) };
                updateCatch(c._id, updatedCatch);
            });

            element.querySelector('.delete').addEventListener('click', async() => {
                const confimation = confirm('Are you sure you want to delete your catch?');
                if (confimation) {
                    deleteCatch(c._id);
                }
            });
        }

        catches.appendChild(element);
    });
}

async function registerNewCatch(newCatch) {
    await fetch('http://localhost:3030/data/catches', {
        method: 'post',
        headers: { 'Content-Type': 'application/json', 'X-Authorization': `${sessionStorage.getItem('token')}` },
        body: JSON.stringify(newCatch)
    });

    loadAllCatches();
}

async function updateCatch(id, updatedCatch) {
    await fetch('http://localhost:3030/data/catches/' + id, {
        method: 'put',
        headers: { 'Content-Type': 'application/json', 'X-Authorization': `${sessionStorage.getItem('token')}` },
        body: JSON.stringify(updatedCatch)
    });

    loadAllCatches();
}

async function deleteCatch(id) {
    await fetch('http://localhost:3030/data/catches/' + id, {
        method: 'delete',
        headers: { 'X-Authorization': `${sessionStorage.getItem('token')}` }
    });

    loadAllCatches();
}

function e(type, attributes, ...content) {
    const result = document.createElement(type);

    for (let [attr, value] of Object.entries(attributes || {})) {
        if (attr.substring(0, 2) == 'on') {
            result.addEventListener(attr.substring(2).toLocaleLowerCase(), value);
        } else {
            result[attr] = value;
        }
    }

    content.forEach(e => {
        if (typeof e == 'string' || typeof e == 'number') {
            const node = document.createTextNode(e);
            result.appendChild(node);
        } else {
            result.appendChild(e);
        }
    });

    return result;
}
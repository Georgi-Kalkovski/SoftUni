function attachEvents() {
    document.getElementById('btnLoad').addEventListener('click', getContacts);
    document.getElementById('phonebook').addEventListener('click', (event) => {
        if (event.target.className == 'deleteBtn') {
            const id = event.target.parentNode.id;
            deleteContact(id)
        }
    });
    document.getElementById('btnCreate').addEventListener('click', createEntrie)
}

attachEvents();

async function getContacts() {
    const contacts = Object.values(await request('http://localhost:3030/jsonstore/phonebook'));
    const phonebook = document.getElementById('phonebook');
    phonebook.innerHTML = '';
    contacts.map(c => renderEntrie(c)).forEach(en => phonebook.appendChild(en));
}

function renderEntrie(c) {
    const li = document.createElement('li');
    li.textContent = `${c.person}: ${c.phone}`;
    li.id = c._id;
    const deleteBtn = document.createElement('button');
    deleteBtn.textContent = 'Delete';
    deleteBtn.className = 'deleteBtn'
    li.appendChild(deleteBtn);
    return li;
}

async function deleteContact(id) {
    const result = await request('http://localhost:3030/jsonstore/phonebook/' + id, {
        method: 'delete'
    });
    getContacts();
}

async function createEntrie() {
    const person = document.getElementById('person').value;
    const phone = document.getElementById('phone').value;

    await request('http://localhost:3030/jsonstore/phonebook', {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ person, phone })
    })
    document.getElementById('person').value = '';
    document.getElementById('phone').value = '';
    getContacts();
}

async function request(url, options) {
    const response = await fetch(url, options);
    if (response.ok != true) {
        const error = await response.json();
        alert(error.message)
        throw new Error(error.message)
    }
    const data = await response.json();
    return data;
}
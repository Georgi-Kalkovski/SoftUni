function attachEvents() {

    const link = 'http://localhost:3030/jsonstore/phonebook/';

    // Event listener for Load Button
    document.getElementById('btnLoad').addEventListener('click', () => {
        getPhonebook(link);
    });

    // Event listener for the Create Button
    document.getElementById('btnCreate').addEventListener('click', () => {
        const person = document.getElementById('person').value;
        const phone = document.getElementById('phone').value;

        createPerson(link, { person, phone });

        person.value = '';
        phone.value = '';
    });

    // Event listener for the Delete Buttons
    document.querySelectorAll('#phonebook').forEach(btn => btn.addEventListener('click', (e) => {
        if (e.target.value != ' ') {
            deletePerson(link, e.target.parentNode.id);
        }
    }));
}

attachEvents();

// Load Phonebook
async function getPhonebook(link) {
    const response = await fetch(link);
    const data = await response.json();

    const phonebook = document.getElementById('phonebook');
    phonebook.textContent = '';

    for (const key in data) {
        const li = document.createElement('li');
        const button = document.createElement('button');
        button.id = key;
        button.textContent = 'Delete';

        const token = data[key];

        li.id = token._id;
        li.textContent = `${token.person}: ${token.phone}`;

        li.appendChild(button);
        phonebook.appendChild(li);
    }
}

// Create Person
async function createPerson(link, person) {
    await fetch(link, {
        method: 'post',
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify(person),
    });
    getPhonebook(link);
}

// Delete Person
async function deletePerson(link, id) {
    await fetch(link + id, {
        method: 'delete',
    });
    getPhonebook(link);
}
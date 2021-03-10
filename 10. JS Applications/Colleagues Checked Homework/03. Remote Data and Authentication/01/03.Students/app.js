const url = 'http://localhost:3030/jsonstore/collections/students';

async function onLoad() {
    const response = await fetch(url);

    if (response.ok == false) {
        return alert('Database is empty!');
    }

    const data = await response.json();

    const tbody = document.querySelector('table tbody');
    tbody.innerHTML = '';

    Object.values(data).map(({
        firstName,
        lastName,
        facultyNumber,
        grade
    }) => {
        const tr = createHtmlElement('tr');

        const firstNameTh = createHtmlElement('th', firstName);
        const lastNameTh = createHtmlElement('th', lastName);
        const facultyNumberTh = createHtmlElement('th', facultyNumber);
        const gradeTh = createHtmlElement('th', grade);

        tr.appendChild(firstNameTh);
        tr.appendChild(lastNameTh);
        tr.appendChild(facultyNumberTh);
        tr.appendChild(gradeTh);

        tbody.appendChild(tr);
    })
}

function createHtmlElement(type, textContent) {
    const el = document.createElement(type);

    if (textContent) {
        el.textContent = textContent;
    }

    return el;
}

onLoad();

function attachEvents() {
    document.getElementById('form').addEventListener('submit', onSubmit);
}

attachEvents();

async function onSubmit(evt) {
    evt.preventDefault();

    const formData = new FormData(evt.target);

    const firstName = formData.get('firstName');
    const lastName = formData.get('lastName');
    const facultyNumber = formData.get('facultyNumber');
    const grade = formData.get('grade');

    if (!firstName || !lastName || !facultyNumber || !grade) {
        return alert('All fields are required!');
    }

    let facultyNumberAsNumber = Number(facultyNumber);
    if (isNaN(facultyNumberAsNumber)) {
        return alert('Faculty number should be integer!');
    }

    let gradeAsNumber = Number(grade);
    if (isNaN(gradeAsNumber)) {
        return alert('Grade should be decimal.');
    }

    const response = await fetch(url, {
        method: 'post',
        headers: {
            'Content-Type': 'aplication/json'
        },
        body: JSON.stringify({
            firstName,
            lastName,
            facultyNumber,
            grade: gradeAsNumber
        })
    });

    if (response.ok == false) {
        return alert('You can not publish this data.');
    }

    [...document.getElementsByTagName('input')].forEach(i => i.value = '');

    onLoad();
}
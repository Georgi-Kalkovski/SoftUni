function attachEvents() {

    const link = 'http://localhost:3030/jsonstore/collections/students';

    // Getting student table
    getStudentsTable(link);

    // Getting student form
    studentForm();

    // Event listener dealing with the submit
    document.querySelector('button').addEventListener('click', () => {
        const firstName = document.getElementById('firstName').value;
        const lastName = document.getElementById('lastName').value;
        const facultyNumber = document.getElementById('facultyNumber').value;
        const grade = document.getElementById('grade').value;

        studentFormTypeCheck(firstName, lastName, facultyNumber, grade);
        createStudent(link, { firstName, lastName, facultyNumber, grade });
        getStudentsTable(link);
    });
}

attachEvents();

// Student Table
async function getStudentsTable(link) {
    const response = await fetch(link);
    const data = await response.json();

    const body = document.querySelector('#results tbody');
    body.innerHTML = '';

    for (const key in data) {
        const id = key;
        const token = data[key];
        const tr = e('tr')
        tr.id = id;
        tr.appendChild(e('td', token.firstName));
        tr.appendChild(e('td', token.lastName));
        tr.appendChild(e('td', token.facultyNumber));
        tr.appendChild(e('td', token.grade));
        body.appendChild(tr);
    }
}

// Student Form
function studentForm() {

    const form = e('tfoot');

    // Name Row
    const nameRow = e('tr');
    const name = e('th', 'FORM');
    name.style.textAlign = 'center';
    nameRow.append(e('td'), name, e('td'), e('td'));
    form.appendChild(nameRow);

    // Input Row
    const inputRow = e('tr');
    const inputFirstName = e('input', '', 'firstName', 'First Name...');
    const inputLastName = e('input', '', 'lastName', 'Last Name...');
    const inputFacultyNumber = e('input', '', 'facultyNumber', 'Faculty Number...');
    const inputGrade = e('input', '', 'grade', 'Grade...');
    td(inputRow, inputFirstName);
    td(inputRow, inputLastName);
    td(inputRow, inputFacultyNumber);
    td(inputRow, inputGrade);
    form.appendChild(inputRow);

    // Button Row
    const buttonRow = e('tr');
    const submitBtn = e('button');
    submitBtn.textContent = 'Submit';
    buttonRow.append(e('td'), e('td'), e('td'), submitBtn);
    form.appendChild(buttonRow);

    document.querySelector('#results').appendChild(form);
}

// Creating Student
async function createStudent(link, student) {
    await fetch(link, {
        method: 'post',
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify(student),
    });
}

// Student Form Type Check
function studentFormTypeCheck(firstName, lastName, facultyName, grade) {
    const isTrue = true;

    if (!String(firstName)) {
        alert('First Name must be string!')
        isTrue = false;
    } if (!String(lastName)) {
        alert('Last Name must be string!')
        isTrue = false;
    } if (!Number(facultyName)) {
        alert('Faculty Number must be number!')
        isTrue = false;
    } if (!Number(grade)) {
        alert('Grade must be number!')
        isTrue = false;
    } if (Number(grade) > 6) {
        alert('Grade cannot be more than 6.00!')
        isTrue = false;
    } if (Number(grade) < 0) {
        alert('Grade cannot be negative number!')
        isTrue = false;
    }

    if (isTrue) { return; }
    else { throw new Error('Wrong input. Try again.') }
}

// Function dealing with elements
function e(type, text, id, placeholder) {
    const element = document.createElement(type);
    if (type == 'input') {
        element.placeholder = placeholder;
    }
    if (text) {
        element.textContent = text;
    }
    if (id) {
        element.id = id;
    }
    return element;
}

// Function that makes 'td' element
function td(target, input) {
    const td = e('td');
    td.appendChild(input);
    target.appendChild(td);
}
async function getStudents() {
    const students = await request('http://localhost:3030/jsonstore/collections/students')
    const rows = Object.values(students).map(createRows).join('');
    document.querySelector('tbody').innerHTML = rows;

    function createRows(student) {
        result = `<tr>
        <td>${student.firstName}</td>
        <td>${student.lastName}</td>
        <td>${student.facultyNumber}</td>
        <td>${student.grade}</td>
        </tr>`
        return result;
    }
}

async function createStudent(event) {
    event.preventDefault();
    const formData = new FormData(event.target);
    let student = {};
    if (formData.get('firstName') != '' && formData.get('lastName') != ''
        && formData.get('facultyNumber') != '' && formData.get('grade') != '') {
        student = {
            firstName: formData.get('firstName'),
            lastName: formData.get('lastName'),
            facultyNumber: formData.get('facultyNumber'),
            grade: formData.get('grade')
        }
        await request('http://localhost:3030/jsonstore/collections/students', {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(student)
        });
    }
    getStudents();
    event.target.reset();
}

function start() {
    getStudents();
    document.getElementById('form').addEventListener('submit', createStudent);
}

start()

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
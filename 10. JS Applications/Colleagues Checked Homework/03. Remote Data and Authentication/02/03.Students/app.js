const tbody = document.querySelector('tbody');

function main() {
    getAllStudents();
    document.getElementById('submit').addEventListener('click', createStudent);
}

main();

function createStudent(event) {
    event.preventDefault();
    const [fName, lName, fNumber, grade] = document.querySelectorAll('input');

    if (fName.value == '' || lName.value == '' || fNumber.value == '' || grade == '') {
        return;
    }

    const result = `
            <tr>
                <td>${fName.value}</td>
                <td>${lName.value}</td>
                <td>${fNumber.value}</td>
                <td>${Number(grade.value).toFixed(2)}</td>
            </tr>`;

    tbody.innerHTML += result;

    clearInputs(fName, lName, fNumber, grade);
}

function clearInputs(firstName, lastName, facultyNumber, grade) {
    firstName.value = '';
    lastName.value = '';
    facultyNumber.value = '';
    grade.value = '';
}

async function getAllStudents() {
    const url = 'http://localhost:3030/jsonstore/collections/students';

    const response = await fetch(url);
    const data = await response.json();


    Object.values(data).forEach(student => {
        const firstName = student.firstName;
        const lastName = student.lastName;
        const facultyNumber = student.facultyNumber;
        const grade = student.grade.toFixed(2);

        const result = `
            <tr>
                <td>${firstName}</td>
                <td>${lastName}</td>
                <td>${facultyNumber}</td>
                <td>${grade}</td>
            </tr>`;

        tbody.innerHTML += result;
    });
}
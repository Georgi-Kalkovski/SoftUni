import { showHome } from './home.js';

async function onSubmit(e) {
    e.preventDefault();
    const formData = new FormData(e.target);
    const email = formData.get('email');
    const password = formData.get('password');
    const repass = formData.get('repeatPassword');

    if (email == '' || password == '') {
        return alert('All fields are required!')
    } else if (password != repass) {
        return alert('Password dont math!')
    }

    const response = await fetch('http://localhost:3030/users/register', {
        method: 'post',
        headers: { 'Content-Type': 'applicatin/json' },
        body: JSON.stringify({ email, password }),
    });

    if (response.ok) {
        e.target.reset();
        const data = await response.json()
        sessionStorage.setItem('authToken', data.accessToken);
        sessionStorage.setItem('userId', data._id);
        sessionStorage.setItem('email', data.email);

        document.getElementById('welcome-msg').textContent = `Welcome, ${email}`;

        [...document.querySelectorAll('nav .user')].forEach(x => x.style.display = 'block');
        [...document.querySelectorAll('nav .guest')].forEach(x => x.style.display = 'none');

        showHome();
    } else {
        const error = await response.json();
        alert(error.message);
    }
}

let main;
let section;

export function setupRegister(mainTarget, sectionTarget) {
    main = mainTarget;
    section = sectionTarget;

    const form = section.querySelector('form');
    form.addEventListener('submit', onSubmit);
}

export async function showRegister() {
    main.innerHTML = '';
    main.appendChild(section);
}
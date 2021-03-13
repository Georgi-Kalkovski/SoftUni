import {showHome} from './home.js';
let main;
let section;

async function onSubmit(event) {
    event.preventDefault();
    let form = new FormData(event.target);
    const email = form.get('email');
    const password = form.get('password');
    const repeatPassword = form.get('repeatPassword');
    if (email == "" || password == "") {
        return alert ('All fields are required!')
    }
    if (password != repeatPassword) {
        return alert ('Passwords do not match!')
    }
    const response = await fetch('http://localhost:3030/users/register', {
        method: 'post',
        headers: {"Content-Type": 'application/json'},
        body: JSON.stringify({email,password})
    })
    if (!response.ok) {
        const error = await response.json();
        return alert(error.message);
    } else {
        event.target.reset();
        const data = await response.json();
        sessionStorage.setItem('authToken', data.accessToken);
        sessionStorage.setItem('userId', data._id);
        sessionStorage.setItem('email', data.email);
        document.getElementById('welcome-msg').textContent = `Welcome ${email}`;
        [...document.querySelectorAll('nav .user')].forEach(l => l.style.display = 'block');
        [...document.querySelectorAll('nav .guest')].forEach(l => l.style.display = 'none');
        showHome();
    }
    
}

function setupRegister(mainTarged, sectionTarget) {
    main = mainTarged;
    section = sectionTarget;
}

async function showRegister() {
    main.innerHTML = "";
    main.appendChild(section);
    section.querySelector('form').addEventListener('submit', onSubmit)
}

export {
    setupRegister,
    showRegister
}

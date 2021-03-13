import {showHome} from './home.js';
let main;
let section;

async function onSubmit(event) {
    event.preventDefault();
    let form = new FormData(event.target);
    const email = form.get('email');
    const password = form.get('password');
    const response = await fetch('http://localhost:3030/users/login', {
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


function setupLogin(mainTarged, sectionTarget) {
    main = mainTarged;
    section = sectionTarget;

    section.querySelector('form').addEventListener('submit', onSubmit)
}

async function showLogin() {
    main.innerHTML = "";
    main.appendChild(section);
}

export {
    setupLogin,
    showLogin
}

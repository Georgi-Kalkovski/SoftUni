import { displayHome } from "./home.js";

async function onSubmit(ev) {
    ev.preventDefault();
        const formData = new FormData(ev.target);
        const password = formData.get('password');
        const email = formData.get('email');

        const response = await fetch('http://localhost:3030/users/login', {
            method: 'post',
            headers: {
                'Content-Type' : 'application.json'
            },
            body : JSON.stringify({email, password})
        });

        if (response.ok == true) {
            ev.target.reset();
            const data = await response.json();
            sessionStorage.setItem('token', data.accessToken);
            sessionStorage.setItem('ownerId', data._id);
            sessionStorage.setItem('email', data.email);

            document.getElementById('welcomeMsg').textContent = `Welcome, ${data.email}`;
            document.querySelectorAll('nav .user').forEach(el => el.style.display = 'block');
            document.querySelectorAll('nav .guest').forEach(el => el.style.display = 'none');

            displayHome();
        } else {
            const error = await response.json();
            alert(error.message);
        }
}

let main;
let section;

export function setupLogin(mainTarget, sectionTarget) {
    main = mainTarget;
    section = sectionTarget;

    const form = section.querySelector('form');
    form.addEventListener('submit', onSubmit);
}

export async function displayLogin() {
    main.innerHTML = '';
    main.appendChild(section);
}
import { setupHome, showHome } from './home.js';
import { setupDetails } from './details.js';
import { setupLogin, showLogin } from './login.js';
import { setupRegister, showRegister } from './register.js';
import { setupCreate, showCreate } from './create.js';
import { setupEdit, showEdit } from './edit.js';

const main = document.querySelector('main');

const links = {
    'homeLink': showHome,
    'loginLink': showLogin,
    'registerLink': showRegister,
    'createLink': showCreate,
    // 'editButton': showEdit,
}

setupSection('home-page', setupHome);
setupSection('add-movie', setupCreate);
setupSection('movie-details', setupDetails);
setupSection('edit-movie', setupEdit);
setupSection('form-login', setupLogin);
setupSection('form-sign-up', setupRegister);

setupNavigation();
showHome();

function setupSection(sectionId, setup) {
    const section = document.getElementById(sectionId);
    // console.log(section);
    setup(main, section);
}

function setupNavigation() {
    const email = sessionStorage.getItem('email');
    if (email != null) {
        document.getElementById('welcome-msg').textContent = `Welcome, ${email}`;

        [...document.querySelectorAll('nav .user')].forEach(x => x.style.display = 'block');
        [...document.querySelectorAll('nav .guest')].forEach(x => x.style.display = 'none');
    } else {
        [...document.querySelectorAll('nav .user')].forEach(x => x.style.display = 'none');
        [...document.querySelectorAll('nav .guest')].forEach(x => x.style.display = 'block');
    }

    document.querySelector('nav').addEventListener('click', (e) => {
        const view = links[e.target.id];
        if (typeof view == 'function') {
            e.preventDefault();
            view();
        }
    });
    document.getElementById('createLink').addEventListener('click', e => {
        e.preventDefault();
        showCreate();
    });
    document.getElementById('logoutBtn').addEventListener('click', logout);
}

async function logout() {
    const token = sessionStorage.getItem('authToken');
    const response = await fetch('http://localhost:3030/users/logout', {
        method: 'post',
        headers: { 'X-Authorization': token }
    });

    if (response.ok) {
        sessionStorage.removeItem('authToken');
        sessionStorage.removeItem('userId');
        sessionStorage.removeItem('email');

        [...document.querySelectorAll('nav .user')].forEach(x => x.style.display = 'none');
        [...document.querySelectorAll('nav .guest')].forEach(x => x.style.display = 'block');

        showHome();
    } else {
        const error = await response.json();
        alert(error.message);
    }
}

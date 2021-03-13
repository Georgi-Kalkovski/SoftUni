import { displayHome, setupHome } from './home.js'
import { setupDetails } from './details.js'
import { displayLogin, setupLogin } from './login.js'
import { displayRegister, setupRegister } from './register.js'
import { displayCreate, setupCreate } from './create.js'
import { setupEdit } from './edit.js'

const main = document.querySelector('main');
const links = {
    'homeLink': displayHome,
    'loginLink': displayLogin,
    'registerLink': displayRegister,
    'createLink': displayCreate
}


setupSection('home-page', setupHome);
setupSection('movie-details', setupDetails);
setupSection('form-login', setupLogin);
setupSection('form-sign-up', setupRegister);
setupSection('add-movie', setupCreate);
setupSection('edit-movie', setupEdit);

setupNav();

displayHome();

function setupSection(sectionId, setup) {
    const section = document.getElementById(sectionId);
    setup(main, section);
}

function setupNav() {
    const email = sessionStorage.getItem('email');

    if (email != null) {
        document.getElementById('welcomeMsg').textContent = `Welcome, ${email}`;
        document.querySelectorAll('nav .user').forEach(el => el.style.display = 'block');
        document.querySelectorAll('nav .guest').forEach(el => el.style.display = 'none');
    } else {
        document.querySelectorAll('nav .user').forEach(el => el.style.display = 'none');
        document.querySelectorAll('nav .guest').forEach(el => el.style.display = 'block');
    }
    document.querySelector('nav').addEventListener('click', ev => {
        if (ev.target.tagName == 'A') {
            const view = links[ev.target.id];
            if (typeof view == 'function') {
                ev.preventDefault();
                view();
            }
        }
    })
    document.getElementById('createLink').addEventListener('click', ev => {
        ev.preventDefault();
        displayCreate();
    })

    document.getElementById('logoutBtn').addEventListener('click', logout);
};

async function logout() {
    const token = sessionStorage.getItem('token');

    const response = await fetch('http://localhost:3030/users/logout', {
        method: 'get',
        headers: { 'X-authorization' : token}
    });

    if (response.ok) {
        sessionStorage.removeItem('token');
        sessionStorage.removeItem('email');
        sessionStorage.removeItem('ownerId');

        document.querySelectorAll('nav .user').forEach(el => el.style.display = 'none');
        document.querySelectorAll('nav .guest').forEach(el => el.style.display = 'block');

        displayHome();
    } else {
        const error = await response.json();
        alert(error.message);
    }

}
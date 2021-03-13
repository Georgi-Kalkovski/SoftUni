import {e} from './dom.js';
import {setupHome, showHome} from './home.js';
import {setupDetails} from './details.js';
import {setupLogin, showLogin} from './login.js';
import {setupRegister, showRegister} from './register.js';
import {setupCreate, showCreate} from './create.js';
import {setupEdit} from './edit.js';
//import modules
//grab sections
//setup modules
//setup navigation

const main = document.querySelector('main');

const links = {
    'homeLink': showHome,
    'loginLink': showLogin,
    'registerLink': showRegister,
    'createLink': showCreate
}



setupSection("home-page", setupHome);
setupSection("add-movie", setupCreate);
setupSection("movie-details", setupDetails);
setupSection("form-sign-up", setupRegister);
setupSection("form-login", setupLogin);
setupSection("edit-movie", setupEdit);

setupNavigation();
showHome();

function setupSection(sectionID, setup) {
    const section = document.getElementById(sectionID);
    setup(main, section);
}

function setupNavigation() {
    const email = sessionStorage.getItem('email');
    if (email == null) {
        [...document.querySelectorAll('nav .user')].forEach(l => l.style.display = 'none');
        [...document.querySelectorAll('nav .guest')].forEach(l => l.style.display = 'block');
    } else {
         document.getElementById('welcome-msg').textContent = `Welcome ${email}`;
        [...document.querySelectorAll('nav .user')].forEach(l => l.style.display = 'block');
        [...document.querySelectorAll('nav .guest')].forEach(l => l.style.display = 'none');
    }
    
    const nav = document.querySelector('nav').addEventListener('click', (event) => {
        if (event.target.tagName === 'A') { 
            const view = links[event.target.id];
            if (typeof view === 'function') {
                event.preventDefault();
                view();
            }
            
        }
    })
    document.getElementById('createLink').addEventListener('click', (event) => {
        event.preventDefault();
        showCreate();
    })
    document.getElementById('logoutBtn').addEventListener('click', logout);
}

async function logout() {
    const token = sessionStorage.getItem('authToken');
    const response = await fetch('http://localhost:3030/users/logout', {
        method: 'get',
        headers: {"X-Authorization": token}
    });
    if (response.ok) {
        sessionStorage.clear();
        [...document.querySelectorAll('nav .user')].forEach(l => l.style.display = 'none');
        [...document.querySelectorAll('nav .guest')].forEach(l => l.style.display = 'block');
        showHome();
    } else {
        const error = await response.json();
        return alert(error.message);
    }

}
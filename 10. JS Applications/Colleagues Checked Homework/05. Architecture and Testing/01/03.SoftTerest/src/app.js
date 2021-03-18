import {setupHome} from '../views/home.js';
import {setupLogin} from '../views/login.js';
import {setupRegister} from '../views/register.js';
import {setupDashboard} from '../views/dashboard.js';
import {setupDetails} from '../views/details.js';
import {setupCreate} from '../views/create.js';
import {logout} from './api/data.js'

const main = document.querySelector('main');
const nav = document.querySelector('nav');

const views = {};
const links = {};

const navigation = {
    loadPage,
    setUserNav
};

registerView(document.querySelector('#homePage'), setupHome, 'home', 'homeNav');
registerView(document.querySelector('#registerPage'), setupRegister, 'register', 'regNav');
registerView(document.querySelector('#loginPage'), setupLogin, 'login', 'loginNav');
registerView(document.querySelector('#dashboard-holder'), setupDashboard, 'dashboard', 'dashNav');
registerView(document.querySelector('#createPage'), setupCreate, 'create', 'createNav');
registerView(document.querySelector('#detailsPage'), setupDetails, 'details');

setupNavigation();
setUpLogoutBtn();
loadPage('home');

function registerView(section, setup, name, linkId){
    const view = setup(section, navigation);
    views[name] = view;
    if (linkId) {
        links[linkId] = name;
    }
}

async function loadPage(name, ...params){
    main.innerHTML = '';
    const view = views[name];
    const section = await view(...params);
    main.appendChild(section);
}

function setUserNav(){
    const token = sessionStorage.getItem('userToken');

    if (token != null) {
        [...nav.querySelectorAll('.user-nav')].forEach(x => x.style.display = 'list-item');
        [...nav.querySelectorAll('.guest')].forEach(x => x.style.display = 'none');
    }
    else{
        [...nav.querySelectorAll('.user-nav')].forEach(x => x.style.display = 'none');
        [...nav.querySelectorAll('.guest')].forEach(x => x.style.display = 'list-item');
    }
}

function setupNavigation(){
    setUserNav();

    nav.addEventListener('click', (e) => {
        const viewName = links[e.target.id];
        if (viewName) {
            e.preventDefault();
            loadPage(viewName);
        }
       
    })
}

function setUpLogoutBtn(){
    document.querySelector('#logoutNav').addEventListener('click', (e) => {
        if (sessionStorage.getItem('userToken') != null) {
            logout();
            setUserNav();
            navigation.loadPage('home');
        }
    })
}




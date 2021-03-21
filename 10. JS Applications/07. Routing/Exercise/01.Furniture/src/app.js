import {showRegister} from "./views/regster.js";
import {showLogin} from "./views/login.js";
import {showDashboard} from "./views/dashboard.js";
import {showMyPage} from "./views/myPage.js";
import {showDetails} from "./views/details.js";
import {showEdit} from "./views/edit.js";
import {showCreate} from "./views/create.js"
import {logout} from './api/api.js'
import {render} from '../node_modules/lit-html/lit-html.js'
import page from '../node_modules/page/page.mjs'

const navigationLogged = document.getElementById('user');
const navigationGuest = document.getElementById('guest');
document.getElementById('logoutBtn').addEventListener('click',logOut)

page('/register', ctxDecoration, showRegister)
page('/login', ctxDecoration, showLogin)
page('/', ctxDecoration, showDashboard)
page('/my-furniture', ctxDecoration, showMyPage)
page('/details/:id', ctxDecoration, showDetails)
page('/edit/:id', ctxDecoration, showEdit)
page('/create', ctxDecoration, showCreate)


function ctxDecoration(ctx, next) {
    ctx.render = render;
    ctx.container = document.querySelector('.container');
    ctx.setNav = setUserNav;
    next();
}

function setUserNav() {
    if (sessionStorage.getItem('token')) {
        navigationGuest.style.display = 'none';
        navigationLogged.style.display = 'inline-block';
    } else {
        navigationGuest.style.display = 'inline-block';
        navigationLogged.style.display = 'none';
    }
}

async function logOut(ev){
    ev.preventDefault();
    await logout();
    page.redirect('/');
}

page.start();
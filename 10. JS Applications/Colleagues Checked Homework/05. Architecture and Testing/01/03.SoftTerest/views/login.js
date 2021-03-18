import {login} from '../src/api/data.js'

export function setupLogin(section, navigation){
    return showLogin;

    async function showLogin(){
        section.querySelector('form').addEventListener('submit', submitLoginForm)
        return section;
    }

    async function submitLoginForm(e){
        e.preventDefault();
            const formData = new FormData(e.target);
            const email = formData.get('email');
            const password = formData.get('password');

            if (!email || !password) {
                return alert('All fields are required!')
            }
            await login(email, password);
            navigation.setUserNav();
            navigation.loadPage('home');
            e.target.reset();
    }
}
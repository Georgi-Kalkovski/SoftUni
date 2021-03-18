import {register} from '../src/api/data.js'

export function setupRegister(section, navigation){
    return showRegister;

    async function showRegister(){
        section.querySelector('form').addEventListener('submit', reg)
        return section;
    }

    async function reg(e){
        e.preventDefault();
            const formData = new FormData(e.target);
            const email = formData.get('email');
            const password = formData.get('password');
            const repass = formData.get('repeatPassword');
            if (!email || !password || !repass) {
                return alert('All fields are required!')
            }

            if (password != repass) {
                return alert('Password and repass should be same!')
            }

            await register(email, password);
            navigation.setUserNav();
            navigation.loadPage('home');
            e.target.reset();
    }
}
import { settings, register } from "./api.js";

export { setupRegister }


function setupRegister(section, navigation) {
    const form = section.querySelector('form');
    form.addEventListener('submit', async (ev) => {
        ev.preventDefault();

        const data = [...new FormData(form).entries()].reduce((acc, [k, v]) => {
            acc[k] = v;
            return acc;
        }, {});

        if (data.email.length < 3) {
            return alert('Email should be at least 3 characters long!');
        }
        if (data.password.length < 3) {
            return alert('Password should be at least 3 characters long!');
        }
        if (data.password !== data.repeatPassword) {
            return alert('Passwords don\'t match!');
        }

        await register(data.email, data.password);
        navigation.setNav();
        navigation.goTo('home');
    });

    settings.host = 'http://localhost:3030';
    return showRegister;

    function showRegister() {
        return section;
    }
}

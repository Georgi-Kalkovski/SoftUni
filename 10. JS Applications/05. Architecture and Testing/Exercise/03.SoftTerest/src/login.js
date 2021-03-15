import { settings, login } from "./api.js";

export { setupLogin }


function setupLogin(section, navigation) {
    const form = section.querySelector('form');
    form.addEventListener('submit', async (ev) => {
        ev.preventDefault();

        const data = [...new FormData(form).entries()].reduce((acc, [k, v]) => {
            acc[k] = v;
            return acc;
        }, {});

        await login(data.email, data.password);
        navigation.setNav();
        navigation.goTo('home');
    });
    settings.host = 'http://localhost:3030';
    return showLogin;

    function showLogin() {
        return section;
    }
}

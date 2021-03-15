import { post } from "./api.js";

export { setupCreate }

function setupCreate(section, navigation) {
    const form = section.querySelector('form');

    form.addEventListener('submit', async (ev) => {
        ev.preventDefault();

        const data = [...new FormData(form).entries()].reduce((acc, [k, v]) => {
            acc[k] = v;
            return acc;
        }, {});

        await post('http://localhost:3030/data/ideas', data);
        form.reset();
        navigation.setNav();
        navigation.goTo('dashboard');
    });
    return showCreate;

    async function showCreate() {
        return section;
    }
}

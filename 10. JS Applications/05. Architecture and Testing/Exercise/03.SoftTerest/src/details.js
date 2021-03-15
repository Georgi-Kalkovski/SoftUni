import { del, get } from "./api.js";

export { setupDetails }

function setupDetails(section, navigation) {
    return showDetails;

    async function showDetails(id) {
        const url = 'http://localhost:3030/data/ideas/' + id;
        const idea = await get(url);
        section.innerHTML = createCard(idea);
        
        if (idea._ownerId === sessionStorage.getItem('userId')) {
            section.innerHTML += createBtn(idea);

            section.querySelector('.btn.detb').addEventListener('click', async (ev) => {
                ev.preventDefault();

                const confirmation = confirm('Are you sure you want to delete this recipe?');
                
                if (!confirmation) {
                    return;
                }
                await del(' http://localhost:3030/data/ideas/' + ev.target.id);
                navigation.goTo('dashboard');
            })

        }
        return section;
    }
}

function createCard(idea) {
    return ` <img class="det-img" src=${idea.img}>
        <div class="desc">
            <h2 class="display-5">${idea.title}</h2>
            <p class="infoType">Description:</p>
            <p class="idea-description">${idea.description}</p>
        </div>`;
}

function createBtn(idea) {
    return `<div class="text-center">
        <a id=${idea._id} class="btn detb" href="">Delete</a>
    </div>`;
}

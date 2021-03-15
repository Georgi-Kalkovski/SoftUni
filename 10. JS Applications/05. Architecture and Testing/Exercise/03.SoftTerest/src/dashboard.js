import { get } from "./api.js";

export { setupDashboard }

function setupDashboard(section, navigation) {
    section.addEventListener('click', (ev) => {

        if (ev.target.className === 'btn') {
            ev.preventDefault();

            navigation.goTo('details', ev.target.id);
        }
    })

    return showDashboard;

    async function showDashboard() {
        const url = ' http://localhost:3030/data/ideas?select=_id%2Ctitle%2Cimg&sortBy=_createdOn%20desc';
        const ideas = await get(url);

        if (ideas.length === 0) {
            section.innerHTML = '<h1>No ideas yet! Be the first one :)</h1>';
        } else {
            section.innerHTML = ideas.map(createCard).join('');
        }
        return section;
    }
}

function createCard(card) {
    return `<div class="card overflow-hidden current-card details" style="width: 20rem; height: 18rem;">
            <div class="card-body">
                <p class="card-text">${card.title}</p>
            </div>
            <img class="card-image" src=${card.img} alt="Card image cap">
            <a id=${card._id} class="btn" href="">Details</a>
        </div>`;
}

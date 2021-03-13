import {showDetails} from './details.js';

async function getMovies() {
    const response = await fetch('http://localhost:3030/data/movies');
    const movies = await response.json();
    return movies;
}

function createMoviePreview(movie) {
    const element = document.createElement('div');
    element.classList.add("card.mb-4");
    element.innerHTML = `<img class="card-img-top" src="${movie.img}"
         alt="Card image cap" width="400">
    <div class="card-body">
        <h4 class="card-title">${movie.title}</h4>
    </div>
    <div class="card-footer">
            <button id=${movie._id} type="button" class="btn btn-info movieDetailsLink">Details</button>
       
    </div>`

return element;

}

let main;
let section;
let container;

function setupHome(mainTarged, sectionTarget) {
    main = mainTarged;
    section = sectionTarget;
    container = section.querySelector(".card-deck.d-flex.justify-content-center");

    container.addEventListener('click', (event) => {
        if (event.target.classList.contains('movieDetailsLink')) {
           showDetails(event.target.id)
        }
    })
}

async function showHome() {
    container.innerHTML = 'Loading&hellip;';
    main.innerHTML = "";
    main.appendChild(section);

    const movies = await getMovies();
    const cards = movies.map(createMoviePreview);
    const fragment = document.createDocumentFragment();
    cards.forEach(e => fragment.append(e));
    container.innerHTML = "";
    container.appendChild(fragment);
}

export {
    setupHome,
    showHome
}
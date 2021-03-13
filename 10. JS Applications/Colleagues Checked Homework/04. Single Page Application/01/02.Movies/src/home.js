import { displayDetails } from './details.js';
import {e} from './externalFunctions.js';

async function getMovies() {
    const response = await fetch('http://localhost:3030/data/movies');

    if (response.ok == false) {
        const error = await response.json();;
        return alert(error.message);
    }

    const data = await response.json();

    return data;
}

function createMoviePreview(movie) {
    const card = e('div', {className : 'card mb-4'}, 
        e('img', {className : 'card-img-top', src: movie.img, alt: 'Card image cap', width: '400'}),
        e('div', {className: 'card-body'}, e('h4', {className: 'card-title'}, movie.title)),
        e('div', {className : 'card-footer'},e('button', {id : movie._id, className: 'btn btn-info movieDetailsLink'}, 'Details'))
    );

    return card;
}

let main;
let section;
let container;

export function setupHome(mainTarget, sectionTarget) {
    main = mainTarget;
    section = sectionTarget;
    container = section.querySelector('.card-deck.d-flex.justify-content-center');

    container.addEventListener('click', (ev) => {
        if (ev.target.classList.contains('movieDetailsLink')) {
            displayDetails(ev.target.id)
        };
    })
}

export async function displayHome() {
    const token = sessionStorage.getItem('token');
    if (token == null) {
        section.querySelector('#createLink').style.display = 'none';
    } else {
        section.querySelector('#createLink').style.display = '';
    }
    container.innerHTML = 'Loading...'
    main.innerHTML = '';
    main.appendChild(section);
    const movies = await getMovies();
    container.innerHTML = '';
    movies.forEach(movie => {
        const card = createMoviePreview(movie);
        container.appendChild(card);
    })
}

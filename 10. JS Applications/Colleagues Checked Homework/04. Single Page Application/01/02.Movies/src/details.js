import { displayEdit } from './edit.js';
import { e } from './externalFunctions.js';
import { displayHome } from './home.js';

async function getLikes(id) {
    const response = await fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${id}%22&distinct=_ownerId&count`);
    const likes = await response.json();

    return likes;
}

async function getOwnLikes(id) {
    const userId = sessionStorage.getItem('ownerId');
    const response = await fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${id}%22%20and%20_ownerId%3D%22${userId}%22`);
    const likes = await response.json();

    return likes;
}

async function getMovie(id) {
    const response = await fetch(`http://localhost:3030/data/movies/${id}`);
    const movie = await response.json();

    return movie;
}

async function onDelete(e, id) {
    e.preventDefault();

    const confirmed = confirm('Are you sure?');

    if (confirmed) {
        const response = await fetch(`http://localhost:3030/data/movies/${id}`,{
            method: 'delete',
            headers: { 'X-authorization' : sessionStorage.getItem('token')}
        });

        if (response.ok) {
            displayHome();
        } else {
            const error = await response.json();
            alert(error.message);
        }
    }
}

function createMovieCard(movie, likes, ownLike) {
    const ownerId = sessionStorage.getItem('ownerId');
    let controls = [];
    if (ownerId != null) {
        if (ownerId == movie._ownerId) {
            const deleteBtn = e('a', { className: 'btn btn-danger', href: '#', onclick: (e) => onDelete(e, movie._id) }, 'Delete');
            const editBtn = e('a', { className: 'btn btn-warning', href: '#', onclick: (e) => displayEdit(movie._id) }, 'Edit');
            controls.push(deleteBtn);
            controls.push(editBtn);
        } else {
            if (ownLike.length == 0) {
                const likeBtn = e('a', { className: 'btn btn-primary', href: '#', onclick: likeMovie }, 'LIke');
                controls.push(likeBtn);
            }
        }
    };
    const likesSpan = e('span', { className: 'enrolled-span' }, likes + ' like' + (likes == 1 ? '' : 's'))
    controls.push(likesSpan);

    const card = e('div', { className: 'container' },
        e('div', { className: 'row bg-light text-dark' },
            e('h1', {}, `Movie title: ${movie.title}`),
            e('div', { className: 'col-md-8' }, e('img', { className: 'img-thumbnail', src: movie.img, alt: 'Movie' })),
            e('div', { className: 'col-md-4 text-center' },
                e('h3', { className: 'my-3 ' }, 'Movie Description'),
                e('p', {}, movie.description),
                ...controls
            )
        )
    )

    return card;

    async function likeMovie(event) {
        const response = await fetch('http://localhost:3030/data/likes', {
            method: 'post',
            headers: {
                'Content-Type': 'application/json',
                'X-authorization': sessionStorage.getItem('token')
            },
            body: JSON.stringify({ movieId: movie._id })
        });

        if (response.ok) {
            event.target.remove();
            likes++;
            likesSpan.textContent = likes + ' like' + (likes == 1 ? '' : 's')
        }
    }
};

let main;
let section;

export function setupDetails(mainTarget, sectionTarget) {
    main = mainTarget;
    section = sectionTarget;
}

export async function displayDetails(id) {
    section.innerHTML = '';
    main.innerHTML = '';
    main.appendChild(section);
    const [movie, likes, ownLike] = await Promise.all([
        getMovie(id),
        getLikes(id),
        getOwnLikes(id)
    ]);
    const card = createMovieCard(movie, likes, ownLike);
    section.appendChild(card);
}
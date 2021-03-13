import { showDetails } from './details.js';


async function getMovieById(id) {
    const response = await fetch('http://localhost:3030/data/movies/' + id);
    const data = await response.json();

    return data;
}

let main;
let section;
let movieId;

export function setupEdit(targetMain, targetSection) {
    main = targetMain;
    section = targetSection;
    const form = targetSection.querySelector('form');

    form.addEventListener('submit', (ev => {
        ev.preventDefault();
        new FormData(ev.target);
    }));

    form.addEventListener('formdata', (ev => {
        onSubmit([...ev.formData.entries()].reduce((p, [k, v]) => Object.assign(p, { [k]: v }), {}));
    }));

    async function onSubmit(movie) {
        const body = JSON.stringify({
            description: movie.description,
            img: movie.img,
            title: movie.title
        });

        const token = sessionStorage.getItem('authToken');
        if (token == null) {
            return alert('You\'re not logged in!');
        }

        try {
            const response = await fetch('http://localhost:3030/data/movies/' + movieId, {
                method: 'put',
                headers: {
                    'Content-Type': 'application/json',
                    'X-Authorization': token
                },
                body
            });

            if (response.status == 200) {
                showDetails(movieId);
            } else {
                const error = await response.json();
                throw new Error(error.message);
            }
        } catch (err) {
            alert(err.message);
            console.error(err.message);
        }
    }
}


export async function showEdit(id) {

    main.innerHTML = '';
    main.appendChild(section);

    movieId = id;
    const movie = await getMovieById(movieId);

    section.querySelector('[name="title"]').value = movie.title;
    section.querySelector('[name="imageUrl"]').value = movie.img;
    section.querySelector('[name="description"]').value = movie.description;
}
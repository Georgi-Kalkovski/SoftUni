import { displayDetails } from "./details.js";

async function onSubmit(ev, id) {
    ev.preventDefault();

    const formData = new FormData(ev.target);
    const title = formData.get('title');
    const description = formData.get('description');
    const img = formData.get('imageUrl');

    if (title == '' || description == '' || img == '') {
        return alert('All fields are required!');
    }

    const response = await fetch(`http://localhost:3030/data/movies/${id}`, {
        method: 'put',
        headers: {
            'Content-Type' : 'application/json',
            'X-authorization' : sessionStorage.getItem('token')
        },
        body : JSON.stringify({title, description, img})
    });

    if (response.ok) {
        const data = await response.json()
        displayDetails(data._id);
    } else {
        const error = await response.json();
        alert(error.message);
    }
}

async function getMovie(id) {
    const response = await fetch(`http://localhost:3030/data/movies/${id}`);
    const movie = await response.json();

    return movie;
}

let main;
let section;

export function setupEdit(mainTarget, sectionTarget) {
    main = mainTarget;
    section = sectionTarget;
}

export async function displayEdit(id) {
    main.innerHTML = '';
    main.appendChild(section);
    const movie = await getMovie(id);
    section.querySelector('input[name="title"]').value = movie.title;
    section.querySelector('textarea[name="description"]').value = movie.description;
    section.querySelector('input[name="imageUrl"]').value = movie.img;

    const form = section.querySelector('form');
    form.addEventListener('submit', (e) => onSubmit(e, id));
}
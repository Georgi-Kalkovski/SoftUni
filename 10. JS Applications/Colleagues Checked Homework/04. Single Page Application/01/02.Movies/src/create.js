import { displayDetails } from "./details.js";

async function onSubmit(ev) {
    ev.preventDefault();

    const formData = new FormData(ev.target);
    const title = formData.get('title');
    const description = formData.get('description');
    const img = formData.get('imageUrl');

    if (title == '' || description == '' || img == '') {
        return alert('All fields are required!');
    }

    const response = await fetch('http://localhost:3030/data/movies', {
        method: 'post',
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

let main;
let section;

export function setupCreate(mainTarget, sectionTarget) {
    main = mainTarget;
    section = sectionTarget;
}

export async function displayCreate() {
    main.innerHTML = '';
    main.appendChild(section);

    const form = section.querySelector('form');
    form.addEventListener('submit', onSubmit);
}
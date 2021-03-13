import {showDetails} from './details.js';
import { e } from './dom.js';
let main;
let section;

async function onSubmit(event) {
    event.preventDefault();
    const formData = new FormData(event.target);
    const movie = {
        title: formData.get('title'),
        description: formData.get('description'),
        img: formData.get('imageUrl')
    }
    if (movie.title === "" || movie.description === "" || movie.img === "") {
        return alert('All fields are required!');
    }

    const response = await fetch('http://localhost:3030/data/movies', {
        method: 'POST',
        headers: {"Content-Type": 'application/json', "X-Authorization": sessionStorage.getItem('authToken')},
        body: JSON.stringify(movie),
    });

    if (response.ok) {
        const data = await response.json();
        
        await showDetails(data._id);
    } else {
        const error = await response.json();
        return alert(error.message);
    }

}

function setupCreate(mainTarged, sectionTarget) {
    main = mainTarged;
    section = sectionTarget;
}

async function showCreate() {
    main.innerHTML = "";
    main.appendChild(section);
    const form = section.querySelector('form');
    form.addEventListener('submit', onSubmit);
}

export {
    setupCreate,
    showCreate
}

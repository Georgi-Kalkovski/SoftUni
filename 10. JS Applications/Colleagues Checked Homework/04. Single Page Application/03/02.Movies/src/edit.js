import {showDetails} from './details.js';
let main;
let section;

function setupEdit(mainTarged, sectionTarget) {
    main = mainTarged;
    section = sectionTarget;
}

async function onSubmit(event, id) {
    event.preventDefault();
    const data = new FormData(event.target);
    const title = data.get('title');
    const description = data.get('description');
    const imageUrl = data.get('imageUrl');
    if (title === "" || description === "" || imageUrl === "") {
        event.target.reset();
        return alert('All fields are required!');
    }
    const response = await fetch('http://localhost:3030/data/movies/' + id, {
        method: "PUT",
        headers: {'Content-Type': 'application/json', "X-Authorization": sessionStorage.getItem("authToken")},
        body: JSON.stringify({title, description, imageUrl})
    })
    event.target.reset();
    if (!response.ok) {
        const error = await response.json();
        return alert(error.message);
    }else {
        
        await showDetails(id)
        
    }
    
    

}

async function showEdit(id) {
    main.innerHTML = "";
    main.appendChild(section);
    section.querySelector('form').addEventListener('submit', (e) => onSubmit(e , id));
}

export {
    setupEdit,
    showEdit
}

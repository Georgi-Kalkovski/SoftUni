import { e } from './externalFunctions.js';

async function getAllComments() {
    const response = await fetch('http://localhost:3030/jsonstore/collections/myboard/comments');

    if (response.ok == false) {
        const error = await response.json();;
        return alert(error.message);
    }

    const comments = await response.json();

    return comments;
}

let main;
let section;

export function setupTopicContent(mainTarget, sectionTarget) {
    main = mainTarget;
    section = sectionTarget;
}

export async function displayTopicContent() {
    main.innerHTML = '';
    main.appendChild(section);

}
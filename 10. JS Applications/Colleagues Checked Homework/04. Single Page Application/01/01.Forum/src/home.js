import { e } from './externalFunctions.js';
import { displayTopicContent } from './topic-content.js';

async function getAllTopics() {
    const response = await fetch('http://localhost:3030/jsonstore/collections/myboard/posts');

    if (response.ok == false) {
        const error = await response.json();;
        return alert(error.message);
    }

    const topics = await response.json();

    return topics;
}

function createTopicPreview(topic) {
    const newTopic = e('div', { className: 'topic-container' },
        e('div', { className: 'topic-name-wrapper' },
            e('div', { className: 'topic-name' },
                e('a', { href: '#', className: 'normal', onclick : (e) => displayTopicContent(e)}, e('h2', {}, topic.topicName)),
                e('div', { className: 'columns' },
                    e('div', {},
                        e('p', {}, 'Date: 2020-10-10T12:08:28.451Z'),
                        e('div', { className: 'nick-name' }, e('p', {}, `Username: ${topic.username}`))
                    ),
                    e('div', { className: 'subscribers' }, e('p', {}, `Subscribers: 456`)
                    )
                )
            )
        )
    );
    return newTopic;
}

async function onSubmit(ev) {
    ev.preventDefault();
    if (ev.submitter.id != 'cancelBtn') {
        const formData = new FormData(ev.target);
        const topicName = formData.get('topicName');
        const username = formData.get('username');
        const topicContent = formData.get('postText');

        if (topicName == '' || username == '' || topicContent == '') {
            return alert('All fields are required!');
        }

        const response = await fetch('http://localhost:3030/jsonstore/collections/myboard/posts', {
            method: 'post',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ topicName, username, topicContent })
        });

        if (response.ok) {
            ev.target.reset();
            displayHome();
        } else {
            const error = await response.json();
            alert(error.message);
        }
    }
}

let main;
let section;
let topicContainer;

export function setupHome(mainTarget, sectionTarget) {
    main = mainTarget;
    section = sectionTarget;
    topicContainer = section.querySelector('.topic-title');
}

export async function displayHome() {
    main.innerHTML = '';
    main.appendChild(section);

    const form = section.querySelector('form');
    section.querySelector('#cancelBtn').addEventListener('click', e => {
        form.reset();
    });
    form.addEventListener('submit', onSubmit);

    const topics = await getAllTopics();
    topicContainer.innerHTML = '';
    Object.values(topics).forEach(topic => {
        const topicPreview = createTopicPreview(topic);
        topicContainer.appendChild(topicPreview);
    })
}
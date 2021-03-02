function attachEvents() {
    let loadBtn = document.getElementById('btnLoadPosts');
    let veiwBtn = document.getElementById('btnViewPost');
    
    loadBtn.addEventListener('click', load);
    veiwBtn.addEventListener('click', view);
}

async function load() {
    const posts = document.getElementById('posts');
    posts.innerHTML = '';
    const urlPosts = 'http://localhost:3030/jsonstore/blog/posts';
    const dataPosts = await data(urlPosts);

    for (const key in dataPosts) {
        const option = e('option', dataPosts[key].title, key);
        posts.appendChild(option);
    }
}

async function view() {
    const posts = document.getElementById('posts');
    const id = posts.options[posts.selectedIndex].value;
    const urlPost = 'http://localhost:3030/jsonstore/blog/posts/'+ id;
    const dataPosts = await data(urlPost);
    const urlComments = 'http://localhost:3030/jsonstore/blog/comments';
    const dataComments = await data(urlComments);

    const commetns = [];

    for (const key in dataComments) {
        if (dataComments[key].postId === id) {
            commetns.push(dataComments[key].text);
        }
    }
    
    document.getElementById('post-title').textContent = '';
    document.getElementById('post-body').textContent = '';
    document.getElementById('post-comments').innerHTML = '';

    document.getElementById('post-title').textContent = dataPosts.title;
    document.getElementById('post-body').textContent = dataPosts.body;

    const ul = document.getElementById('post-comments');

    for (const element of commetns) {
        const li = e('li', element);
        ul.appendChild(li);
    }

}

async function data(url) {
    const response = await fetch(url);
    const data = await response.json();
    return data;
}

function e(type, text, val) {

    const element = document.createElement(type);

    if (text) {
        element.textContent = text;
    }
    if (val) {
        element.value = val;
    }
    return element;
}

attachEvents();
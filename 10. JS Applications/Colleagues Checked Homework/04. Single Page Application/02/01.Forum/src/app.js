function addEvents() {
    document.getElementsByClassName('public')[0].addEventListener('click', publicClick);
    document.getElementsByClassName('cancel')[0].addEventListener('click', onCancel);

}
addEvents()
async function allPosts() {
    const response = await fetch('http://localhost:3030/jsonstore/collections/myboard/posts', {
        method: 'get',
        headers: { 'Content-Type': 'aplication/json' }
    });

    if (response.ok != true) {
        const error = await response.json();
        return alert(error.message);
    }
    const data = await response.json();
    Object.values(data).map(({_id, title: topicName, username}) => createTopic({_id, topicName, username }));
}
allPosts();
async function publicClick(event) {
    event.preventDefault();
    const topicName = document.getElementById('topicName').value;
    const username = document.getElementById('username').value;
    const postText = document.getElementById('postText').value;

    const response = await fetch('http://localhost:3030/jsonstore/collections/myboard/posts', {
        method: 'post',
        headers: { 'Content-Type': 'aplication/json' },
        body: JSON.stringify({
            title: topicName,
            username: username,
            post: postText
        })
    });

    if (response.ok != true) {
        const error = await response.json();
        return alert(error.message);
    }
    const {_id} = await response.json()
    createTopic({_id, topicName, username });
}
async function createTopic({_id, topicName, username }) {
    const newPost = `
    <div class="topic-container">
        <div class="topic-name-wrapper">
            <div class="topic-name">
                <a href="./theme-content.html?id=${_id}" class="normal">
                    <h2>${topicName}</h2>
                </a>
                <div class="columns">
                    <div>
                        <p>Date: <time>2020-10-10T12:08:28.451Z</time></p>
                        <div class="nick-name">
                            <p>Username: <span>${username}</span></p>
                        </div>
                    </div>
                    <div class="subscribers">
                        <p>Subscribers: <span>456</span></p>
                    </div>
                </div>
            </div>
        </div>
    </div>`;
    document.getElementsByClassName('topic-title')[0].innerHTML += newPost;
    onCancel();
}

function onCancel() {
    document.getElementById('topicName').value = '';
    document.getElementById('username').value = '';
    document.getElementById('postText').value = '';
}


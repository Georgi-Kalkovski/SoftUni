import { showPost, setupPost, addComment } from './post.js';

const newTopicDiv = document.querySelector('.container .new-topic-border');
let form = document.querySelector('.container form');
let topics = document.querySelector('.topic-title');
let cancelBtn = document.querySelector('.container form .cancel');

setupPost(topics, '');

cancelBtn.addEventListener('click', (event) => {
    event.preventDefault();
    if (event.target.className == 'cancel') {
        clearFields();
        return;
    }
});

form.addEventListener('submit', async (event) => {
    event.preventDefault();

    let former = document.querySelector('.container form');
    let formData = new FormData(former);
    let topicName = formData.get('topicName');
    let username = formData.get('username');
    let postText = formData.get('postText');
    let date = new Date();
    let subscribes = '0';
    let post = { topicName, username, postText, date, subscribes };
    let valid = true;

    Object.values(post).forEach(element => {
        if (element == '') {
            valid = false;
        }
    });

    if (valid) {
        let result = await addPost(post);
        if (result.hasOwnProperty('_id')) {
            // clear fields
            clearFields();
            let posts = await getPosts();
            renderPosts(posts);
        } else {
            alert('Server error!');
        }
    } else {
        return alert(`All fields are required!`);
    }
});

topics.addEventListener('click', async (event) => {
    event.preventDefault();

    if (event.target.tagName == 'H2') {
        newTopicDiv.style.display = 'none';
        let id = event.target.parentNode.querySelector('input').value; ///
        showPost(id);
    } else if (event.target.tagName == 'BUTTON') {
        let commentForm = document.querySelector('.answer-comment form');
        let formData = new FormData(commentForm);
        let postText = formData.get('postText');
        let username = formData.get('username');
        let postId = formData.get('postId');
        let id = postId;
        let date = new Date();

        if (postText != '' && username != '') {
            let newComment = { username, postText, date, postId };
            let result = await addComment(newComment);
        }

        showPost(id);
    }
});

function clearFields() {
    let former = document.querySelector('.container form');
    let fields = former.querySelectorAll('input');
    let textArea = former.querySelector('textarea');
    fields.forEach(field => {
        field.value = '';
    });
    
    textArea.value = '';
}

async function addPost(postData) {
    const result = await request('http://localhost:3030/jsonstore/collections/myboard/posts', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(postData)
    });
    return result;
}

async function getPosts(postData) {
    const result = await request('http://localhost:3030/jsonstore/collections/myboard/posts');
    return result;
}

function renderPosts(posts) {
    let container = document.querySelector('.topic-title');

    Object.keys(posts).forEach(post => {
        let postHTML = `                
        <div class="topic-container">
        <div class="topic-name-wrapper">
            <div class="topic-name">
                <a href="#" class="normal">
                    <h2>${posts[post].topicName}</h2>
                    <input type="hidden" name="id" value="${posts[post]._id}">
                </a>
                <div class="columns">
                    <div>
                        <p>Date: <time>${posts[post].date}</time></p>
                        <div class="nick-name">
                            <p>Username: <span>${posts[post].username}</span></p>
                        </div>
                    </div>
                    <div class="subscribers">
                        <p>Subscribers: <span>${posts[post].subscribes}</span></p>
                    </div>
                </div>
            </div>
        </div>
    </div>`;
        container.innerHTML += postHTML;
    });
}

async function request(url, options) {
    const response = await fetch(url, options);
    if (response.ok == false) {
        const error = await response.json();
        alert(error.message);
        throw new Error(error.message);
    }
    const data = await response.json();
    return data;
}

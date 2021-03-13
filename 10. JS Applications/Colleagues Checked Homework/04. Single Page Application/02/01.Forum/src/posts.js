async function loadPost() {
    const id = (new URLSearchParams(window.location.search)).get('id');
    // get content from server
    const content = await fetch('http://localhost:3030/jsonstore/collections/myboard/posts/' + id, {
        method: 'get',
        headers: { 'Content-Type': 'aplication/json' }
    });

    if (content.ok != true) {
        const error = await content.json();
        return alert(error.message);
    }
    const { title, username, post } = await content.json();
    let postHtml = `
    <div class="theme-title">
                <div class="theme-name-wrapper">
                    <div class="theme-name">
                        <h2>${title}</h2>
                        <p>Date: <time>2020-10-10 12:08:28</time></p>
                    </div>
                    <div class="subscribers">
                        <p>Subscribers: <span>456</span></p>
                    </div>
                </div>
            </div>
            <div class="comment">
                <header class="header">
                    <p><span>${username}</span> posted on <time>2020-10-10 12:08:28</time></p>
                </header>
                <div class="comment-main">
                    <div class="userdetails">
                        <img src="./static/profile.png" alt="avatar">
                    </div>
                    <div class="post-content">${post}</div>
                </div>
                <div class="footer">
                    <p><span>5</span> likes</p>
                </div>
            </div>`
    // get comments from server
    const comments = await fetch('http://localhost:3030/jsonstore/collections/myboard/comments/' + id);
    if (comments.ok != true) {
        const error = await comments.json();
        return alert(error.message);
    }
    let contentComments;
    try{
        contentComments = await comments.json();
    } catch (error) {
        contentComments = {};
    }
    Object.values(contentComments).forEach(({ username, comment }) => {
        postHtml += `<div class="comment">
        <header class="header">
        <p><span>${username}</span> posted on <time>2020-10-10 14:28:11</time></p>
        </header>
        <div class="comment-main">
        <div class="userdetails">
        <img src="./static/profile.png" alt="avatar">
        </div>
        <div class="post-content">${comment}</div>
        </div>
        <div class="footer">
        <p><span>3</span> likes</p>
        </div>
        </div>`
    });
    postHtml += ` 
    <div class="answer-comment">
    <p><span>currentUser</span> comment:</p>
    <div class="answer">
    <form>
    <textarea name="postText" id="comment" cols="30" rows="10"></textarea>
    <div>
    <label for="username">Username <span class="red">*</span></label>
    <input type="text" name="username" id="username">
    </div>
    <button id="postBtn">Post</button>
    </form>
    </div>
    </div>`;
    document.getElementsByClassName('theme-content')[0].innerHTML = postHtml;
    document.getElementById('postBtn').addEventListener('click', createPost)

    async function createPost(event) {
        event.preventDefault();
        const user = document.getElementById('username').value;
        const com = document.getElementById('comment').value;

        const response = await fetch('http://localhost:3030/jsonstore/collections/myboard/comments/' + id, {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ username: user, comment: com })
        });
        loadPost();
    }
}
loadPost();

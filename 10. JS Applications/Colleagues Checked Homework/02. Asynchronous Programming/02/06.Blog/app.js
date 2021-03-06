// the whole app is done as it was in the live exercise

function attachEvents() {
    document.getElementById("btnLoadPosts").addEventListener('click', getPosts);
    document.getElementById("btnViewPost").addEventListener('click', displayPost)
}

attachEvents();

async function getPosts() {
    const select = document.getElementById("posts");
    select.innerHTML = ''
    const url = 'http://localhost:3030/jsonstore/blog/posts';

    const response = await fetch(url);
    const data = await response.json();


    Object.values(data).map(createOptions).forEach(option => select.appendChild(option));
}

function createOptions(post) {
    const result = document.createElement("option");
    result.textContent = post.title;
    result.value = post.id

    return result
}

function displayPost() {
    const postId = document.getElementById('posts').value;
    getComments(postId);
}

async function getComments(id) {
    const commentsUl = document.getElementById('post-comments');
    commentsUl.innerHTML = '';

    const [postResponse, commentsResponse] = await Promise.all([
        fetch('http://localhost:3030/jsonstore/blog/posts/' + id),
        fetch('http://localhost:3030/jsonstore/blog/comments')
    ]);

    const postData = await postResponse.json();

    document.getElementById('post-title').textContent = postData.title;
    document.getElementById('post-body').textContent = postData.body;
    console.log(commentsResponse)
    const commentsData = await commentsResponse.json();
    const comments = Object.values(commentsData).filter(c => c.postId === id);

    comments.map(createComment).forEach(c => commentsUl.appendChild(c));
}

function createComment(com) {
    const result = document.createElement('li');
    result.textContent = com.text;
    return result
}

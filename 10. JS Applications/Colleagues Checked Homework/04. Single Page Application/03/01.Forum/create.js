let sec;
let doc;
async function showPosts(sectionTarget, documentTarget) {
    sec = sectionTarget;
    doc = documentTarget;
    const response = await fetch('http://localhost:3030/jsonstore/collections/myboard/posts');
    const data = await response.json();
    const posts = Object.values(data).map(createPost).join('');
    sectionTarget.innerHTML = posts;
    documentTarget.appendChild(sectionTarget);
}
 
 async function setUpCreate(form, section) {
    form.addEventListener('click', async (event) => {
        event.preventDefault();
        if (event.target.classList.contains('cancel')) {
            form.reset();
        } else if (event.target.classList.contains('public')) {
            const topicName = document.getElementById('topicName').value;
            const username = document.getElementById('username').value;
            const text = document.getElementById('postText').value;
           const response = await fetch('http://localhost:3030/jsonstore/collections/myboard/posts', {
                method: 'post',
                headers: {"Content-Type": "application/json"},
                body: JSON.stringify({"topicName":topicName,"username": username, "postText": text}),
            })
            form.reset();
            showPosts(sec, doc);
        }
        
    })

    section.appendChild(form);
}




function createPost(data) {
    const format = `<div id='${data._id}' class="topic-container">
    <div class="topic-name-wrapper">
        <div class="topic-name">
            <a href="#" class="normal">
                <h2>${data.topicName}</h2>
            </a>
            <div class="columns">
                <div>
                    <p>Date: <time>2020-04-10T15:08:28.431Z</time></p>
                    <div class="nick-name">
                        <p>Username: <span>${data.username}</span></p>
                    </div>
                </div>
                <div class="subscribers">
                    <p>Subscribers: <span>123</span></p>
                </div>
            </div>
        </div>
    </div>
</div>`
return format;
}

export {
    setUpCreate,
    showPosts
}
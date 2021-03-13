 function commentFunction(section, container,post,commentSection) {
    section.addEventListener('click', async (event) => {
        let article = event.target.parentNode;
        while (!article.classList.contains('topic-container')) {
            article = article.parentNode;
        }
        const id = article.id;
       container.innerHTML = "";
       
      
       post.style.display = 'block';
       container.appendChild(article);
    getComments(id,commentSection);
       container.appendChild(commentSection);
       container.appendChild(post)
       const form = post.querySelector('form');
       form.addEventListener('submit', async (event) => {
           event.preventDefault();
           const formData = new FormData(event.target);
           const text = formData.get('postText');
           const username = formData.get('username');
           const response = await fetch('http://localhost:3030/jsonstore/collections/myboard/comments', {
               method: 'post',
               headers: {'Content-Type': "application/json"},
               body: JSON.stringify({'ownerID': id, "postText": text, "username": username})
           })
           event.target.reset();
    getComments(id,commentSection);
       
       })
       

    })
}

async function getComments(ownerId,commentSection) {
    const response = await fetch('http://localhost:3030/jsonstore/collections/myboard/comments');
    const data = await response.json();
    let comments = Object.values(data).filter(e=> e.ownerID === ownerId).map(shapeComments).join('');
    commentSection.innerHTML =  comments;
}

function shapeComments(element) {
    const result = `<div class="comment">
    <header class="header">
        <p><span>${element.username}</span> posted on <time>2020-10-10 14:28:11</time></p>
    </header>
    <div class="comment-main">
        <div class="userdetails">
            <img src="./static/profile.png" alt="avatar">
        </div>
        <div class="post-content">
            <p>${element.postText}</p>
        </div>
    </div>
    <div class="footer">
        <p><span>3</span> likes</p>
    </div>
</div>`
return result;
}

export {
    commentFunction
}
function attachEvents() {
    const [btnLoadPosts, btnViewPosts] = 
        document.getElementsByTagName('button');

    btnLoadPosts.addEventListener('click', getPostsResponse);
    btnViewPosts.addEventListener('click', getCommentsResponse);


    async function getPostsResponse() {
        const response = await fetch('http://localhost:3030/jsonstore/blog/posts');
        const data = await response.json();
        const postsBody = document.getElementById('posts');

        Object.values(data).forEach(prop => {
            const optionTag = document.createElement('option');
            optionTag.value = prop.id;
            optionTag.textContent = prop.title;

            postsBody.appendChild(optionTag);
        });
    }

    async function getCommentsResponse(event) {
        const options = event.target.previousElementSibling;
        if (!options.children.length) return;

        const commentsResponse = await fetch('http://localhost:3030/jsonstore/blog/comments');
        const commentsData = await commentsResponse.json();

        const postResponse = await fetch('http://localhost:3030/jsonstore/blog/posts/' + options.value);
        const postData = await postResponse.json();

        const postTitle = document.getElementById('post-title');
        const postBody = document.getElementById('post-body');
        const postComments = document.getElementById('post-comments');


        postTitle.textContent = '';
        postComments.innerHTML = '';
        for (const obj of Object.values(commentsData)) {
            if (obj.postId === options.value) {
                postTitle.textContent = postData.title;
                
                postBody.textContent = postData.body;
                
                const li = document.createElement('li');
                li.textContent = obj.text;
                postComments.appendChild(li);
            }
        }
    }
}

attachEvents();
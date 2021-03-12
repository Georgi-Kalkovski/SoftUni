
// import to post.js
export function createRow(post) {
    const element = `
      <div class="topic-container">
      <div class="topic-name-wrapper">
          <div class="topic-name">
              <a id="${post._id}" href="#" class="normal">
                  <h2>${post.topicName}</h2>
              </a>
              <div class="columns">
                  <div>
                      <p>Date: <time>2020-10-10T12:08:28.451Z</time></p>
                      <div class="nick-name">
                          <p>Username: <span>${post.username}</span></p>
                      </div>
                  </div>
                  <div class="subscribers">
                      <p>Subscribers: <span>456</span></p>
                  </div>
              </div>
          </div>
      </div>
      </div>`;
    return element;
}

// import to comment.js
export function createPage(topic, comments, id) {
    const element = `
    <div class="container" id="${id}">
    <!-- theme content  -->
    <div class="theme-content">
      <!-- theme-title  -->
      <div class="theme-title">
        <div class="theme-name-wrapper">
          <div class="theme-name">
            <h2>${topic.topicName}</h2>
            <p>Date: <time>2020-10-10 12:08:28</time></p>
          </div>
          <div class="subscribers">
            <p>Subscribers: <span>456</span></p>
          </div>
        </div>
      </div>
     ${comments}
        <div class="answer-comment">
          <p><span>currentUser</span> comment:</p>
          <div class="answer">
            <form id="commentCreate">
              <textarea
                name="postText"
                id="comment"
                cols="30"
                rows="10"
              ></textarea>
              <div>
                <label for="username">Username <span class="red">*</span></label>
                <input type="text" name="username" id="username" />
              </div>
              <button>Post</button>
            </form>
          </div>
        </div>
      </div>
      </div>`;
    return element;
}

// import to comment.js
export function createCommentRow(comment) {
    const element = `
      <div class="comment">
      <header class="header">
        <p>
          <span>${comment.username}</span> posted on <time>2020-10-10 12:08:28</time>
        </p>
      </header>
      <div class="comment-main">
        <div class="userdetails">
          <img src="./static/profile.png" alt="avatar" />
        </div>
        <div class="post-content">
         <p>
          ${comment.postText}
         </p>
        </div>
      </div>
      <div class="footer">
        <p><span>5</span> likes</p>
      </div>
      </div>`;
    return element;
}

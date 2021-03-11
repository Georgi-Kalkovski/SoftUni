import { getPostById } from "./post.js";
import {createPage, createCommentRow} from './dom.js';
import {commentCheck} from './nullCheck.js'

export async function createComment(e) {
  e.preventDefault();

  const formData = new FormData(e.target);
  const postText = formData.get("postText");
  const username = formData.get("username");

  commentCheck(username);

  const newComment = {
    postText,
    username,
    topicId: document.querySelector('div .container').id,
  };
  const response = await fetch("http://localhost:3030/jsonstore/collections/myboard/comments", {
    method: "post",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(newComment),
  });

  if (response.ok) {
    alert("Post successfully created");
  } else {
    const data = await response.json();
    return alert(data.message);
  }
  e.target.reset();
  showComments(document.querySelector('div .container').id);
}

export async function showComments(id) {
  const topic = await getPostById(id);
  const response = await fetch("http://localhost:3030/jsonstore/collections/myboard/comments");
  const data = await response.json();

  const comment = Object.values(data).filter(x => x.topicId == id).map(createCommentRow).join('');
  const view = createPage(topic, comment, id);

  document.getElementsByTagName("main")[0].innerHTML = "";
  document.getElementsByTagName("main")[0].innerHTML = view;
  document.getElementById("commentCreate").addEventListener("submit", createComment);
}

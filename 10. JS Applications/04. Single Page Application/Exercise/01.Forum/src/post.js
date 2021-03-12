import { createRow } from './dom.js';
import {postCheck} from './nullCheck.js'

export async function createPost(e) {
  e.preventDefault();

  const formData = new FormData(e.target);
  const topicName = formData.get("topicName");
  const username = formData.get("username");
  const postText = formData.get("postText");

  postCheck(topicName, username, postText);

  const newPost = {
    topicName,
    username,
    postText,
    post: [],
  };

  const response = await fetch("http://localhost:3030/jsonstore/collections/myboard/posts", {
    method: "post",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(newPost),
  });

  if (e.submitter.textContent == "Post") {
    console.log("Post");
  } else if (e.submitter.textContent == "Cancel") {
    e.target.reset();
    return;
  }

  if (response.ok) {
    alert("Post successfully created");
  } else {
    const data = await response.json();
    return alert(data.message);
  }

  e.target.reset();
  showPosts();
}

export async function getPosts() {
  const response = await fetch("http://localhost:3030/jsonstore/collections/myboard/posts");
  const data = await response.json();
  return data;
}

export async function getPostById(id) {
  const response = await fetch("http://localhost:3030/jsonstore/collections/myboard/posts/" + id);
  const data = await response.json();
  return data;
}

export async function showPosts() {
  const posts = await getPosts();
  const rows = Object.values(posts).map(createRow).join("");
  document.getElementById("allTopics").innerHTML = rows;
}
import { createPost, showPosts } from "./post.js";
import { showComments } from "./comment.js";

document.getElementById("createForm").addEventListener("submit", createPost);

document.body.addEventListener("load", showPosts());

document.getElementById("allTopics").addEventListener("click", (e) => {
  if (e.target.tagName == "H2") {
    let id = e.target.parentElement.id;
    showComments(id);
  }
});
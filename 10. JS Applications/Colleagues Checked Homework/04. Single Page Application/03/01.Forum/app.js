import {setUpCreate, showPosts} from './create.js';
import {commentFunction} from './comments.js';


const createForm = document.querySelector('form');
const topics = document.querySelector('.topic-title');
topics.innerHTML = "";
const container = document.querySelector('.container');
container.innerHTML = "";
const postComment = document.getElementById('hidden');
const commentSection = document.getElementById('commentSection');
setUpCreate(createForm, container);
showPosts(topics, container);
commentFunction(topics, container,postComment,commentSection);




import { displayHome, setupHome } from './home.js'
import { displayTopicContent, setupTopicContent} from './topic-content.js'

const mainSection = document.getElementById('mainView')
const homeSection = document.getElementById('homeSection');
const topicContentSection = document.getElementById('topicContentSection');

setupHome(mainSection, homeSection);
setupTopicContent(mainSection, topicContentSection);

displayHome();

document.getElementById('homeBtn').addEventListener('click', (ev) => {
    ev.preventDefault();
    displayHome();
});
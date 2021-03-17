import { html, render } from './node_modules/lit-html/lit-html.js';
import { cats } from './catSeeder.js';

const template = (cat) => html`
<li>
    <img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
    <div class="info">
        <button class="showBtn">Show status code</button>
        <div class="status" style="display: none" id="${cat.id}">
            <h4>Status Code: ${cat.statusCode}</h4>
            <p>${cat.statusMessage}</p>
        </div>
    </div>
</li>`;

const main = document.getElementById('allCats');

const catsList = html`
<ul @click=${toggleInfo}>
    ${cats.map(template)}
</ul>`;

render(catsList, main);

function toggleInfo(e) {
    const element = e.target.parentNode.querySelector('.status');
    if (e.target.className == 'showBtn')
        if (element.style.display == 'none') {
            element.removeAttribute('style');
            e.target.textContent = 'Hide status code';
        } else {
            element.style.display = 'none';
            e.target.textContent = 'Show status code';
        }
}
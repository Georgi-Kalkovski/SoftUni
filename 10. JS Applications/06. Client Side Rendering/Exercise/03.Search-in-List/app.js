import { html, render } from './node_modules/lit-html/lit-html.js';
import { towns as townsList } from './towns.js';

const mainTemplate = (towns, match) => html`
<article>
   <div id="towns">
      <ul>
         ${towns.map(t => townTemplate(t, match))}
      </ul>
   </div>
   <input type="text" id="searchText" />
   <button @click=${search}>Search</button>
   <div id="result"></div>
</article>`;

const townTemplate = (townName, match) => html`
   <li class=${(match && townName.toLowerCase().includes(match.toLowerCase())) ? 'active' : '' }>
      ${townName}
   </li>`;

const root = document.querySelector('body');
update();

function update(match = '') {
   const result = mainTemplate(townsList, match);
   render(result, root);
}

function search(e) {
   update(e.target.parentNode.querySelector('input').value);
}

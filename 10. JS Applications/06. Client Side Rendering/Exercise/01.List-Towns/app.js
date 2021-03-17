import { html, render } from './node_modules/lit-html/lit-html.js';

const template = (data) => html`
<ul>
    ${data.map(t => html`<li>${t}</li>`)}
</ul>`;

// add click listener
document.getElementById('btnLoadTowns').addEventListener('click', update)

function update(e) {
    e.preventDefault();
    
    const townsAsString = document.getElementById('towns').value;
    const root = document.getElementById('root');

    // execute template
    const towns = townsAsString.split(', ').map(x => x.trim());
    const result = template(towns);
    // render result
    render(result, root)
}
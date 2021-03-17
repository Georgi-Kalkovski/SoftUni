import { html, render } from './node_modules/lit-html/lit-html.js';

const template = (list) => html`
<select id="menu">
    ${list.map(x => html`<option value=${x._id}>${x.text}</option>`)}
</select>`;

const endpoint = 'http://localhost:3030/jsonstore/advanced/dropdown';
const root = document.querySelector('div');
const input = document.getElementById('itemText');
initialize();

async function initialize() {
    document.querySelector('form').addEventListener('submit', (e) => addItem(e, list));

    const response = await fetch(endpoint);
    const data = await response.json();
    const list = Object.values(data);

    update(list);
}

function update(list) {
    const result = template(list);
    render(result, root);
}

async function addItem(e, list) {
    e.preventDefault();

    const item = {
        text: input.value
    };
    const response = await fetch(endpoint, {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(item),
    });
    const result = await response.json();
    list.push(result);

    update(list);
}
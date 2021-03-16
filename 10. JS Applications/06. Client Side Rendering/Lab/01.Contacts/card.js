import { html } from './node_modules/lit-html/lit-html.js';

const cardTemplate = (data) => html`
<div class="contact card">
    <div>
        <i class="far fa-user-circle gravatar"></i>
    </div>
    <div class="info">
        <h2>Name: ${data.name}</h2>
        <button @click=${onClick} class="detailsBtn">Details</button>
        <div class="details" id="${data.id}">
            <p>Phone number: ${data.phoneNumber}</p>
            <p>Email: ${data.email}</p>
        </div>
    </div>
</div>`;

function onClick(event) {
    const element = event.target.parentNode;
    const currentStyle = element.querySelector('.details').style.display;
    if (currentStyle == 'block') {
        element.querySelector('.details').style.display = 'none';
    }else {
        element.querySelector('.details').style.display = 'block';
    }
}

export default cardTemplate;
import { html } from '../../node_modules/lit-html/lit-html.js';

import { deleteItem, getItem } from '../api/data.js';


const detailsTemplate = (car, onDelete) => html`
<!-- Listing Details Page -->
<section id="listing-details">
    <h1>Details</h1>
    <div class="details-info">
        <img src="${car.imageUrl}">
        <hr>
        <ul class="listing-props">
            <li><span>Brand:</span>${car.brand}</li>
            <li><span>Model:</span>${car.model}</li>
            <li><span>Year:</span>${car.year}</li>
            <li><span>Price:</span>${car.price}$</li>
        </ul>

        <p class="description-para">${car.description}</p>

        ${car._ownerId === sessionStorage.getItem('userId') ? 
            html`
            <div class="listings-buttons">
            <a href="/edit/${car._id}" class="button-list">Edit</a>
            <a @click=${onDelete} class="button-list">Delete</a>
            </div>`
             : ''}
    </div>
</section>
`;

export async function detailsPage(ctx) {
    const id = ctx.params.id;
    const car = await getItem(id);
    ctx.render(detailsTemplate(car, onDelete));
    
    async function onDelete() {
        const confirmation = confirm('Are you sure you want to delete this car?');

        if(confirmation){
            await deleteItem(id);
            ctx.page.redirect('/catalog');
        }
    }
}
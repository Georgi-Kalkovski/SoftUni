import { html } from '../../node_modules/lit-html/lit-html.js';

import { deleteItem, getItem } from '../api/data.js';

const detailsTemplate = (meme, onDelete) => html`
<!-- Details Meme Page (for guests and logged users) -->
<section id="meme-details">
    <h1>Meme Title: ${meme.title}</h1>
    <div class="meme-details">
        <div class="meme-img">
            <img alt="meme-alt" src=${meme.imageUrl}>
        </div>
        <div class="meme-description">
            <h2>Meme Description</h2>
            <p>${meme.description}</p>
            ${meme._ownerId === sessionStorage.getItem('userId') ? 
            html`<a class="button warning" href="/edit/${meme._id}">Edit</a>
                 <button @click=${onDelete} class="button danger">Delete</button>`
             : ''}
        </div>
    </div>
</section>
`;

export async function detailsPage(ctx) {
    const id = ctx.params.id;
    const meme = await getItem(id);
    ctx.render(detailsTemplate(meme, onDelete));
    
    async function onDelete() {
        const confirmation = confirm('Are you sure you want to delete this meme?');

        if(confirmation){
            await deleteItem(id);
            ctx.page.redirect('/catalog');
        }
    }
}
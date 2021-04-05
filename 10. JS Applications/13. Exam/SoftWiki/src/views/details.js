import { html } from '../../node_modules/lit-html/lit-html.js';

import { deleteItem, getItem } from '../api/data.js';

const detailsTemplate = (article, onDelete) => html`
<!-- Details -->
<section id="details-page" class="content details">
    <h1>${article.title}</h1>
    <div class="details-content">
        <strong>Published in category ${article.category}</strong>
        <p>${article.content}</p>
        
        ${article._ownerId === sessionStorage.getItem('userId') ? 
            html`
            <div class="buttons">
            <a href="/" @click=${onDelete} class="btn delete">Delete</a>
            <a href="/edit/${article._id}" class="btn edit">Edit</a>
            <a href="/" class="btn edit">Back</a>
            </div>`
        : html `<a href="/" class="btn edit">Back</a>`}
    </div>
</section>
`;


export async function detailsPage(ctx) {
    const id = ctx.params.id;
    const article = await getItem(id);
    ctx.render(detailsTemplate(article, onDelete));
    
    async function onDelete() {
        const confirmation = confirm('Are you sure you want to delete this article?');

        if(confirmation){
            await deleteItem(id);
            ctx.page.redirect('/');
        }
    }
}
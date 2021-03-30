import { html } from '../../node_modules/lit-html/lit-html.js';

import { addItem } from '../api/data.js';
import { showNotification } from './notification.js'

const createTemplate = (onSubmit) => html`
<!-- Create Meme Page ( Only for logged users ) -->
<section id="create-meme">
    <form @submit=${onSubmit} id="create-form">
        <div class="container">
            <h1>Create Meme</h1>
            <label for="title">Title</label>
            <input id="title" type="text" placeholder="Enter Title" name="title">
            <label for="description">Description</label>
            <textarea id="description" placeholder="Enter Description" name="description"></textarea>
            <label for="imageUrl">Meme Image</label>
            <input id="imageUrl" type="text" placeholder="Enter meme ImageUrl" name="imageUrl">
            <input type="submit" class="registerbtn button" value="Create Meme">
        </div>
    </form>
</section>
`;

export async function createPage(ctx) {
    ctx.render(createTemplate(onSubmit));

    async function onSubmit(event) {
        event.preventDefault();

        const formData = new FormData(event.target);

        const title = formData.get('title').trim();
        const description = formData.get('description').trim();
        const imageUrl = formData.get('imageUrl').trim();

        if (!title || !description || !imageUrl) {
            return showNotification('All fields are required!');
            //return alert('All fields are required!');
        }

        const item = {
            title,
            description,
            imageUrl
        }

        await addItem(item);
        ctx.setUserNav();
        ctx.page.redirect('/catalog');
    }
}
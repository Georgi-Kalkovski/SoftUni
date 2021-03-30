import { html } from '../../node_modules/lit-html/lit-html.js';

import { editItem, getItem } from '../api/data.js';
import { showNotification } from './notification.js'

const editTemplate = (meme, onSubmit) => html`
<!-- Edit Meme Page ( Only for logged user and creator to this meme )-->
<section id="edit-meme">
    <form @submit=${onSubmit} id="edit-form">
        <h1>Edit Meme</h1>
        <div class="container">
            <label for="title">Title</label>
            <input id="title" type="text" placeholder="Enter Title" name="title" .value=${meme.title}>
            <label for="description">Description</label>
            <label for="imageUrl">Image Url</label>
            <textarea id="description" placeholder="Enter Description" name="description" .value=${meme.description}></textarea>
            <label for="imageUrl">Image Url</label>
            <input id="imageUrl" type="text" placeholder="Enter Meme ImageUrl" name="imageUrl" .value=${meme.imageUrl}>
            <input type="submit" class="registerbtn button" value="Edit Meme">
        </div>
    </form>
</section>
`;

export async function editPage(ctx) {
    const id = ctx.params.id;
    const meme = await getItem(id);
    ctx.render(editTemplate(meme, onSubmit));

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

        await editItem(id, item);
        ctx.setUserNav();
        ctx.page.redirect('/catalog');
    }
}
import {deleteItem, getItem} from "../api/data.js";

export {showDetails}
import {html} from '../../node_modules/lit-html/lit-html.js'

async function showDetails(ctx) {
    const data = await getItem(ctx.params.id);
    const view = html`
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Furniture Details</h1>
            </div>
        </div>
        <div class="row space-top">
            <div class="col-md-4">
                <div class="card text-white bg-primary">
                    <div class="card-body">
                        <img src="${data.img}"/>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <p>Make: <span>${data.make}</span></p>
                <p>Model: <span>${data.model}</span></p>
                <p>Year: <span>${data.year}</span></p>
                <p>Description: <span>${data.description}</span></p>
                <p>Price: <span>${data.price}</span></p>
                <p>Material: <span>${data.material}</span></p>
                ${sessionStorage.userId === data._ownerId ?
                        html`
                            <div>
                                <a href="/edit/${data._id}" class="btn btn-info">Edit</a>
                                <a href="javascript:void(0)" @click="${(ev) => onDelete(ev, data._id, ctx)}"
                                   class="btn btn-red">Delete</a>
                            </div>` : ''}
            </div>
        </div>
    `
    ctx.render(view, ctx.container)
}

async function onDelete(ev, id, ctx) {
    ev.preventDefault();
    const confirmation = confirm('Are you sure you want to delete this item?');
    if (confirmation) {
        await deleteItem(id);
        ctx.page.redirect('/');
    }
}
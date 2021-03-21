import {getItems} from "../api/data.js";

export {showDashboard}
import {html} from '../../node_modules/lit-html/lit-html.js'

async function showDashboard(ctx) {
    const data = await getItems();
    const view = html`
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Welcome to Furniture System</h1>
                <p>Select furniture from the catalog to view details.</p>
            </div>
        </div>
        <div class="row space-top">
            ${data.map(e=>html`
                <div class="col-md-4">
                    <div class="card text-white bg-primary">
                        <div class="card-body">
                            <img src="${e.img}"/>
                            <p>${data.description}</p>
                            <footer>
                                <p>Price: <span>${e.price} $</span></p>
                            </footer>
                            <div>
                                <a href="/details/${e._id}" class="btn btn-info">Details</a>
                            </div>
                        </div>
                    </div>
                </div>`)}
        </div>`
    ctx.setNav();
    ctx.render(view, ctx.container);
}
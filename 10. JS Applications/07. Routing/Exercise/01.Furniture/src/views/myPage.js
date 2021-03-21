import {getItemsByOwner} from "../api/data.js";
import {html} from "../../node_modules/lit-html/lit-html.js";

export {showMyPage}

async function showMyPage(ctx){
    const data = await getItemsByOwner(sessionStorage.getItem('userId'));
    const view = html`
        <div class="row space-top">
            <div class="col-md-12">
                <h1>My Furniture</h1>
                <p>This is a list of your publications.</p>
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
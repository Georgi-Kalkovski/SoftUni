export {showCreate}
import {html} from '../../node_modules/lit-html/lit-html.js';
import {validateInput} from '../validation/input.js'
import {addItem} from '../api/data.js';

function showCreate(ctx) {
    const view = html`
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Create New Furniture</h1>
                <p>Please fill all fields.</p>
            </div>
        </div>
        <form @submit="${(ev) => onSubmit(ev, ctx)}">
            <div class="row space-top">
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="form-control-label" for="new-make">Make</label>
                        <input class="form-control" id="new-make" type="text" name="make">
                    </div>
                    <div class="form-group has-success">
                        <label class="form-control-label" for="new-model">Model</label>
                        <input class="form-control" id="new-model" type="text" name="model">
                    </div>
                    <div class="form-group has-danger">
                        <label class="form-control-label" for="new-year">Year</label>
                        <input class="form-control" id="new-year" type="number" name="year">
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-description">Description</label>
                        <input class="form-control" id="new-description" type="text" name="description">
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="form-control-label" for="new-price">Price</label>
                        <input class="form-control" id="new-price" type="number" name="price">
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-image">Image</label>
                        <input class="form-control" id="new-image" type="text" name="img">
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-material">Material (optional)</label>
                        <input class="form-control" id="new-material" type="text" name="material">
                    </div>
                    <input type="submit" class="btn btn-primary" value="Create"/>
                </div>
            </div>
        </form>
    `
    ctx.render(view, ctx.container);
}

async function onSubmit(ev, ctx) {
    ev.preventDefault();
    const form = ev.target;
    const data = [...new FormData(ev.target).entries()].reduce((acc, [k, v]) => {
        acc[k] = v;
        return acc;
    }, {});
    data.year = Number(data.year);
    data.price = Number(data.price);
    const isValid = validateInput(form,data);
    if(isValid){
        await addItem(data);
        ctx.page.redirect('/');
    }
}
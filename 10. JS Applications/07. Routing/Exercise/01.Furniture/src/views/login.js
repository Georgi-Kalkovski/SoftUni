import {html} from '../../node_modules/lit-html/lit-html.js'
import {login} from '../api/api.js'

export {showLogin}

function showLogin(ctx) {
    const view = html`
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Login User</h1>
                <p>Please fill all fields.</p>
            </div>
        </div>
        <form @submit="${(ev)=>onSubmit(ev,ctx)}">
            <div class="row space-top">
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="form-control-label" for="email">Email</label>
                        <input class="form-control" id="email" type="text" name="email">
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="password">Password</label>
                        <input class="form-control" id="password" type="password" name="password">
                    </div>
                    <input type="submit" class="btn btn-primary" value="Login"/>
                </div>
            </div>
        </form>
    `;

    ctx.render(view, ctx.container);
}

async function onSubmit(ev,ctx){
    ev.preventDefault();
    const data = [...new FormData(ev.target).entries()].reduce((acc,[k,v])=>{
        acc[k]=v;
        return acc;
    },{});
    await login(data.email,data.password);
    ctx.page.redirect('/');
}
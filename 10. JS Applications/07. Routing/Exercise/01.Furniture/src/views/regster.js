export {showRegister}
import {html} from '../../node_modules/lit-html/lit-html.js';
import {login, register} from '../api/api.js';

function showRegister(ctx) {
    const view = html`
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
                    <div class="form-group">
                        <label class="form-control-label" for="rePass">Repeat</label>
                        <input class="form-control" id="rePass" type="password" name="rePass">
                    </div>
                    <input type="submit" class="btn btn-primary" value="Register"/>
                </div>
            </div>
        </form>
    `
    ctx.render(view,ctx.container);
}

async function onSubmit(ev,ctx){
    ev.preventDefault();
    const data = [...new FormData(ev.target).entries()].reduce((acc,[k,v])=>{
        acc[k]=v;
        return acc;
    },{});
    if (Object.values(data).some(e => e === '')) {
        return alert('Please fill in all fields!');
    }

    if(data.password!==data.rePass){
        return alert('Passwords don\'t match!');
    }
    await register(data.email,data.password);
    ctx.page.redirect('/');
}
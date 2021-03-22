import { until } from '../../node_modules/lit-html/directives/until.js';
import { html } from '../../node_modules/lit-html/lit-html.js';
import { getTeamById, editTeam } from '../api/data.js';
import { loaderTemplate } from './common/loader.js';


const editTemplate = (team, onSubmit, errorMsg) => html`
<section id="edit">
    <article class="narrow">
        <header class="pad-med">
            <h1>Edit Team</h1>
        </header>
        <form @submit=${onSubmit} id="edit-form" class="main-form pad-large">
            ${errorMsg ? html`<div class="error">${errorMsg}</div>` : ''}
            <label>Team name: <input type="text" name="name" .value=${team.name}></label>
            <label>Logo URL: <input type="text" name="logoUrl" .value=${team.logoUrl}></label>
            <label>Description: <textarea name="description" .value=${team.description}></textarea></label>
            <input class="action cta" type="submit" value="Save Changes">
        </form>
    </article>
</section>`;


export async function editPage(ctx) {
    const teamId = ctx.params.id;

    ctx.render(until(populateTemplate(), loaderTemplate()));

    async function populateTemplate() {
        const team = await getTeamById(teamId);
        return editTemplate(team, onSubmit);

        async function onSubmit(event) {
            event.preventDefault();
            const formData = new FormData(event.target);
            const name = formData.get('name');
            const logoUrl = formData.get('logoUrl');
            const description = formData.get('description');

            [...event.target.querySelectorAll('input')].forEach(i => i.disabled = true);

            try {
                if (name.length < 4) {
                    throw new Error('Team name must be at least 4 characters long.');
                }
                if (description.length < 10) {
                    throw new Error('Description must be at least 10 characters long.');
                }
                if (logoUrl == '') {
                    throw new Error('Team logo is required.');
                }

                await editTeam(teamId, { name, description, logoUrl });

                event.target.reset();
                ctx.page.redirect('/details/' + team._id);
            } catch (err) {
                ctx.render(editTemplate(team, onSubmit, err.message));
            } finally {
                [...event.target.querySelectorAll('input')].forEach(i => i.disabled = false);
            }
        }
    }
}


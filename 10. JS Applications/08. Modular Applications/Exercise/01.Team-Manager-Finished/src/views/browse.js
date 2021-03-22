import { html } from '../../node_modules/lit-html/lit-html.js';
import { until } from '../../node_modules/lit-html/directives/until.js';

import { getTeams } from '../api/data.js';
import { loaderTemplate } from './common/loader.js';
import { teamTemplate } from './common/team.js';


const browseTemplate = (teams) => html`
<section id="browse">

    <article class="pad-med">
        <h1>Team Browser</h1>
    </article>

    <article class="layout narrow">
        <div class="pad-small"><a href="/create" class="action cta">Create Team</a></div>
    </article>

    ${teams.map(teamTemplate)}

</section>`;


export async function browsePage(ctx) {
    ctx.render(until(populateTemplate(), loaderTemplate()));
}

async function populateTemplate() {
    const teams = await getTeams();
    return browseTemplate(teams);
}
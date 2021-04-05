import { html } from '../../node_modules/lit-html/lit-html.js';

import { getItems } from '../api/data.js';

const catalogTemplate = (article) => html`
<!-- catalogue -->
<section id="catalog-page" class="content catalogue">
    <h1>All Articles</h1>
    ${article.length > 0 ? article.map(articleTemplate) : html`<h3 class="no-articles">No articles yet</h3>`}
</section>
`;

const articleTemplate = (article) => html`
<a class="article-preview" href="/details/${article._id}">
    <article>
        <h3>Topic: <span>${article.title}</span></h3>
        <p>Category: <span>${article.category}</span></p>
    </article>
</a>
`;

export async function catalogPage(ctx) {
    const articles = await getItems();
    ctx.render(catalogTemplate(articles));
}
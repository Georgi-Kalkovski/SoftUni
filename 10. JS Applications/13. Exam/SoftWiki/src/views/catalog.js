import { html } from '../../node_modules/lit-html/lit-html.js'

import { getItems } from '../api/data.js'

const catalogTemplate = (data) => html`
<section id="catalog-page" class="content catalogue">
    <h1>All Articles</h1>
    ${data.length > 0 ? data.map(articleTemplate) : html`<h3 class="no-articles">No articles yet</h3>`}
</section>`

const articleTemplate = (article) => html`
<a class="article-preview" href="/details/${article._id}">
    <article>
        <h3>Topic: <span>${article.title}</span></h3>
        <p>Category: <span>${article.category}</span></p>
    </article>
</a>`

export async function catalogPage(ctx) {
    const article = await getItems();
    ctx.render(catalogTemplate(article));
}
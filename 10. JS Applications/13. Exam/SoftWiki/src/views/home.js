import { html } from '../../node_modules/lit-html/lit-html.js';

import { getRecentArticles } from '../api/data.js';

const homeTemplate = (javascript, csharp, java, python) => html`
<!-- Home -->
<section id="home-page" class="content">
    <h1>Recent Articles</h1>

    <section class="recent js">
        <h2>JavaScript</h2>
        ${javascript ? html`
        <article>
            <h3>${javascript.title}</h3>
            <p>${javascript.content}</p>
            <a href="/details/${javascript._id}" class="btn details-btn">Details</a>
        </article>`
    : html`<h3 class="no-articles">No articles yet</h3>`}
    </section>

    <section class="recent csharp">
        <h2>C#</h2>
        ${csharp ? html`
        <article>
            <h3>${csharp.title}</h3>
            <p>${csharp.content}</p>
            <a href="/details/${csharp._id}" class="btn details-btn">Details</a>
        </article>`
    : html`<h3 class="no-articles">No articles yet</h3>`}
    </section>

    <section class="recent java">
        <h2>Java</h2>
        ${java ? html`
        <article>
            <h3>${java.title}</h3>
            <p>${java.content}</p>
            <a href="/details/${java._id}" class="btn details-btn">Details</a>
        </article>`
    : html`<h3 class="no-articles">No articles yet</h3>`}
    </section>
    
    <section class="recent python">
        <h2>Python</h2>
        ${python ? html`
        <article>
            <h3>${python.title}</h3>
            <p>${python.content}</p>
            <a href="/details/${python._id}" class="btn details-btn">Details</a>
        </article>`
    : html`<h3 class="no-articles">No articles yet</h3>`}
    </section>
</section>
`;

export async function homePage(ctx) {
    const articles = await getRecentArticles();

    let javascript = articles.filter(el => el.category === 'JavaScript').sort((a, b) => b._createdOn - a._createdOn)[0];
    let csharp = articles.filter(el => el.category === 'C#').sort((a, b) => b._createdOn - a._createdOn)[0];
    let java = articles.filter(el => el.category === 'Java').sort((a, b) => b._createdOn - a._createdOn)[0];
    let python = articles.filter(el => el.category === 'Python').sort((a, b) => b._createdOn - a._createdOn)[0];

    ctx.render(homeTemplate(javascript, csharp, java, python));
}
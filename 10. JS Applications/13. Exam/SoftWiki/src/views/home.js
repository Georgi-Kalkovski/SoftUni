import { html } from '../../node_modules/lit-html/lit-html.js';
import { getRecentArticles } from '../../src/api/data.js';

const homeTemplate = (js, csharp, java, python) => html`
<section id="home-page" class="content">
    <h1>Recent Articles</h1>
    <section class="recent js">
        <h2>JavaScript</h2>
        ${js != null ? html`
        <article>
            <h3>${js.title}</h3>
            <p>${js.content}</p>
            <a href="/details/${js._id}" class="btn details-btn">Details</a>
        </article>` : html`<h3 class="no-articles">No articles yet</h3>`}
    </section>
    <section class="recent csharp">
        <h2>C#</h2>
        ${csharp != null ? html`
        <article>
            <h3>${csharp.title}</h3>
            <p>${csharp.content}</p>
            <a href="/details/${csharp._id}" class="btn details-btn">Details</a>
        </article>` : html`<h3 class="no-articles">No articles yet</h3>`}
    </section>
    <section class="recent java">
        <h2>Java</h2>
        ${java != null ? html`
        <article>
            <h3>${java.title}</h3>
            <p>${java.content}</p>
            <a href="/details/${java._id}" class="btn details-btn">Details</a>
        </article>` : html`<h3 class="no-articles">No articles yet</h3>`}
    </section>
    <section class="recent python">
        <h2>Python</h2>
        ${python != null ? html`
        <article>
            <h3>${python.title}</h3>
            <p>${python.content}</p>
            <a href="/details/${python._id}" class="btn details-btn">Details</a>
        </article>` : html`<h3 class="no-articles">No articles yet</h3>`}
    </section>
</section>`;

export async function homePage(ctx) {
    const list = await getRecentArticles();

    const jsSection = list.find(e => e.category == 'JavaScript');
    const csharpSection = list.find(e => e.category == 'C#');
    const javaSection = list.find(e => e.category == 'Java');
    const pythonSection = list.find(e => e.category == 'Python');

    const result = homeTemplate(jsSection, csharpSection, javaSection, pythonSection);
    ctx.render(result)
}
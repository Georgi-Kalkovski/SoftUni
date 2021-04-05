import {html} from "../../node_modules/lit-html/lit-html.js";

import {search as searchItem} from "../api/data.js";

let searchTemplate = (searchArticle, articles=undefined) => html`
    <h1>Search</h1>
    <form  id="search-form">
        <p class="field search">
            <input type="text" placeholder="Search by article title" name="search" id="search-input">
        </p>
        <p class="field submit">
            <input @click=${searchArticle} class="btn submit" type="submit" value="Search">
        </p>
    </form>
    <div class="search-container">
    ${articles.length > 0 && articles != undefined
    ? html `
        ${articles.map(article => articleTemplate(article))}` 
    : html `
         <h3 class="no-articles">No matching articles</h3>`}
               
    </div>
</section>`;


let articleTemplate = (article) => html`
        <a class="article-preview" href="/details/${article._id}">
            <article>
                <h3>Topic: <span>${article.title}</span></h3>
                <p>Category: <span>${article.category}</span></p>
            </article>
        </a>`;

export async function searchPage(ctx) {   
    ctx.render(searchTemplate(searchArticle, []));

    async function searchArticle(event) {
        event.preventDefault();
    
        const info = document.getElementById('search-input').value;
        console.log(info)
            const articles = await searchItem(info);
            console.log(articles)
            ctx.render(searchTemplate(searchArticle,articles));
    }
}
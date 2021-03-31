import {html} from "../../node_modules/lit-html/lit-html.js";
import {getYear} from "../api/data.js";

let searchTemplate = (searchCar, cars=undefined) => html`
<section id="search-cars">
    <h1>Filter by year</h1>
    <div class="container">
        <input id="search-input" type="text" name="search" placeholder="Enter desired production year">
        <button @click=${searchCar} class="button-list">Search</button>
    </div>
    <h2>Results:</h2>
    <div class="listings">
    ${cars.length > 0 && cars != undefined
    ? html `
        ${cars.map(car => carTemplate(car))}` 
    : html `
         <p class="no-cars"> No results.</p>`}
               
    </div>
</section>`;

let carTemplate = (car) => html`
<div class="listing">
    <div class="preview">
        <img src="${car.imageUrl}">
    </div>
    <h2>${car.brand} ${car.model}</h2>
    <div class="info">
        <div class="data-info">
            <h3>Year: ${car.year}</h3>
            <h3>Price: ${car.price} $</h3>
        </div>
        <div class="data-buttons">
            <a href="/details/${car._id}" class="button-carDetails">Details</a>
        </div>
    </div>
</div>`;

export async function searchPage(ctx) {   

    ctx.render(searchTemplate(searchCar,[]));

    async function searchCar() {
        let input = Number(document.getElementById('search-input').value);
        ctx.page.redirect(`/search=${input}`);
        let cars = await getYear(input);
        ctx.render(searchTemplate(searchCar, cars));

    }
}
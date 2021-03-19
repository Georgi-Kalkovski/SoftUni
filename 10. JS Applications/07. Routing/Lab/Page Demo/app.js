import page from './node_modules/page/page.mjs';

const pages = {
    '/home': '<h2>Home Page</h2><p>Home page content</p>',
    '/catalog': '<h2>Catalog</h2><p>List of recent articles <a href="/catalog/action/123">Item 123</a></p>',
    '/catalog/123': '<h2>Item 123</h2><p>Item details</p>',
    '/about': '<h2>About Us</h2><p>Contact information</p>',
    '/buy': '<h2>Thank you for your purchase!</h2>',
};
const defaultPage = '<h2>404</h2><p>Page Not Found</p>';

const main = document.querySelector('main');

page('/home', updateCondent);
page('/catalog', updateCondent);
page('/catalog/:category/:id', itemDetails);
page('/about', updateCondent);
page('/buy', updateCondent);

page.redirect('/', '/home');

page.start();

async function updateCondent(context) {
    main.innerHTML = '<p>Loading&hellip;</p>';

    await new Promise(r => setTimeout(r, 500));

    main.innerHTML = pages[context.pathname] || defaultPage;
}

// http://localhost:3000/catalog/thriller/443
function itemDetails(context) {
    const category = context.params.category;
    const id = context.params.id;
    const html = `
    <h2>Category ${category}</h2>
    <h3>Item ${id}</h3>
    <p>Details for item ${id}</p>`;
    main.innerHTML = html;

    const btn = document.createElement('button');
    btn.textContent = 'Buy';
    btn.addEventListener('click', () => {
        context.page.redirect('/buy');
    });
    main.appendChild(btn);
}
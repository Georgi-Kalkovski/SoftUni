function solve() {
    let products = document.querySelector("body > div").children;
    let textarea = document.querySelector("body > div > textarea")
    for (const product of products) {
        if (product.className == 'product') {
            let button = product.children[2].children[0];
            name = product.children[1].children[0].textContent;
            price = Number(product.children[3].textContent);

            console.log(`Added ${name} for $${price.toFixed(2)} to the cart.` + '\n');
        }
    }
}
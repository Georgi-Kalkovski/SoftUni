function solve() {

    const textarea = document.querySelector("body > div > textarea");
    const names = [];
    let priceSum = 0;
    let buttonsDisabled = false;

    Array.from(document.querySelectorAll('body > div > div > .product-add'))
    .forEach(button => {
        button.addEventListener('click', onAddClick);
    });

    function onAddClick(e) {
        if (buttonsDisabled == false) {
            const name = e.target.parentNode.parentNode.children[1].children[0].textContent;
            if (!names.includes(name)) {
                names.push(name);
            }
            const price = Number(e.target.parentNode.parentNode.children[3].textContent);
            priceSum += price;
            textarea.textContent += `Added ${name} for ${price.toFixed(2)} to the cart.\n`;
        }
    }

    document.querySelector("body > div > button").addEventListener('click', onCheckoutClick);
    
    function onCheckoutClick() {
        if (buttonsDisabled == false) {
            textarea.textContent += `You bought ${names.join(', ')} for ${priceSum.toFixed(2)}.`;
            buttonsDisabled = true;
        }
    }
} 
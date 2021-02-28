async function getRecipeList() {
    const url = ' http://localhost:3030/jsonstore/cookbook/recipes';

    const main = document.querySelector('main');
    try {
        const response = await fetch(url);
        const recipes = await response.json();
        main.innerHTML = '';
        Object.values(recipes).forEach(r => {
            const result = e('article', { className: 'preview' },
                e('div', { className: 'title' }, e('h2', {}, r.name)),
                e('div', { className: 'small' }, e('img', { src: r.img }))
            );
            main.appendChild(result);
        });
    } catch (error) {
        alert(error.message);
    }

    /*
    fetch(url)
        .then(response => response.json())
        .then(recipes => {
            main.innerHTML = '';
            Object.values(recipes).forEach(r => {
                const result = e('article', { className: 'preview' },
                    e('div', { className: 'title' }, e('h2', {}, r.name)),
                    e('div', { className: 'small' }, e('img', { src: r.img }))
                );
                main.appendChild(result);
            });
        })
        .catch(error => {
            alert(error.message);
        });
    */
}

window.addEventListener('load', () => {
    getRecipeList();
});

function e(type, attributes, ...content) {
    const result = document.createElement(type);

    for (let [attr, value] of Object.entries(attributes || {})) {
        if (attr.substring(0, 2) == 'on') {
            result.addEventListener(attr.substring(2).toLocaleLowerCase(), value);
        } else {
            result[attr] = value;
        }
    }

    content = content.reduce((a, c) => a.concat(Array.isArray(c) ? c : [c]), []);

    content.forEach(e => {
        if (typeof e == 'string' || typeof e == 'number') {
            const node = document.createTextNode(e);
            result.appendChild(node);
        } else {
            result.appendChild(e);
        }
    });

    return result;
}

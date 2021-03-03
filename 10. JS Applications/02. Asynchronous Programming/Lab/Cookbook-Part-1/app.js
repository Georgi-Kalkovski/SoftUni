async function getRecipeList() {
    const url = 'http://localhost:3030/jsonstore/cookbook/recipes';

    const main = document.querySelector('main');
    
    try {
        const response = await fetch(url);

        if (response.ok == false) {
            throw new Error(response.statusText);
        }

        const recipes = await response.json();
        main.innerHTML = '';
        Object.values(recipes).map(createPreview).forEach(r => main.appendChild(r));
    }
    catch (error) {
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

function createPreview(recipe) {
    const result = e('article', { className: 'preview' },
        e('div', { className: 'title' }, e('h2', {}, recipe.name)),
        e('div', { className: 'small' }, e('img', { src: recipe.img }))
    );

    result.addEventListener('click', () => getRecipeDetails(recipe._id, result));
    return result;
}

async function getRecipeDetails(id, preview) {
    const url = 'http://localhost:3030/jsonstore/cookbook/details/' + id;

    const response = await fetch(url);
    const data = await response.json();

    const result = e('article', {},
        e('h2', { onClick: toggleCard }, data.name),
        e('div', { className: 'band' },
            e('div', { className: 'thumb' }, e('img', { src: data.img })),
            e('div', { className: 'ingredients' },
                e('h3', {}, 'Ingredients:'),
                e('ul', {}, data.ingredients.map(i => e('li', {}, i)))
            )
        ),
        e('div', { className: 'description' },
            e('h3', {}, 'Preparation:'),
            data.steps.map(s => e('p', {}, s))
        )
    );

    //preview.parentNode.replaceChild(result, preview);
    preview.replaceWith(resilt);

    function toggleCard() {
        result.replaceWith(preview)
    }
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

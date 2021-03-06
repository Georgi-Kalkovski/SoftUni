const main = document.getElementById('main');

function solution() {
    getArticles();
}

solution();

async function getArticles() {
    const response = await fetch('http://localhost:3030/jsonstore/advanced/articles/list');
    const data = await response.json();

    for (const article of data) {
        const url = 'http://localhost:3030/jsonstore/advanced/articles/details/' + article._id;

        const response = await fetch(url);
        const data = await response.json();

        const accordion = e('div', { className: 'accordion' });
        const head = e('div', { className: 'head' });
        const span = e('span', {}, article.title);
        const button = e('button', { className: 'button', id: article._id }, 'More');

        const extra = e('div', { className: 'extra' });
        const p = e('p', {}, data.content);
       
        head.appendChild(span);
        head.appendChild(button);
        accordion.appendChild(head);
     
        extra.appendChild(p);
        accordion.appendChild(extra);

        button.addEventListener('click', toggleButton);
        main.appendChild(accordion);
    }
}

function toggleButton(ev) {
    let parent = ev.target.parentNode.parentNode;
    if (ev.target.textContent == 'More') {
        parent.querySelector('.extra').style.display = 'block';
        ev.target.textContent = 'Hide';
    } else if (ev.target.textContent == 'Hide') {
        parent.querySelector('.extra').style.display = 'none';
        ev.target.textContent = 'More';
    }
}


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

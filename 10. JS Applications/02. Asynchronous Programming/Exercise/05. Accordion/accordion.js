async function solution() {

    const url = 'http://localhost:3030/jsonstore/advanced/articles/list';
    const response = await fetch(url);
    const data = await response.json();

    innerSolution(data);
}

solution();


async function innerSolution(outerData) {

    const main = document.getElementById('main');

    for (const element in outerData) {

        const elem = outerData[element];
        const id = elem._id;
        const title = elem.title;
        const url = 'http://localhost:3030/jsonstore/advanced/articles/details/' + id;
        const response = await fetch(url);
        const data = await response.json();
        const content = data.content;

        const outerDiv = e('div', '', 'accordion');
        const innerDiv1 = e('div', '', 'head');
        const span = e('span', title);
        const button = e('button', 'More', 'button', id);
        const innerDiv2 = e('div', '', 'extra')
        innerDiv2.style.display = 'none';
        const p = e('p', content);

        innerDiv1.appendChild(span);
        innerDiv1.appendChild(button);
        outerDiv.appendChild(innerDiv1);

        innerDiv2.appendChild(p);
        outerDiv.appendChild(innerDiv2);

        main.appendChild(outerDiv);
    }
    toggle();
}

function e(type, text, style, id) {

    const element = document.createElement(type);
    
    if (text) {
        element.textContent = text;
    }
    if (style) {
        element.className = style;
    }
    if (id) {
        element.id = id;
    }
    return element;
}

function toggle() {
    document.querySelectorAll('.button')
        .forEach((btn) => btn.addEventListener('click', (event) => {
            const extra = event.target.parentNode.parentNode.children[1];
            const button = event.target;

            if (extra.style.display == "none") {
                extra.style.display = "block";
                button.textContent = "Less";
            } else {
                extra.style.display = "none";
                button.textContent = "More";
            }
        }));
}
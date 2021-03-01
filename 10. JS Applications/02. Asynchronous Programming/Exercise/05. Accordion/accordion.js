async function solution() {

    const url = 'http://localhost:3030/jsonstore/advanced/articles/list';
    const response = await fetch(url);
    const data = await response.json();
    console.log(data)

    innerSolution(data);
}

solution();

async function innerSolution(outerData) {
    for (const element in outerData) {
        const e = outerData[element];
        const id = e._id;
        const title = e.title;
        const url = 'http://localhost:3030/jsonstore/advanced/articles/details/' + id;
        const inner = await fetch(url);
        const data = await inner.json();
        const content = data.content;
        console.log(id);
        console.log(title);
        console.log(content);

        const main = document.getElementById('main');

        const p = e('p', content);
        const outerDiv2 = e('div', {}, 'extra');
        const outerDiv1 = e('div', {}, 'extra');
        const button = e('button', )



    }
}

function toggle() {
    if (document.getElementById("extra").style.display == "none") {
        document.getElementById("extra").style.display = "block"
        document.getElementsByClassName("button")[0].textContent = "Less"
    } else {
        document.getElementById("extra").style.display = "none";
        document.getElementsByClassName("button")[0].textContent = "More";
    }
}

function e(type, text, style) {
    let element = document.createElement(type);

    if (text) {
        element.textContent = text;
    }

    if (style) {
        element.className = style;
    }

    return element;
}
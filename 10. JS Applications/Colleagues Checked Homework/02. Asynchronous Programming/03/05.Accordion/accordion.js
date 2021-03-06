window.addEventListener('load', solve);

async function solve() {
    setInitialStateOfAccordion();
    duplicateAccordion();
    addEventListeners();

    const dataResponse = await fetch('http://localhost:3030/jsonstore/advanced/articles/list');
    const data = await dataResponse.json();
    const dataDetailsResponse = await fetch('http://localhost:3030/jsonstore/advanced/articles/details');
    const dataDetails = await dataDetailsResponse.json();

    const buttons = document.getElementsByClassName('button');

    for (let i = 0; i < data.length; i++) {
        buttons[i].id = data[i]._id;
        buttons[i].parentElement.children[0].textContent = dataDetails[data[i]._id].title;
        buttons[i].parentElement.parentElement.children[1].children[0].textContent = dataDetails[data[i]._id].content;
    }
}

function setInitialStateOfAccordion() {
    const div = document.getElementsByClassName('extra')[0];
    div.style.display = 'none';
}

function duplicateAccordion() {
    const accordion = document.getElementsByClassName('accordion')[0];

    let i = 0;
    while (i++ < 3) {
        const newAccordion = document.createElement('div');

        newAccordion.className = 'accordion';
        newAccordion.innerHTML = accordion.innerHTML;

        accordion.parentElement.appendChild(newAccordion);

        accordion.parentElement.appendChild(document.createTextNode(' '));
    }
}

function addEventListeners() {
    const buttons = document.getElementsByClassName('button');

    Array.from(buttons).forEach(b => b.addEventListener('click', toggle));

    function toggle(event) {
        if (event.target.textContent === "More") {
            event.target.parentElement.parentElement.children[1].style.display = "block";
            event.target.textContent = "Less";
        } else if (event.target.textContent === "Less") {
            event.target.parentElement.parentElement.children[1].style.display = "none";
            event.target.textContent = "More";
        }
    }
}
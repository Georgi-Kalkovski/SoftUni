const url = 'http://localhost:3030/jsonstore/phonebook';

function attachEvents() {
    document.getElementById('btnLoad').addEventListener('click', onLoad);
    document.getElementById('btnCreate').addEventListener('click', onCreate);
}

attachEvents();

async function onCreate() {
    const person = document.getElementById('person').value;
    const phone = document.getElementById('phone').value;

    const response = await fetch(url, {
        method: 'post',
        headers: { 'Content-Type': 'aplication/json' },
        body: JSON.stringify( { person, phone })
    });

    const data = await response.json();
    
    document.getElementById('person').value = '';
    document.getElementById('phone').value = '';

    onLoad();
}

async function onLoad() {
    const response = await fetch(url);
    const data = await response.json();

    const ul = document.getElementById('phonebook');
    ul.innerHTML = '';

    Object
        .entries(data)
        .forEach(([key, value]) => {
            const content = `${value.person}: ${value.phone}`;
            newElement(content, ul, key);
        });
}

function newElement(content, parentEl, id) {
    const li = document.createElement('li');
    li.textContent = content;

    const btn = document.createElement('button');
    btn.textContent = 'Delete';
    btn.addEventListener('click', () => onDelete(id));

    li.appendChild(btn);

    parentEl.appendChild(li);
}

async function onDelete(id) {
    const uri = url + `/${id}`;

    const response = await fetch(uri, {
        method: 'delete'
    });

    const data = await response.json();
    console.log(data);

    onLoad();
}
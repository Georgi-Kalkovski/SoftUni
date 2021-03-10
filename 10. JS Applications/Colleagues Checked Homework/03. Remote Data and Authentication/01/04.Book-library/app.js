function attachEvents() {
    document.getElementById('loadBooks').addEventListener('click', onLoad);
    document.getElementById('tableBody').addEventListener('click', onClickButton);
    document.getElementById('createForm').addEventListener('submit', createBook);
    document.getElementById('editForm').addEventListener('submit', editBook);
}

attachEvents();

async function onClickButton(evt) {
    const id = evt.target.parentNode.parentNode.id;

    if (evt.target.className == 'editBtn') {
        document.getElementById('createForm').style.display = 'none';
        document.getElementById('editForm').style.display = 'block';
        await getBook(id);
    } else if (evt.target.className == 'deleteBtn') {
        const confirmed = confirm('Do you really want to delete this book?');

        if (confirmed) {
            await deleteBook(id);
        }
    }
}

async function getBook(id) {
    let url = `http://localhost:3030/jsonstore/collections/books/${id}`;

    const data = await request(url);

    document.querySelector('#editForm [name="id"]').value = data._id;
    document.querySelector('#editForm [name="title"]').value = data.title;
    document.querySelector('#editForm [name="author"]').value = data.author;

    return data;
}

async function onLoad() {
    let url = 'http://localhost:3030/jsonstore/collections/books';
    const data = await request(url);
    const tableBody = document.getElementById('tableBody');
    tableBody.innerHTML = '';

    Object.entries(data).map(([key, book]) => {
        const tr = createHtmlElement('tr', undefined, {
            name: 'id',
            value: key
        });
        const titleTd = createHtmlElement('td', book.title);
        const authorTd = createHtmlElement('td', book.author);

        const actionTd = createHtmlElement('td');
        const editBtn = createHtmlElement('button', 'Edit', undefined, 'editBtn');
        const deleteBtn = createHtmlElement('button', 'Delete', undefined, 'deleteBtn');

        actionTd.appendChild(editBtn);
        actionTd.appendChild(deleteBtn);

        tr.appendChild(titleTd);
        tr.appendChild(authorTd);
        tr.appendChild(actionTd);

        tableBody.appendChild(tr);
    });
}

async function createBook(evt) {
    evt.preventDefault();
    let url = 'http://localhost:3030/jsonstore/collections/books';

    const form = evt.target;
    const formData = new FormData(form);

    const title = formData.get('title');
    const author = formData.get('author');

    if (!title || !author) {
        return alert('All fields are required!');
    }

    await request(url, {
        method: 'post',
        headers: {
            'Content-Type': 'aplication/json'
        },
        body: JSON.stringify({
            author,
            title
        })
    });

    form.reset();

    await onLoad();
}

async function editBook(evt) {
    evt.preventDefault();
    const id = evt.target.querySelector('input[name="id"]').value;
    let url = `http://localhost:3030/jsonstore/collections/books/${id}`;

    const formData = new FormData(evt.target);
    const title = formData.get('title');
    const author = formData.get('author');

    await request(url, {
        method: 'put',
        headers: {
            'Content-Type': 'application/json'
        },
        Endpont: `/jsonstore/books/${id}`,
        body: JSON.stringify({
            author,
            title
        })
    });

    document.getElementById('createForm').style.display = 'block';
    document.getElementById('editForm').style.display = 'none';

    await onLoad();
}

async function deleteBook(id) {
    let url = `http://localhost:3030/jsonstore/collections/books/${id}`;

    await request(url, {
        method: 'delete',
    });

    await onLoad();
}

function createHtmlElement(type, content, attribute, className) {
    const el = document.createElement(type);

    if (content) {
        el.textContent = content;
    }

    if (attribute) {
        el[attribute.name] = attribute.value;
    }

    if (className) {
        el.className = className;
    }

    return el;
}

async function request(url, options) {
    const response = await fetch(url, options);

    if (response.ok == false) {
        const error = await response.json();
        throw new Error(error.message);
    }

    const data = await response.json();
    return data;
}
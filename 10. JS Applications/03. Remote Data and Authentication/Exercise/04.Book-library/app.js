function attachEvents() {

    const link = 'http://localhost:3030/jsonstore/collections/books/';

    // Event listene for the LOAD ALL BOOKS button
    document.getElementById('loadBooks').addEventListener('click', () => {
        getBooks(link);
    });

    // Event listene for the Submit button
    document.querySelector('form button').addEventListener('click', (event) => {
        event.preventDefault();
        if (event.target.textContent == 'Submit') {
            const title = document.getElementById('title').value;
            const author = document.getElementById('author').value;
            postBook(link, title, author);
        }
    });

    // Event listener for Edit/Delete buttons
    document.querySelectorAll('tbody').forEach((btn) => btn.addEventListener('click', (event) => {
        event.preventDefault();

        if (event.target.nodeName == 'BUTTON') {
            const id = event.target.parentNode.parentNode.id;
            const button = document.querySelector('form button');

            if (event.target.textContent == 'Edit') {
                document.querySelector('h3').textContent = 'Edit FORM';
                button.textContent = 'Save';

                button.addEventListener('click', (e) => {
                    e.preventDefault();

                    const title = document.getElementById('title').value;
                    const author = document.getElementById('author').value;
                    updateBook(link, id, title, author);
                });
            } if (event.target.textContent == 'Delete') {
                deleteData(link, id);
            }
        }
    }));
}

attachEvents();

// Load all books
async function getBooks(link) {
    const response = await fetch(link);
    const data = await response.json();

    const table = document.querySelector('tbody');
    table.innerHTML = '';

    for (const key in data) {
        const token = data[key];

        const book = e('tr');
        const title = e('td', token.title);
        const author = e('td', token.author);
        const buttons = e('td');
        const editBtn = e('button', 'Edit');
        const deleteBtn = e('button', 'Delete');
        book.id = key;

        buttons.append(editBtn, deleteBtn);
        book.append(title, author, buttons);
        table.appendChild(book);
    }
}

// Submit book
async function postBook(link, title, author) {
    if (title == '') {
        alert('Write Title name');
        return;
    } if (author == '') {
        alert('Write Author name');
        return;
    }
    await post(link, { title, author });

    document.getElementById('title').value = '';
    document.getElementById('author').value = '';

    async function post(link, data) {
        await fetch(link, {
            method: 'post',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(data),
        });
    }
}

// Edit book
async function updateBook(link, id, title, author) {
    if (title == '') {
        alert('Write Title name');
        return;
    } if (author == '') {
        alert('Write Author name');
        return;
    }
    await update(link, id, { title, author });

    document.querySelector('h3').textContent = 'FORM';
    document.querySelector('form button').textContent = 'Submit';
    document.getElementById('title').value = '';
    document.getElementById('author').value = '';

    async function update(link, id, data) {
        await fetch(link + id, {
            method: 'put',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(data),
        });
        getBooks(link);
    }
}

// Delete book
async function deleteData(link, id) {
    await fetch(link + id, {
        method: 'delete',
    });
    getBooks(link);
}

// Function dealing with elements
function e(type, text) {
    const element = document.createElement(type);
    element.textContent = text;
    return element;
}
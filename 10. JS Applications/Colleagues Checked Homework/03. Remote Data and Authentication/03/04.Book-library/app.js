const cancel = document.createElement('button');
cancel.textContent = 'Cancel';
cancel.className = 'cancel';
document.querySelector('.updateForm').appendChild(cancel);

async function getAllBooks() {
    const books = await request('http://localhost:3030/jsonstore/collections/books');
    document.querySelector('table>tbody').innerHTML = '';
    const rows = Object.entries(books).map(createRow).join('');
    document.querySelector('tbody').innerHTML = rows;
}
function createRow([id, book]) {
    const result = `<tr data-id=${id}>
    <td>${book.title}</td>
    <td>${book.author}</td>
    <td>
    <button class="editBtn">Edit</button>
    <button class="deleteBtn">Delete</button>
    </td>
    </tr>`
    return result;
}

async function updateBook(event) {
    event.preventDefault();
    const formData = new FormData(event.target);
    const id = formData.get('id');
    const book = {
        title: formData.get('title'),
        author: formData.get('author')
    }
    await request('http://localhost:3030/jsonstore/collections/books/' + id, {
        method: 'put',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(book)
    })
    document.querySelector('.createForm').style.display = 'block';
    document.querySelector('.updateForm').style.display = 'none';
    event.target.reset();
    getAllBooks();
}

async function createBook(event) {
    event.preventDefault();
    const formData = new FormData(event.target);
    const book = {
        title: formData.get('title'),
        author: formData.get('author')
    }
    const result = await request('http://localhost:3030/jsonstore/collections/books', {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(book)
    })
    event.target.reset();
    getAllBooks();
}

async function deleteBook(id) {
    await request('http://localhost:3030/jsonstore/collections/books/' + id, {
        method: 'delete'
    })
    getAllBooks();
}

async function request(url, options) {
    const response = await fetch(url, options);
    if (response.ok != true) {
        const error = await response.json();
        alert(error.message)
        throw new Error(error.message)
    }
    const data = await response.json();
    return data;
}

function events() {
    document.getElementById('loadBooks').addEventListener('click', getAllBooks);
    document.querySelector('table').addEventListener('click', tableClickHandler);
    document.querySelector('.createForm').addEventListener('submit', createBook);
    document.querySelector('.updateForm').addEventListener('submit', updateBook);
    cancel.addEventListener('click', (ev) => {
        ev.preventDefault();
        document.querySelector('.createForm').style.display = 'block';
        document.querySelector('.updateForm').style.display = 'none';
        ev.target.reset();
    })
    getAllBooks();
}

events();

function tableClickHandler(event) {
    if (event.target.className == 'deleteBtn') {
        const confirmed = confirm('Are you sure?');
        if(confirmed){
            const bookId = event.target.parentNode.parentNode.dataset.id;
            deleteBook(bookId);
        }
    } else if (event.target.className == 'editBtn') {
        document.querySelector('.createForm').style.display = 'none';
        document.querySelector('.updateForm').style.display = 'block';
        const bookId = event.target.parentNode.parentNode.dataset.id;
        bookForEdit(bookId);
    }
}

async function bookForEdit(bookId) {
    const book = await request('http://localhost:3030/jsonstore/collections/books/' + bookId);

    document.querySelector('.updateForm [name="id"]').value = bookId;
    document.querySelector('.updateForm [name="title"]').value = book.title;
    document.querySelector('.updateForm [name="author"]').value = book.author;
}
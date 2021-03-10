const phonebook = document.getElementById('phonebook');

function main() {
    document.getElementById('btnCreate').addEventListener('click', async() => {
        const person = document.getElementById('person').value;
        const phone = document.getElementById('phone').value;

        await createContact({ person, phone });

        getPhonebook();

        document.getElementById('person').value = '';
        document.getElementById('phone').value = '';
    });

    document.getElementById('btnLoad').addEventListener('click', getPhonebook);

}

main();


async function createContact(contact) {
    await fetch('http://localhost:3030/jsonstore/phonebook', {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(contact)
    });
}

async function onDelete(e, id) {
    const response = await fetch('http://localhost:3030/jsonstore/phonebook/' + id, {
        method: 'delete',
        headers: { 'X-Authorization': sessionStorage.getItem('token') }
    });
    if (response.ok) {
        alert('Contact deleted');
        getPhonebook();
    } else {
        const error = await response.json();
        alert(error.message);
    }
}

async function getPhonebook() {
    phonebook.innerHTML = '';
    const response = await fetch('http://localhost:3030/jsonstore/phonebook');
    const data = await response.json();
    sessionStorage.setItem('token', data.accessToken);

    Object.entries(data).forEach(([k, v]) => {
        const id = k;
        const person = v.person;
        const phone = v.phone;

        // console.log(id);
        // console.log(person);
        // console.log(phone);

        const result = e('li', { className: `data-id= ${id}` }, `${person}: ${phone}`);
        result.appendChild(e('button', { className: 'deleteBtn', onClick: (e) => onDelete(e, id) }, 'Delete'));

        phonebook.append(result);
    });
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
    console.log(result);
    return result;
}
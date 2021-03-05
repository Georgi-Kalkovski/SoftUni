
const link = 'http://localstore:3030/jsonstore/advanced/articles/details';
CRUD(link);

function CRUD(link) {

    async function getData() {
        const response = await fetch(link);
        const data = await response.json();

        console.log(data);
    }

    async function getDataById(id) {
        const response = await fetch(link + id);
        const data = await response.json();

        console.log(data);
    }

    async function postData(data) {
        const response = await fetch(link, {
            method: 'post',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(data),
        });

        const result = await response.json();
        console.log(result);
    }

    async function updateData(id, data) {
        const response = await fetch(link + id, {
            method: 'put',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(data),
        });

        const result = await response.json();
        console.log(result);
    }

    async function deleteData(id) {
        const response = await fetch(link + id, {
            method: 'delete'
        });

        const result = await response.json();
        console.log(result);
    }
}
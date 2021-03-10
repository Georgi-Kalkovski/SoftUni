function attachEvents() {
    getAllCatches();
    document.querySelector('.load').addEventListener('click', getAllCatches);
    document.querySelector('.add').addEventListener('click', addCatch);
    document.getElementById('catches').addEventListener('click', clickHandler);
}
attachEvents();
/*--- Helpful function for handeling click events ---*/
function clickHandler(event) {
    if (event.target.className == 'update') {
        const id = event.target.parentNode.dataset.id;
        updateCatch(id);
        console.log(`update`);
    } else if (event.target.className == 'delete') {
        const id = event.target.parentNode.dataset.id;
        deleteCatch(id);
    }
}

/*--- Get and display all cathces ---*/
async function getAllCatches() {
    const data = await request('http://localhost:3030/data/catches');
    const items = data.map(createCatch).join('');
    document.getElementById('catches').innerHTML = items;
    function createCatch(c) {
        const result = `<div class="catch" data-id=${c._id} id=${c._id}>
        <label>Angler</label>
        <input type="text" class="angler" value="${c.angler}" />
        <hr>
        <label>Weight</label>
        <input type="number" class="weight" value="${c.weight}" />
        <hr>
        <label>Species</label>
        <input type="text" class="species" value="${c.species}" />
        <hr>
        <label>Location</label>
        <input type="text" class="location" value="${c.location}" />
        <hr>
        <label>Bait</label>
        <input type="text" class="bait" value="${c.bait}" />
        <hr>
        <label>Capture Time</label>
        <input type="number" class="captureTime" value="${c.captureTime}" />
        <hr>
        <button class="update">Update</button>
        <button class="delete">Delete</button>
    </div>`
        return result;
    }
}

/*--- Add catch card to collection ---*/
async function addCatch() {

    const inputFields = Array.from(document.querySelectorAll('#addForm>input'));
    const angler = inputFields[0].value;
    const weight = inputFields[1].value;
    const species = inputFields[2].value;
    const location = inputFields[3].value;
    const bait = inputFields[4].value;
    const captureTime = inputFields[5].value;
    if(angler == '' || weight == '' || species == '' || location == '' || bait == '' || captureTime == ''){
        return alert('All fields are required!')
    }
    const catchToAdd = { angler, weight, species, location, bait, captureTime };
    const token = sessionStorage.getItem('authToken');
    if(!token){
        return;
    }
    const options = {
        method: 'post',
        headers: { 'Content-Type': 'application/json', 'X-Authorization': token },
        body: JSON.stringify(catchToAdd)
    }

    await request('http://localhost:3030/data/catches', options)
    inputFields[0].value = '';
    inputFields[1].value = '';
    inputFields[2].value = '';
    inputFields[3].value = '';
    inputFields[4].value = '';
    inputFields[5].value = '';
    getAllCatches();
}
/*--- Update existing catch ---*/
async function updateCatch(id) {
    const inputFields = Array.from(document.querySelectorAll(`#${id}>input`));
    console.log(inputFields);
    const angler = inputFields[0].value;
    const weight = inputFields[1].value;
    const species = inputFields[2].value;
    const location = inputFields[3].value;
    const bait = inputFields[4].value;
    const captureTime = inputFields[5].value;
    const catchToUpdate = { angler, weight, species, location, bait, captureTime };
    const token = sessionStorage.getItem('authToken');
    const options = {
        method: 'put',
        headers: { 'Content-Type': 'application/json', 'X-Authorization': token },
        body: JSON.stringify(catchToUpdate)
    }

    await request('http://localhost:3030/data/catches/' + id, options)
    inputFields[0].value = '';
    inputFields[1].value = '';
    inputFields[2].value = '';
    inputFields[3].value = '';
    inputFields[4].value = '';
    inputFields[5].value = '';
    alert('Successfully updated!')
    getAllCatches();
}

/*--- Delete existing catch ---*/
async function deleteCatch(id) {
    const token = sessionStorage.getItem('authToken');
    const confirmed = confirm('Are you sure?')
    if (confirmed) {
        await request('http://localhost:3030/data/catches/' + id, {
            method: 'delete',
            headers: { 'X-Authorization': token }
        });
        alert('Deleted')
        getAllCatches();
    }
}

/*----------------------------------------------------------*/
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
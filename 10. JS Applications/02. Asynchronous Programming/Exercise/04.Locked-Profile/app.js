function lockedProfile() {

    [...document.querySelectorAll('#main div button')].forEach(button => {
        button.addEventListener('click', show);
    })

    let usersId = [];

    getId(usersId);
}

async function getId(usersId) {

    const url = 'http://localhost:3030/jsonstore/advanced/profiles';
    const response = await fetch(url);
    const data = await response.json();
    for (const user in data) {
        const info = data[user];
        usersId.push(info._id);
    }
    for (const id of usersId) {
        const url = 'http://localhost:3030/jsonstore/advanced/profiles/' + id;
        const response = await fetch(url);
        const data = await response.json();
        const profile = document.querySelector("main div").cloneNode(true);
        profile.childNodes[5].name = 'Locked ' + id;
        profile.childNodes[9].name = 'Unlocked ' + id;
        profile.childNodes[16].name = 'Username ' + id;
        profile.childNodes[18].id = 'HiddenFields ' + id;
        profile.childNodes[18].childNodes[5].name = 'Email ' + id;
        profile.childNodes[18].childNodes[9].name = 'Age ' + id;
        //console.log(profile.childNodes[5].name = id)
        document.querySelector('#main').appendChild(profile);

    }

    document.querySelector('#main').children[0].remove();
    const main = document.querySelector('main');
    for (const prof of Object.values(main)) {
        console.log(prof)
    }


}

function show(e) {
    if (e.target.parentNode.children[4].checked && e.target.textContent === 'Show more') {
        e.target.parentNode.children[9].style.display = 'block';
        e.target.textContent = 'Hide it';
    } else if (e.target.parentNode.children[4].checked) {
        e.target.parentNode.children[9].style.display = 'none';
        e.target.textContent = 'Show more';
    }
}
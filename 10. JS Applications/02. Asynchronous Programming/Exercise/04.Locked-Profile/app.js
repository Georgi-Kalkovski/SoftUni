async function lockedProfile() {

    const url = 'http://localhost:3030/jsonstore/advanced/profiles';
    const response = await fetch(url);
    const data = await response.json();

    const main = document.getElementById('main');
    main.innerHTML = '';

    Object.values(data).forEach((user, i) => {

        i = i + 1;

        const profile =
            e('div', { class: 'profile' }, '',
                e('img', { src: './iconProfile2.png', class: 'userIcon' }),
                e('label', {}, 'Lock'),
                e('input', { type: 'radio', name: `user${i}Locked`, value: 'lock', checked: '' }),
                e('label', {}, 'Unlock'),
                e('input', { type: 'radio', name: `user${i}Locked`, value: 'unlock' }),
                e('br'),
                e('hr'),
                e('label', {}, `Username`),
                e('input', { type: 'text', name: `user${i}Username`, value: `${user.username}`, disabled: ``, randomly: `` }),
                e('div', { id: `user${i}HiddenFields` }, '',
                    e('hr'),
                    e('label', {}, 'Email:'),
                    e('input', { type: 'email', name: `user${i}Email`, value: `${user.email}`, disabled: '', randomly: '' }),
                    e('label', {}, 'Age'),
                    e('input', { type: 'email', name: `user${i}Age`, value: `${user.age}`, disabled: '', randomly: '' })),
                e('button', {}, 'Show More'));

        main.appendChild(profile);

        document.querySelector(`#user${i}HiddenFields`).style.display = 'none';
    });
    Array.from(document.querySelectorAll('button'))
        .forEach(e => e.addEventListener('click', onClick));
}

function onClick(e) {

    if (!e.target.parentNode.querySelector('input[value="lock"]:checked') &&
        e.target.parentNode.querySelector('div').style.display == 'block') {

        e.target.parentNode.querySelector('div').style.display = 'none';
        e.target.textContent = 'Show More';
    }
    else if (!e.target.parentNode.querySelector('input[value="lock"]:checked')) {

        e.target.parentNode.querySelector('div').style.display = 'block';
        e.target.textContent = 'Hide it';
    };
}

function e(type, attribute, text, ...params) {
    
    const element = document.createElement(type);

    if (attribute != {} && attribute != undefined) {

        Object.entries(attribute).forEach(([name, value]) => {
            element.setAttribute(`${name}`, `${value}`);
        });
    }
    if (text != undefined && text != '') {

        element.innerHTML = text;
    };
    if (params != undefined && params.length != 0) {

        params.forEach(e => {
            element.appendChild(e);
        });
    };

    return element;
}
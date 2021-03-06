const main = document.getElementById('main');

async function lockedProfile() {
    const profiles = await getProfiles();

    Object.values(profiles).map(createCards).forEach(o => main.appendChild(o))

}

function createCards(user, index) {
    const result = e('div', { className: 'profile' },
        e('img', { 'src': './iconProfile2.png', className: 'userIcon' }),
        e('label', {}, 'Lock'),
        e('input', { 'type': 'radio', 'name': `user${index + 1}Locked`, 'value': 'lock', 'checked': true }),
        e('label', {}, 'Unlock'),
        e('input', { 'type': 'radio', 'name': `user${index + 1}Locked`, 'value': 'unlock' }),
        e('hr'),
        e('label', {}, 'Username'),
        e('input', { 'type': 'text', 'name': `user${index + 1}Username`, 'value': user.username, 'disabled': true, 'readonly': true }),
        e('div', { 'id': `user1HiddenFields`, 'style': 'display: none' },
            e('hr'),
            e('label', '', 'Email:'),
            e('input', { 'type': 'email', 'name': `user${index + 1}Email`, 'value': user.email, 'disabled': true, 'readonly': true }),
            e('label', '', 'Age:'),
            e('input', { 'type': 'email', 'name': `user${index + 1}Age`, 'value': user.age, 'disabled': true, 'readonly': true })
        ),
        e('button', {}, 'Show more')
    )
    return result;
}

async function getProfiles() {
    const response = await fetch('http://localhost:3030/jsonstore/advanced/profiles');
    const data = await response.json();

    return data;
}



main.addEventListener('click', e => {
    if (e.target.tagName === 'BUTTON') {
        const profile = e.target.parentNode;
        const isLocked = profile
            .querySelector('input[type=radio]:checked').value == 'lock';

        if (isLocked) {
            return;
        }
        let div = profile.querySelector('div');
        let isVisible = div.style.display === 'block';
        div.style.display = isVisible ? 'none' : 'block';
        e.target.textContent = isVisible ? 'Show more' : 'Hide it';
    }
});

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

    return result;
}
function attachEvents() {
    const forms = document.querySelectorAll('form');
    forms[0].addEventListener('submit', onRegister);
    forms[1].addEventListener('submit', onLogin);
}

attachEvents();

async function request(url, options) {
    const response = await fetch(url, options);

    if (response.ok == false) {
        const error = await response.json();
        throw new Error(error);
    }

    return response.json();
}

async function onRegister(evt) {
    evt.preventDefault()

    const formData = new FormData(evt.target);
    const email = formData.get('email');
    const password = formData.get('password');
    const rePass = formData.get('rePass');

    if (!email || !password || !rePass) {
        return alert('All fields are required!');
    }

    if (password != rePass) {
        return alert('Two passwords should be the same!')
    }

    const obj = {
        email,
        password
    };

    try {
        const data = await request('http://localhost:3030/users/register', {
            method: 'post',
            headers: {
                'Content-Type': 'aplication/json'
            },
            body: JSON.stringify(obj)
        });

        alert(`Created profile with ${data.email} email!`);
    } catch (error) {
        alert(error.message);
    }

    evt.target.reset();
}

async function onLogin(evt) {
    evt.preventDefault();

    const formData = new FormData(evt.target);
    const email = formData.get('email');
    const password = formData.get('password');

    if (!email || !password) {
        return alert('All fields are required.');
    }

    try {
        const data = await request('http://localhost:3030/users/login', {
            method: 'post',
            headers: {
                'Content-Type': 'aplication/json'
            },
            body: JSON.stringify({
                email,
                password
            })
        });
        
        sessionStorage.setItem('userId', data._id);
        sessionStorage.setItem('userToken', data.accessToken);
    } catch (error) {
        return alert(error.message);
    }

    window.location.pathname = 'homeLogged.html';
}
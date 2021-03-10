function attachEvents() {
    const forms = document.querySelectorAll('form');
    forms[0].addEventListener('submit', onRegister);
    forms[1].addEventListener('submit', onLogin);
}

attachEvents();

async function onRegister(evt) {
    evt.preventDefault();
    const formData = new FormData(evt.target);

    const email = formData.get('email');
    const password = formData.get('password');
    const repeatedPass = formData.get('rePass');

    if (!email || !password || !repeatedPass) {
        return alert('All fields are required!');
    }

    if (password != repeatedPass) {
        return alert('Passwords should be the same.');
    }

    const response = await fetch('http://localhost:3030/users/register', {
        method: 'post',
        headers: {
            'Content-Type': 'aplication/json'
        },
        body: JSON.stringify({
            email,
            password
        })
    });

    if (response.ok == false) {
        return alert('Something went wrong!');
    }

    const data = await response.json();
    console.log(data);
    //sessionStorage.setItem('userToken', data.accessToken);
    document.getElementById('registerForm').style.display = 'none';
}

async function onLogin(evt) {
    evt.preventDefault();

    const formData = new FormData(evt.target);

    const email = formData.get('email');
    const password = formData.get('password');

    if (!email || !password) {
        return alert('All fields are required!');
    }

    const response = await fetch('http://localhost:3030/users/login', {
        method: 'post',
        headers: {
            'Content-Type': 'aplication/json'
        },
        body: JSON.stringify({
            email,
            password
        })
    });

    if (response.ok == false) {
        const error = await response.json();
        return alert(error.message);
    }

    const data = await response.json();
    console.log(data);
    sessionStorage.setItem('userToken', data.accessToken);
    sessionStorage.setItem('userId', data._id);
    window.location.pathname = 'index.html';
}
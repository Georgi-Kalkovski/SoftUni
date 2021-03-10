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

async function register(event) {
    event.preventDefault();
    const formData = new FormData(event.target);
    const email = formData.get('email');
    const password = formData.get('password');
    const rePass = formData.get('rePass');
    const userObj = {email, password};

    if (password != rePass) {
        return alert('The passwords don\'t match');
    }
    if (email == '' || password == '' || rePass == '') {
        return alert('Please fill all fields');
    }

    const response = await request('http://localhost:3030/users/register', {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(userObj)
    });
    let token = response.accessToken;
    sessionStorage.setItem('authToken', token);
    sessionStorage.setItem('userId', response._id);
    alert('Successful');
    event.target.reset();
}
/*--- attaching events to forms ---*/
function events() {
    const forms = document.querySelectorAll('form');
    const regForm = forms[0];
    const loginForm = forms[1];
    regForm.addEventListener('submit', register);
    loginForm.addEventListener('submit', login)
}
events();

/*--- login function ---*/
async function login(event) {
    event.preventDefault();
    const formData = new FormData(event.target);
    const email = formData.get('email');
    const password = formData.get('password');

    const data = await request('http://localhost:3030/users/login', {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ email, password })
    });
    sessionStorage.setItem('authToken', data.accessToken);
    alert(`Successful login!`);
    event.target.reset();
}
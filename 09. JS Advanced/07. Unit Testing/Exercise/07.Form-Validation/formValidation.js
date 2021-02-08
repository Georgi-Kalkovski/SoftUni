function validate() {

    const usernameRegex = /^[A-Za-z0-9]{3,20}$/;
    const emailRegex = /@(\w)*\./;
    const passwordRegex = /^[A-Za-z0-9_]{5,15}$/;
    const companyNumberRegex = /^[0-9]{4}$/;

    const username = document.getElementById('username');
    const email = document.getElementById('email');
    const password = document.getElementById('password');
    const confirmPassword = document.getElementById('confirm-password');
    const companyInfo = document.getElementById('companyInfo');
    const companyNumber = document.getElementById('companyNumber');
    const companyCheck = document.getElementById('company');
    companyCheck.addEventListener('change', onCheck)
    const submit = document.getElementById('submit');
    submit.addEventListener('click', onSubmit);
    const valid = document.getElementById('valid');

    let isValid;

    function onCheck() {
        if (companyInfo.style.display == 'none') { companyInfo.style.display = 'block' }
        else { companyInfo.style.display = 'none' }
    };

    function onSubmit(ev) {
        isValid = true;

        ev.preventDefault();

        if (!usernameRegex.test(username.value)) {
            username.style.borderColor = 'red';
            isValid = false;
        }
        else { username.style.borderColor = ''; }

        if (!emailRegex.test(email.value)) {
            email.style.borderColor = 'red';
            isValid = false;
        }
        else { email.style.borderColor = ''; }

        if (!passwordRegex.test(password.value) ||
            !passwordRegex.test(confirmPassword.value) ||
            password.value != confirmPassword.value) {
            password.style.borderColor = 'red';
            confirmPassword.style.borderColor = 'red';
            isValid = false;
        }
        else {
            password.style.borderColor = '';
            confirmPassword.style.borderColor = '';
        }

        if (companyInfo.style.display == 'block') {
            if (!companyNumberRegex.test(companyNumber.value)) {
                companyNumber.style.borderColor = 'red';
                isValid = false;
            }
            else { companyNumber.style.borderColor = ''; }
        }
        else { companyNumber.style.borderColor = '' }

        if (isValid) { valid.style.display = 'block'; }
        else { valid.style.display = 'none'; }
    }
}

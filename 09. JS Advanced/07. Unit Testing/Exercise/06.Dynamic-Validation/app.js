function validate() {

    emailRegex = /^[a-z]+@[a-z]+\.[a-z]+$/;

    document.getElementById('email')
        .addEventListener('change', function (ev) {

            if (!emailRegex.test(ev.target.value)) {
                ev.target.className = 'error';
            } else {
                ev.target.className = '';
            }
        });
}
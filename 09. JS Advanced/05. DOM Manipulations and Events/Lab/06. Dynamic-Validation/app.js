function validate() {

    const text = document.getElementById('email').addEventListener('change', onChange);
    const regex = /\S+@\S+\.\S+/;

    function onChange(e) {
        const email = e.target.value;
        if (regex.test(email)) {
            e.target.className = '';
        } else {
            e.target.className = 'error';
        }
    }
}

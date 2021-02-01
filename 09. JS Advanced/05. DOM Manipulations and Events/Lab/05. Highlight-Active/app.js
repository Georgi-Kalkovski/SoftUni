function focus() {
    // Array.from(document.querySelectorAll('input')).forEach(div => {  <-- in judge
    document.querySelectorAll('input').forEach(div => {
        div.addEventListener('focus', onFocus);
        div.addEventListener('blur', onBlur);
    });

    function onFocus(e) {
        // e.target.parentNode.className = 'focused';  <-- in judge
        e.target.parentNode.className = 'focus';
    }
    function onBlur(e) {
        e.target.parentNode.className = '';
    }
}
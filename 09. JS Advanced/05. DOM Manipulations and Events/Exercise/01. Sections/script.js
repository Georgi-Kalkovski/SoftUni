function create(words) {

    const content = document.getElementById('content');

    for (let i = 0; i < words.length; i++) {

        let div = document.createElement('div');
        let p = document.createElement('p');
        p.textContent = words[i];
        p.style.display = 'none';
        div.appendChild(p)
        content.appendChild(div);
    }

    content.addEventListener('click', onClick)

    function onClick(e) {
        if (e.target.tagName === 'DIV' || e.target.tagName === 'P') {
            const p = e.target.children[0] || e.target;
            const isVisible = p.style.display === 'block';
            p.style.display = isVisible ? 'none' : 'block';
        }
    }
}
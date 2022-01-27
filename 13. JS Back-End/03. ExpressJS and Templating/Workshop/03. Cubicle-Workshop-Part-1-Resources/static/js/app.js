document.getElementById('cars').addEventListener('click', ({target}) => {
    if (target.classList.contains('more')) {
        const desc = target.parentElement.querySelector('.description');
        if (desc.style.display == 'block') {
            desc.style.display = 'none';
            target.textContent = 'Show More';
        } else {
            desc.style.display = 'block';
            target.textContent = 'Hide';
        }
    }
});
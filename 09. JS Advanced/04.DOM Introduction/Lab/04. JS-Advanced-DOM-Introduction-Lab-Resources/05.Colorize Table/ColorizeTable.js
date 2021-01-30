function colorize() {
    let items = document.querySelectorAll('tr');
    for (let i = 1; i < items.length; i+= 2) {
        document.querySelectorAll('tr')[i].style.backgroundColor = 'Teal';
    }
}
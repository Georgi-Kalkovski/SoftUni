const sections = [...document.querySelectorAll('section')].forEach((e) => {
    if (e.id != 'years')
        e.style.display = 'none';
})
let year;
let month;
var months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sept", "Oct", "Nov", "Dec"];

const section = [...document.querySelectorAll('section')].forEach((s) => s.addEventListener('click', (e) => {
    if (s.id == 'years') {
        if (e.target.className == 'day') {
            year = e.target.textContent.trim();
            document.getElementById(`year-${year}`).style.display = 'block';
            s.style.display = 'none';
        }
    } else if (s.id == `year-${year}`) {
        if (e.target.className == 'day') {
            month = e.target.textContent.trim();
            document.getElementById(`month-${year}-${months.indexOf(month) + 1}`).style.display = 'block';
            s.style.display = 'none';
        } else if (e.target.tagName == 'CAPTION') {
            document.getElementById('years').style.display = 'block';
            s.style.display = 'none';
        }
    } else if (s.id == `month-${year}-${months.indexOf(month) + 1}`) {
        if (e.target.tagName == 'CAPTION') {
            document.getElementById(`year-${year}`).style.display = 'block'
            s.style.display = 'none';
            console.log('CAPTION')
        }
    }
}));

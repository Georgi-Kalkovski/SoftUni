const sections = [...document.querySelectorAll('section')].forEach((e) => {
    if (e.id != 'years')
        e.style.display = 'none';
})
let year;
let month;

var months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
const section = [...document.querySelectorAll('section')].forEach((e) => e.addEventListener('click', (current) => {
    if (current.target.className == 'yearsCalendar' || current.target.className == 'months' || current.target.className == 'days') { return }
    if (e.id == 'years' && current.target.tagName != 'CAPTION') {
        year = current.target.textContent.trim();
        e.style.display = 'none';
        document.getElementById(`year-${year}`).style.display = 'block';
        return;
    } else if (e.id === `year-${year}` && current.target.tagName != 'CAPTION') {
        month = current.target.textContent.trim();
        e.style.display = 'none';
        document.getElementById(`month-${year}-${months.indexOf(month) + 1}`).style.display = 'block';
        return;
    } else if (current.target.tagName == 'CAPTION') {
        if (document.getElementById(`year-${year}`).style.display != 'block') {
            document.getElementById(`year-${year}`).style.display = 'block';
            document.getElementById(`month-${year}-${months.indexOf(month) + 1}`).style.display = 'none';
            return;
        } else if (current.target.id != 'years') {
            document.getElementById(`year-${year}`).style.display = 'none';
            document.getElementById(`years`).style.display = 'block';
            return;
        }
    }
}
));
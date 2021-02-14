function solve() {
    const lecture = Array.from(document.querySelectorAll('.action input'))[0];
    const date = Array.from(document.querySelectorAll('.action input'))[1];
    const module = document.querySelector('.action select');
    const modules = document.querySelector('.modules');
    document.querySelector('.action button').addEventListener('click', add);
 
    function add(ev) {
        ev.preventDefault();
        let time = date.value;
        while (time.includes('-')) {
            time = time.replace('-', '/');
        }
        time = time.replace('T', ' - ');
        let name = lecture.value ? lecture.value : '';
        let course = module.value !== 'Select module' ? module.value.toUpperCase() + '-MODULE' : '';
        if (!time || !name || !course) {
            return;
        }
        const el = createElement('li', {className: 'flex'},
            createElement('h4', {}, name + ' - ' + time),
            createElement('button', {className: 'red', onClick: removeElement}, 'Del'));
        let section = Array.from(modules.children).find(e => e.textContent.includes(course));
        if (section === undefined) {
            section = createElement('div', {className: 'module'}, createElement('h3', {}, course), createElement('ul', {}, el));
            modules.appendChild(section);
        } else {
            let ulElement = section.querySelector('ul');
            ulElement.appendChild(el);
            Array.from(ulElement.children).sort((a, b) => {
                return a.firstChild.textContent.slice(-18).localeCompare(b.firstChild.textContent.slice(-18));
            }).forEach(e=>ulElement.appendChild(e));
        }
    }
 
    function removeElement(ev) {
        const element = ev.target.parentNode;
        const list = element.parentNode;
        element.remove();
        if (list.childElementCount == 0) {
            list.parentNode.remove();
        }
 
    }
 
    function createElement(tagName, attributes, ...content) {
        const element = document.createElement(tagName);
 
        //add attribute or event listener
        for (let attr in attributes) {
            if (attr.substring(0, 2) === 'on') {
                element.addEventListener(attr.substring(2).toLowerCase(), attributes[attr]);
            } else {
                element[attr] = attributes[attr];
            }
        }
 
        //add content or append a child element
        content.forEach(c => {
            if (typeof c === "string" || typeof c === 'number') {
                element.textContent = c;
            } else {
                element.appendChild(c)
            }
        });
        return element;
    }
}
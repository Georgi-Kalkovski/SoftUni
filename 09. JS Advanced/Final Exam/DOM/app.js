function solve() {

    const sections = document.querySelectorAll('main section');
    const section = sections[0];
    const button = document.querySelector('button')
    button.addEventListener('click', onClick);

    function onClick(e) {
        e.preventDefault();

        const author = document.getElementById('creator');
        const title = document.getElementById('title');
        const category = document.getElementById('category');
        const content = document.getElementById('content');

        const delBtn = document.createElement('button')
        delBtn.className = 'btn delete';
        delBtn.textContent = 'Delete';

        const archBtn = document.createElement('button')
        archBtn.className = 'btn archive';
        archBtn.textContent = 'Archive';

        const div = document.createElement('div')
        div.className = 'buttons';

        const p1 = document.createElement('p');
        p1.textContent = `Category:`;
        const strong1 = document.createElement('strong');
        strong1.textContent = category.value;

        const p2 = document.createElement('p');
        p2.textContent = `Creator:`;
        const strong2 = document.createElement('strong');
        strong2.textContent = author.value;

        const p3 = document.createElement('p');
        p3.textContent = content.value;

        const h1 = document.createElement('h1');
        h1.textContent = title.value;

        const article = document.createElement('article');

        div.appendChild(delBtn);
        div.appendChild(archBtn);
        p1.appendChild(strong1);
        p2.appendChild(strong2);
        article.appendChild(h1);
        article.appendChild(p1);
        article.appendChild(p2);
        article.appendChild(p3);
        article.appendChild(div);
        
        section.appendChild(article);
    }

    section.addEventListener('click', function (e) {
        if (e.target.className == 'btn delete') {
            let deleting = e.target.parentNode.parentNode;
            deleting.remove();
        }
        if (e.target.className == 'btn archive') {
            let archiving = e.target.parentNode;
            console.log(archiving.parentNode.children[0].textContent)
            const archive = document.querySelector('section.archive-section > ol')
            let title = archiving.parentNode.children[0].textContent;
            const li = document.createElement('li')
            li.textContent = title;
            archive.appendChild(li);
            e.target.parentNode.parentNode.remove();

            sortList();

            function sortList() {
                var list, i, switching, b, shouldSwitch; 5
                list = archive;
                switching = true;
                while (switching) {
                    switching = false;
                    b = list.getElementsByTagName("LI");
                    for (i = 0; i < (b.length - 1); i++) {
                        shouldSwitch = false;
                        if (b[i].innerHTML.toLowerCase() > b[i + 1].innerHTML.toLowerCase()) {
                            shouldSwitch = true;
                            break;
                        }
                    }
                    if (shouldSwitch) {
                        b[i].parentNode.insertBefore(b[i + 1], b[i]);
                        switching = true;
                    }
                }
            }
        }
    })
}


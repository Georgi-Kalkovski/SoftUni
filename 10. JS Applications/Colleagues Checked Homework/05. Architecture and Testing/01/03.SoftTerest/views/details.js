import {getDetails, deleteIdea} from '../src/api/data.js'

export function setupDetails(section, navigation){
    return showDetails;

    async function showDetails(id){
        section.innerHTML = '';
        const details = await getDetails(id)
        const element = createElement(details, navigation)
        section.appendChild(element);
        return section;
    }
}


function createElement(idea, navigation){
    const section = document.createElement('section');
    section.innerHTML = `<img class="det-img" src="${idea.img}" />
    <div class="desc">
        <h2 class="display-5">${idea.title}</h2>
        <p class="infoType">Description:</p>
        <p class="idea-description">${idea.description}</p>
    </div>`;

    if (sessionStorage.getItem('userId') == idea._ownerId) {
        const div = document.createElement('div');
        div.className = 'text-center';
        const btn = document.createElement('a');
        btn.className = 'btn detb';
        btn.setAttribute('href', '');
        btn.id = idea._id
        btn.textContent = 'Delete'
        btn.addEventListener('click', del);
        div.appendChild(btn);
        section.appendChild(div);
    }
    
    return section;

    function del(e){
        e.preventDefault();
        const confirmed = confirm("Are you shure you want to delete this idea?");

        if (confirmed) {
            deleteIdea(e.target.id);
            navigation.loadPage('dashboard');
        }
        
    }
}


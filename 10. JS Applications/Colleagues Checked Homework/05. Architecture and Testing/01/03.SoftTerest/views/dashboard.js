import {getIdeas} from '../src/api/data.js'

export function setupDashboard(section, navigation){
    return showDashboard;

    async function showDashboard(){
        section.innerHTML = '';
        const ideas = await getIdeas();
        if (ideas.length > 0) {
            const fragment = document.createDocumentFragment();
            ideas.forEach(x => {
                const element = createCard(x, navigation);
                fragment.appendChild(element);
            });
            section.appendChild(fragment);
        }
        else{
            section.innerHTML = '<h1>No ideas yet! Be the first one :)</h1>';
        }

        return section;
    }
}

function createCard(idea, navigation){
    const div = document.createElement('div');
    div.className = 'card overflow-hidden current-card details';
    div.style.width = '20rem';
    div.style.height = '18rem';
    div.innerHTML = `<div class="card-body">
    <p class="card-text">${idea.title}</p>
</div>
<img class="card-image" src="${idea.img}" alt="Card image cap">`;
  
        const btn = document.createElement('a');
   btn.className = 'btn';
   btn.id = idea._id;
   btn.setAttribute('href', '');
   btn.textContent = 'Details';
   btn.addEventListener('click', (e) => {
       e.preventDefault();
       if (sessionStorage.getItem('userToken') != null) {
        navigation.loadPage('details', e.target.id);
       }
       else{
           return alert('To see this page you have to login first!')
       }
       
   });
   
   div.appendChild(btn);
    
   
   return div;

}
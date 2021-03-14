export function setupHome(section, navigation){
    section.querySelector('a').addEventListener('click', (e)=>{
        e.preventDefault();
        navigation.goTo('dashboard');
    })
    return showHome;

    async function showHome(){
        return section;
    }
}


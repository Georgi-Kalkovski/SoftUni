export function setupHome(section, navigation){
    section.querySelector('a').addEventListener('click', (e) => {
        e.preventDefault();
        navigation.loadPage('dashboard');
    })
    return showHome;

    async function showHome(){
        return section;
    }
}
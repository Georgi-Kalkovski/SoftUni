export { setupHome }

function setupHome(section, navigation) {
    
    section.querySelector('#getStarted').addEventListener('click', (ev) => {
        ev.preventDefault();

        navigation.goTo('dashboard');
    })
    return showHome;

    async function showHome() {
        return section;
    }
}

function lockedProfile() {

    const profiles = document.getElementById('main').children;
    forFunction;
    
    function forFunction() {
        for (let i = 0; i < profiles.length; i++) {
            const profile = profiles[i];

            const lockedButton = profile.querySelector('input[type=radio]')

            profile.querySelector('button').addEventListener('click', onClick);
            let shown = true;

            function onClick() {
                if (shown == true && !lockedButton.checked) {
                    profile.querySelector('main>div>div').style.display = 'block';
                    profile.querySelector('button').childNodes[0].nodeValue = "Hide it";
                    shown = false;
                }
                else if (shown != true && !lockedButton.checked) {
                    profile.querySelector('main>div>div').style.display = 'none';
                    profile.querySelector('button').childNodes[0].nodeValue = "Show more";
                    shown = true;
                }
            }
        }
    }
}
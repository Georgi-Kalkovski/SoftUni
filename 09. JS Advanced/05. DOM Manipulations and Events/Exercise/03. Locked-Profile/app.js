function lockedProfile() {
    [...document.querySelectorAll('#main > div > button')].forEach(button => {
        button.addEventListener('click', show)
    })

    function show(e) {
        if (e.target.parentNode.children[4].checked && e.target.textContent === 'Show more') {
            e.target.parentNode.children[9].style.display = 'block';
            e.target.textContent = 'Hide it';
        } else if (e.target.parentNode.children[4].checked) {
            e.target.parentNode.children[9].style.display = 'none';
            e.target.textContent = 'Show more';
        }
    }
}

//function lockedProfile() {
//
//    const profiles = document.getElementById('main').children;
//
//    for (let i = 0; i < profiles.length; i++) {
//        const profile = profiles[i];
//
//        const lockedButton = profile.querySelector('input[type=radio]')
//
//        profile.querySelector('button').addEventListener('click', onClick);
//        let shown = true;
//
//        function onClick() {
//            if (shown == true && !lockedButton.checked) {
//                profile.querySelector('main>div>div').style.display = 'block';
//                profile.querySelector('button').childNodes[0].textContent = "Hide it";
//                shown = false;
//            }
//            else if (shown != true && !lockedButton.checked) {
//                profile.querySelector('main>div>div').style.display = 'none';
//                profile.querySelector('button').childNodes[0].textContent = "Show more";
//                shown = true;
//            }
//        }
//    }
//}
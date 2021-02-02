function lockedProfile() {
    const profiles = document.getElementById('main').children;
    for (let i = 0; i < profiles.length; i++) {
        const profile = profiles[i];
        const lockedButton = profile.querySelector('input[type=radio]:nth-child(3)');
        const unlockedButton = profile.querySelector('input[type=radio]:nth-child(5)');
        const showButton = profile.querySelector('button').addEventListener('click', onClick);

        function onClick() {
            //const hiddenInfo = e.getElementById('div');
            const userInfo = profile.querySelector('div>div');
            const label = document.createElement('label');
            profile.appendChild(userInfo.children[1])
            profile.appendChild(userInfo.children[2])
            profile.appendChild(userInfo.children[3])
            profile.appendChild(userInfo.children[4])
        }

    }
}
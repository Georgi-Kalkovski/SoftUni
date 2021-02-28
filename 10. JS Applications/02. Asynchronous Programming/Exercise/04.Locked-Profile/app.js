async function lockedProfile() {
    const showBtn = document.getElementsByTagName('button');
    const lockBtn = document.querySelector('input[type=radio]:nth-child(3)').checked;
    const unlockBtn = document.querySelector('input[type=radio]:nth-child(5)').checked;
    console.log(lockBtn)
    console.log(unlockBtn)
    const url = 'http://localhost:3030/jsonstore/advanced/profiles';

    const response = await fetch(url);
    const data = await response.json();

    if (unlockBtn) {

    }
    else if (lockBtn) {

    }

    console.log(data);
}
function lockedProfile() {
    // all user data will be stored here as objescts
    let userObjs = undefined
    getProfileDetails();
    // since there is a slight delay from the server a time out is set to
    // ensure that the needed data will be present before function execution
    setTimeout(() => {fillFirstProfile()}, 200);
    setTimeout(() => {createUserProfile()}, 200);

    // function will make a request from the server and get all the needed data
    async function getProfileDetails() {
        const url = "http://localhost:3030/jsonstore/advanced/profiles";
        const request = await fetch(url);
        const dataIDs = await request.json();
        userObjs = Object.values(dataIDs);
    }

    // function will use the user data to fill the first profile
    function fillFirstProfile() {
        let userDetails = userObjs.shift();
        let usernameEL = document.getElementsByName('user1Username')[0];
        let div = document.getElementById('user1HiddenFields');
        let emailEL = div.getElementsByTagName('input')[0];
        let ageEL = div.getElementsByTagName('input')[1];
        let btn = document.querySelector('button');
        usernameEL.value = userDetails.username;
        emailEL.value = userDetails.email;
        ageEL.value = userDetails.age;
        btn.addEventListener("click", (e) => {
            const profile = e.target.parentNode;
            const isLocked = profile
                .querySelector('input[type=radio]:checked').value === 'lock';
            console.log(isLocked)
            if (isLocked) {
                return;
            }
            let div = profile.querySelector('div');
            let isVisible = div.style.display === 'block';
            div.style.display = isVisible ? 'none' : 'block';
            e.target.textContent = !isVisible ? 'Hide it' : 'Show more';
        })
    }

    // function will create all of the other user profiles
    function createUserProfile() {
        let counter = 1;
        for (let obj of userObjs) {
            counter ++
            let mainDiv = document.createElement("div");
            mainDiv.classList.add("profile");
            let img = document.createElement("img")
            img.classList.add("userIcon");
            img.src = "./iconProfile2.png";
            mainDiv.appendChild(img);
            let labelLock = document.createElement("label");
            labelLock.textContent = "Lock"
            mainDiv.appendChild(labelLock)
            let radioOne = document.createElement("input");
            radioOne.type = "radio";
            radioOne.value = "lock";
            radioOne.name = `user${counter}Locked`
            radioOne.checked = true;
            mainDiv.appendChild(radioOne);
            let labelUnlock = document.createElement("label");
            labelUnlock.textContent = "Unlock";
            mainDiv.appendChild(labelUnlock);
            let radioTwo = document.createElement("input");
            radioTwo.type = "radio";
            radioTwo.value = "unlock";
            radioTwo.name = `user${counter}Locked`
            mainDiv.appendChild(radioTwo);
            let br = document.createElement("br");
            mainDiv.appendChild(br);
            let hr = document.createElement("hr");
            mainDiv.appendChild(hr);
            let labelUsername = document.createElement("label");
            labelUsername.textContent = "Username";
            mainDiv.appendChild(labelUsername);
            let inputUsername = document.createElement("input");
            inputUsername.type = "text";
            inputUsername.name = `user${counter}Username`;
            inputUsername.value = obj.username;
            inputUsername.disabled = true;
            inputUsername.readOnly = true;
            mainDiv.appendChild(inputUsername);
            let hiddenDiv = document.createElement("div");
            hiddenDiv.style.display = 'none';
            let hr1 = document.createElement("hr");
            hiddenDiv.appendChild(hr1);
            let labelEmail = document.createElement("label");
            labelEmail.textContent = "Email";
            hiddenDiv.appendChild(labelEmail);
            let inputEmail = document.createElement("input");
            inputEmail.type = "email";
            inputEmail.name = `user${counter}Email`;
            inputEmail.value = obj.email;
            inputEmail.disabled = true;
            inputEmail.readOnly = true;
            hiddenDiv.appendChild(inputEmail);
            let labelAge = document.createElement('label');
            labelAge.textContent = "Age";
            let inputAge = document.createElement("input");
            inputAge.type = "email";
            inputAge.name = `user${counter}Age`
            inputAge.value = obj.age;
            inputAge.disabled = true;
            inputAge.readOnly = true;
            hiddenDiv.appendChild(inputAge);
            mainDiv.appendChild(hiddenDiv);
            let btn = document.createElement("button");
            btn.textContent = "Show more"
            btn.addEventListener("click", (e) => {
                const profile = e.target.parentNode;
                const isLocked = profile
                    .querySelector('input[type=radio]:checked').value === 'lock';
                console.log(isLocked)
                if (isLocked) {
                    return;
                }
                let div = profile.querySelector('div');
                let isVisible = div.style.display === 'block';
                div.style.display = isVisible ? 'none' : 'block';
                e.target.textContent = !isVisible ? 'Hide it' : 'Show more';
            })
            mainDiv.appendChild(btn);
            let main = document.getElementById("main");
            main.appendChild(mainDiv);
        }
    }

}

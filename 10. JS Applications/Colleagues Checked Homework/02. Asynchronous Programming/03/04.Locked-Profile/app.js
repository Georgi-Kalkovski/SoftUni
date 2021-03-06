function lockedProfile() {
    // duplication
    const profileDiv = document.getElementsByClassName('profile')[0];
    createProfiles();

    // adding functionality of the buttons
    const profiles = document.getElementsByClassName("profile");
    Array.from(profiles).forEach(account => {
        account.querySelector("button")
               .addEventListener("click", toggle);
    });

    // getting and computing the response
    obtainResponse();

    
    async function obtainResponse() {
        const profiles = document.getElementsByClassName('profile');

        const response = await fetch('http://localhost:3030/jsonstore/advanced/profiles');
        const data = await response.json();
        const dataValues = Object.values(data);

        let i = 0;
        while (i < 3) {     // 3 profiles
            const username = profiles[i].children[8];
            username.value = dataValues[i].username;

            const email = profiles[i].children[9].children[2];
            email.value = dataValues[i].email;

            const age = profiles[i].children[9].children[4];
            age.value = dataValues[i].age;

            i++;
        }
    }

    function createProfiles() {
        let i = 2;
        while (i < 4) {
            const newProfile = duplicateStructure();

            newProfile.children[2].name =
                newProfile.children[2].name.replace(/\d/g, i);
            newProfile.children[4].name =
                newProfile.children[4].name.replace(/\d/g, i);

            newProfile.children[8].name =
                newProfile.children[8].name.replace(/\d/g, i);

            newProfile.children[9].id = 
                newProfile.children[9].id.replace(/\d/g, i);
            newProfile.children[9].children[2].name = 
                newProfile.children[9].children[2].name.replace(/\d/g, i);
            newProfile.children[9].children[4].name =
                newProfile.children[9].children[4].name.replace(/\d/g, i);

            profileDiv.parentElement.appendChild(newProfile);

            i++;
        }

        function duplicateStructure() {
            const newProfile = document.createElement('div');

            newProfile.className = 'profile';
            newProfile.innerHTML = profileDiv.innerHTML;

            return newProfile;
        }
    }

    function toggle(event) {
        if (event.target.parentElement.querySelector("input[value=lock]")
            .checked) {
            return;
        }

        const hiddenData = event.target.parentElement.querySelector("div");
        if (hiddenData.style.display === "block") {
            hiddenData.style.display = "none";
            hiddenData.parentElement.querySelector("button")
                .textContent = "Show more";
        } else {
            hiddenData.style.display = "block";
            hiddenData.parentElement.querySelector("button")
                .textContent = "Hide it";
        }
    }
}
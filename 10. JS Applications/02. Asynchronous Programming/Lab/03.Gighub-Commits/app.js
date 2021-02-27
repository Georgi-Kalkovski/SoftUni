async function loadCommits() {

    const username = document.getElementById('username').value;
    const repo = document.getElementById('repo').value;
    const ulCommits = document.getElementById('commits');

    const url = `https://api.github.com/repos/${username}/${repo}/commits`;

    try {
        const response = await fetch(url);
        if (response.status != 200) {
            throw new Error(`${response.status} (${response.statusText})`);
        }
        const data = await response.json();
        ulCommits.innerHTML = '';
        data.forEach(el => {
            const li = document.createElement('li');
            li.textContent = `${el.commit.author.name}: ${el.commit.message}`;
            ulCommits.appendChild(li);
        })

    }
    catch (error) {
        const li = document.createElement('li');
        li.textContent = error;
        ulCommits.appendChild(li);
    }

}
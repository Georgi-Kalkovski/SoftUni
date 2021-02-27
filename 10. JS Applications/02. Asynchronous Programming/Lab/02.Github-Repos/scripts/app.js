function loadRepos() {

	const input = document.getElementById('username').value;
	const ul = document.getElementById('repos');

	const url = `https://api.github.com/users/${input}/repos`;

	fetch(url)
		.then(response => {
			if (response.status != 200 || !response.ok) {
				throw new Error('user Not Found');
			} else {
				return response.json();
			}
		})
		.then(data => {
			ul.textContent = '';
			data.forEach(el => {
				const li = document.createElement('li');
				const a = document.createElement('a');
				a.setAttribute('href', `${el.html_url}`);
				a.textContent = el.full_name;
				li.appendChild(a);
				ul.appendChild(li);
			})
		})
		.catch(error => {
			let li = document.createElement('li');
			li.textContent = error;
			ul.appendChild(li);
		})

}
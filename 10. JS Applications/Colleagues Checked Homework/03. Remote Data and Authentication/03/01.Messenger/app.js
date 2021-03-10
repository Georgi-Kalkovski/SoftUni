function attachEvents() {
    getMsg();
    document.getElementById('submit').addEventListener('click', sendMsg);
    document.getElementById('refresh').addEventListener('click', getMsg);
    getMsg();
}

async function getMsg() {
    const allMsg = document.getElementById('messages');
    const url = 'http://localhost:3030/jsonstore/messenger';
    const response = await fetch(url);
    const data = await response.json();
    let messages = Object.values(data).map(m => `${m.author}: ${m.content}`);
    allMsg.value = messages.join('\n');
}

async function sendMsg() {
    const author = document.querySelector('input[name="author"]').value;
    const content = document.querySelector('input[name="content"]').value;
    document.querySelector('input[name="author"]').value = '';
    document.querySelector('input[name="content"]').value = '';
    const url = 'http://localhost:3030/jsonstore/messenger';
    const response = await fetch(url, {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ author, content })
    });
    getMsg();
}

attachEvents();
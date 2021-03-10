const url = 'http://localhost:3030/jsonstore/messenger';

function attachEvents() {
    document.getElementById('submit').addEventListener('click', onSend);
    document.getElementById('refresh').addEventListener('click', onRefresh);
}

attachEvents();

async function onSend() {
    const author = document.querySelector('input[name=author]').value;
    const message = document.querySelector('input[name=content]').value;

    const response = await fetch(url, {
        method: 'post',
        headers: { 'Content-Type': 'aplication/json'},
        body: JSON.stringify({ author, content: message })
    });

    if(response.ok == false) {
        return alert('Something went wrong');
    }

    document.querySelector('input[name=author]').value = '';
    document.querySelector('input[name=content]').value = '';
}

async function onRefresh() {
    const response = await fetch(url);
    
    if(response.ok == false) {
        return alert('No messages');
    }

    const data = await response.json();

    document.getElementById('messages').value = Object.values(data).map(m => `${m.author}: ${m.content}`).join('\n');
}
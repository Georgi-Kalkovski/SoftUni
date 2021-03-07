function attachEvents() {

    // Load Messages
    getMessages();

    // Event listener for the Send Button
    document.getElementById('submit')
        .addEventListener('click', () => {
            const author = document.getElementById('author').value;
            const content = document.getElementById('content').value;

            sendMessage({ author, content })
            document.getElementById('author').value = '';
            document.getElementById('content').value = '';
        });

    // Event listener for the Refresh Button
    document.getElementById('refresh')
        .addEventListener('click', () => { getMessages() });
}

attachEvents();

// Load Messages
async function getMessages() {
    const response = await fetch('http://localhost:3030/jsonstore/messenger');
    const data = await response.json();

    const messages = Object.values(data).map(v => `${v.author}: ${v.content}`).join('\n');
    document.getElementById('messages').value = messages;
}

// Send Message
async function sendMessage(message) {
    const response = await fetch('http://localhost:3030/jsonstore/messenger', {
        method: 'post',
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify(message),
    });
}
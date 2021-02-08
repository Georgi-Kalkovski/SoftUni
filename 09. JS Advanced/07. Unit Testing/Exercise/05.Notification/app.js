function notify(message) {
    const notification = document.getElementById('notification');
    notification.addEventListener('click', hideNotification);
    notification.style.display = 'block';
    notification.textContent = message;

    function hideNotification() {
        notification.style.display = 'none';
    };
}
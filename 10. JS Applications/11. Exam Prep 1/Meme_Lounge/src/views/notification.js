const notification = document.getElementById('errorBox');

export function showNotification(message) {
    notification.querySelector('span').textContent = message;
    notification.style.display = 'block';
    setTimeout(() => notification.style.display = 'none', 3000)
}
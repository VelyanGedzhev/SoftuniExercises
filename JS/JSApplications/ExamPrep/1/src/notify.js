const element = document.getElementById('errorBox');
const messageSpan = element.querySelector('span');

export function notify(message) {
    messageSpan.textContent = message;
    element.style.display = 'block';

    setTimeout(() => element.style.display = 'none', 3000);
}
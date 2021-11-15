function attachEvents() {
    document
        .getElementById('refresh')
        .addEventListener('click', loadMessages);

    document
        .getElementById('submit')
        .addEventListener('click', onSubmit);

    loadMessages();
}

const url = 'http://localhost:3030/jsonstore/messenger';
const messagesArea = document.getElementById('messages');   
const authorInput = document.querySelector('[name="author"]');
const contentInput = document.querySelector('[name="content"]');

attachEvents();

async function loadMessages() {
    const response = await fetch(url);
    const data = await response.json();

    const messages = Object.values(data);

    messagesArea.value = messages
                            .map(m => `${m.author}: ${m.content}`)
                            .join('\n');
}

async function createMessage(message) {
    const options = {
        method: 'post',
        header: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(message)
    };

    const response = await fetch(url, options);
    const result = await response.json();

    return result;
}

async function onSubmit() {
    const author = authorInput.value;
    const content = contentInput.value;

    const result = await createMessage({author, content});
    
    contentInput.value = '';
    messagesArea += '\n' + `${author}: ${content}`;
}
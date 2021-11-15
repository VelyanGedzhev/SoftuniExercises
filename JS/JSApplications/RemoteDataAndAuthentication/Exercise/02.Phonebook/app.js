function attachEvents() {
    document
        .getElementById('btnLoad')
        .addEventListener('click', loadContacts);

    document
        .getElementById('btnCreate')
        .addEventListener('click', onCreate);

    phonebook.addEventListener('click', onDelete);

    loadContacts();
}

const phonebook = document.getElementById('phonebook');
const personInput = document.getElementById('person');
const phoneInput = document.getElementById('phone');

attachEvents();

async function loadContacts() {
    const response = await fetch('http://localhost:3030/jsonstore/phonebook');
    const data = await response.json();

    phonebook.replaceChildren(...Object.values(data).map(createItem));
}

function createItem(contact) {
    const liElement = document.createElement('li');
    liElement.innerHTML = `${contact.person}: ${contact.phone} <button data-id=${contact._id}>[Delete]</button`;

    return liElement;
}

async function createContact(contact) {
    const options = {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(contact)
    };

    const response = await fetch('http://localhost:3030/jsonstore/phonebook', options);

    const result = await response.json();
    return result;
}

async function removeContact(id) {
    const response = await fetch(`http://localhost:3030/jsonstore/phonebook/${id}`, {
        method: 'delete'
    });

    const result = await response.json();

    return result;
}

async function onCreate() {
    const person = personInput.value;
    const phone = phoneInput.value;
    const contact = {person, phone};

    const respone = await createContact(contact);

    phonebook.appendChild(createItem(respone));

    personInput.value = '';
    phoneInput.value = '';
}

async function onDelete(event) {
    const id = event.target.dataset.id;

    if (id == undefined) {
        return;
    }

    await removeContact(id);
    const elementToRemove = event.target.parentElement.remove();
}
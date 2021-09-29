function addItem() {

    const valueToAdd = document.getElementById('newItemText');

    const newLiElement = document.createElement('li');
    newLiElement.textContent = valueToAdd.value;

    const deleteButton = document.createElement('a');
    deleteButton.href = '#';
    deleteButton.textContent = '[Delete]';
    deleteButton.addEventListener('click', removeElement);

    newLiElement.appendChild(deleteButton);

    document.getElementById('items').appendChild(newLiElement);
    valueToAdd.value = '';

    function removeElement(ev) {
        const parent = ev.target.parentNode;
        parent.remove();
    }
}
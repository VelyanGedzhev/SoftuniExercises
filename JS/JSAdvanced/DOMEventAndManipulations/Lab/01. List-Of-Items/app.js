function addItem() {
    
    const valueToAdd = document.getElementById('newItemText');
    const newLiElement = document.createElement('li');
    newLiElement.textContent = valueToAdd.value;

    document.getElementById('items').appendChild(newLiElement);
    valueToAdd.value = '';
}
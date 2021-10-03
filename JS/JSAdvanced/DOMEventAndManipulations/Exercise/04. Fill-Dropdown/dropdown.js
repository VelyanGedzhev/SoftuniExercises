function addItem() {
    const itemTextElement = document.getElementById('newItemText');
    const itemValueElement = document.getElementById('newItemValue');
    const selectElement = document.getElementById('menu');

    let option = document.createElement('option');
    option.textContent = itemTextElement.value;
    option.value = itemValueElement.value;
    selectElement.appendChild(option);

    itemTextElement.value = '';
    itemValueElement.value = '';
}
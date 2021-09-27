function toggle() {
    let button = document.getElementsByClassName('button')[0];
    let extraTextElement = document.getElementById('extra');

    if (button.textContent === 'More'){
        extraTextElement.style.display = 'block';
        button.textContent = 'Less';
    } else if (button.textContent === 'Less'){
        extraTextElement.style.display = 'none';
        button.textContent = 'More';
    }
}
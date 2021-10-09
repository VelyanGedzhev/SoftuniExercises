function validate() {
    const inputField = document.getElementById('email');
    const validEmailPattern = /(^[a-z]+@[a-z]+.[a-z]+$)/;

    inputField.addEventListener('change', () => {
        if (!validEmailPattern.test(inputField.value)) {
            inputField.classList.add('error');
        } else {
            inputField.classList.remove('error');
        }
    });
}
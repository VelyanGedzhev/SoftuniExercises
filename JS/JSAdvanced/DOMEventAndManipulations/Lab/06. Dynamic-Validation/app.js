function validate() {
    document.getElementById('email').addEventListener('change', onChange);

    function onChange({target}) {
        const input = target.value;
        const pattern = /^[a-z]+@[a-z]+\.[a-z]+$/;

        if (pattern.test(input)) {
            target.classList.remove('error');
        } else {
            target.classList.add('error');
        }
    }
}
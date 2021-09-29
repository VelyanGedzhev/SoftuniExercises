function focused() {
    const inputFields = Array
        .from(document.getElementsByTagName('input'))
        .forEach(f => {
            f.addEventListener('focus', onSelect);
            f.addEventListener('blur', onDeselect);
        });


    function onSelect(ev) {
        ev.target.parentNode.className = 'focused';
    }

    function onDeselect(ev) {
        ev.target.parentNode.className = '';
    }
}
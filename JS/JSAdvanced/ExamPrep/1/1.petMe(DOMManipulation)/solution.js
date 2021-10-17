function solve() {
    const fields = document.querySelectorAll('#container input');
    const addButton = document.querySelector('#container button');
    const petList = document.querySelector('#adoption ul');
    const adoptedList = document.querySelector('#adopted ul');

    const input = {
        name: fields[0],
        age: fields[1],
        kind: fields[2],
        owner: fields[3],
    }

    addButton.addEventListener('click', addPet);

    function addPet(event) {
        event.preventDefault();

        const name = input.name.value.trim();
        const age = Number(input.age.value.trim());
        const kind = input.kind.value.trim();
        const owner = input.owner.value.trim();

        if (name == '' || 
        Number.isNaN(age) || 
        input.age.value.trim() == '' ||
        kind == '' ||
        owner == '') {
            return;
        }

        const contactButton = e('button', {}, 'Contact with owner');

        const pet = e(
            'li', 
            {},
            e('p', {}, 
                e('strong', {}, name),
                ' is a ',
                e('strong', {}, age),
                ' year old ',
                e('strong', {}, kind)
            ),
            e('span', {}, `Owner: ${owner}`),
            contactButton
        );

        contactButton.addEventListener('click', contact);

        petList.appendChild(pet);

        input.name.value = '';
        input.age.value = '';
        input.kind.value = '';
        input.owner.value = '';

        //Array.from(fields).forEach(f => f.value = '');

        function contact() {
            const confirmInput = e('input', {placeholder: 'Enter your names'});
            const confirmButton = e('button', {}, 'Yes! I take it!');
            const confirmDiv = e(
                'div',
                {},
                confirmInput,
                confirmButton
            );

            confirmButton.addEventListener('click', adopt.bind(null, confirmInput, pet));

            contactButton.remove();

            pet.appendChild(confirmDiv);
        }
    }

    function adopt(input, pet) {
        const newOnwer = input.value.trim(); 

        if (newOnwer == '') {
            return;
        }

        const checkButton = e('button', {}, 'Checked');
        checkButton.addEventListener('click', check.bind(null, pet));

        pet.querySelector('div').remove();  
        pet.appendChild(checkButton);   
        
        pet.querySelector('span').textContent = `New Owner: ${newOnwer}`;

        adoptedList.appendChild(pet);

        
    }

    function check(pet) {
            pet.remove();
    }

    function e(type, attributes, ...content) {
        const element = document.createElement(type);

        for (let prop in attributes) {
            element[prop] = attributes[prop];
        }

        for (let item of content) {

            if (typeof item == 'string' || typeof item == 'number') {
                item = document.createTextNode(item);
            }
            element.appendChild(item);
        }

        return element;
    }
}


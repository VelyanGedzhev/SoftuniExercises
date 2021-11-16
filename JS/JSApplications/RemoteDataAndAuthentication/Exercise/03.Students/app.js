function attachEvents() {
    loadStudents();
    const form = document.getElementById('form');
    form.addEventListener('submit', onSubmit);
}

attachEvents();

const tbody = document.querySelector('tbody');

async function loadStudents() {
    try {
        const students = await fetchStudents();

        for (let student of students) {
            const tr = createTr(student.firstName, student.lastName,
                student.facultyNumber, student.grade.toFixed(2));
            tbody.appendChild(tr);
        }
    } catch (error) {
        alert(error.message);
    }
}

async function onSubmit(ev) {
    ev.preventDefault();
    const form = ev.target;
    const formData = new FormData(form);
    const firstName = formData.get('firstName');
    const lastName = formData.get('lastName');
    const facultyNumber = Number(formData.get('facultyNumber'));
    const grade = Number(formData.get('grade'));

    try {
        if (firstName === '' || lastName === '' ||
            Number.isNaN(facultyNumber) || Number.isNaN(grade)) {
            throw new Error('The given student data is invalid!');
        }

        const student = {
            firstName,
            lastName,
            facultyNumber: facultyNumber.toString(),
            grade
        };
        await postStudent(student);
        form.reset();
        const tr = createTr(student.firstName, student.lastName,
            student.facultyNumber, student.grade.toFixed(2));
        tbody.appendChild(tr);
    } catch (error) {
        alert(error.message);
    }
}

async function postStudent(student) {
    const options = {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(student)
    };
    const url = 'http://localhost:3030/jsonstore/collections/students';
    const response = await fetch(url, options);

    if (response.ok !== true) {
        throw new Error('Student was not created successfully!');
    }

    await response.json();
}

async function fetchStudents() {
    const url = 'http://localhost:3030/jsonstore/collections/students';
    const response = await fetch(url);

    if (response.status !== 200) {
        throw new Error('Error! Data was not fetched successfully!');
    }

    const data = await response.json();

    return Object.values(data);
}

function createTr(firstName, lastName, facultyNumber, grade) {
    return createStructure('tr',
        createStructure('td', firstName),
        createStructure('td', lastName),
        createStructure('td', facultyNumber),
        createStructure('td', grade));
}

function createStructure(type, ...content) {
    const element = document.createElement(type);

    for (let item of content) {
        if (typeof item === 'string') {
            item = document.createTextNode(item);
        }

        element.appendChild(item);
    }

    return element;
}
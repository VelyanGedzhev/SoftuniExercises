async function getInfo() {
    const stopId = document.getElementById('stopId').value;
    const url = `http://localhost:3030/jsonstore/bus/businfo/${stopId}`;
    const result = document.getElementById('stopName');
    const timeTableElement = document.getElementById('buses');
    timeTableElement.innerHTML = '';

    try {
        let response = await fetch(url);

        if (response.status != 200) {
            throw new Error('Stop Id not found');
        }

        let data = await response.json();

        result.textContent = data.name;
        Object.entries(data.buses).forEach(b => {
            const liElement = document.createElement('li');
            liElement.textContent  = `Bus ${b[0]} arrives in ${b[1]} minutes`;
        
            timeTableElement.appendChild(liElement);
        });

    } catch (error) {
        result.textContent = 'Error';
    }
}
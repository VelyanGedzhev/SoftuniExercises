//Task 1. Calorie Object
function composeCalories(inputArr) {
    const caloriesObject = {};

    for (let i = 0; i < inputArr.length; i += 2) {
        caloriesObject[inputArr[i]] = Number(inputArr[i + 1]);
    }

    console.log(caloriesObject);
}

//Task 2. Construction Crew
function constructionCrew(worker) {

    if (worker.dizziness) {
        worker.levelOfHydrated += Number(weight) * Number(experience) * 0.1;
        worker.dizziness = false;
    }

    return worker;
}

//Task 3. Car Factory
function carFactory(car) {
    car.engine = getEngine(car.power);
    car.carriage = getCarige(car.carriage, car.color);
    car['wheels'] = getWheels(car.wheelsize);
    delete car.color;

    return car;

    function getEngine(power) {

        if (power <= 90) {
            return { power: 90, volume: 1800 };
        } else if (power <= 120) {
            return { power: 120, volume: 2400 };
        } else {
            return { power: 200, volume: 3500 };
        }
    }

    function getCarige(type, color) {

        if (type == 'hatchback') {
            return { type: 'hatchback', color }
        } else {
            return { type: 'coupe', color }
        }
    }

    function getWheels(size){

        size = size % 2 == 0 ? size - 1 : size;

        return Array(4).fill(size);
    }
}

//Task 4. Heroic Inventory
function heroRegister(heroes){
    const heroesResult = [];

    heroes.forEach(element => {
        let [name, level, items] = element.split(' / ');
        heroesResult.push({
            name,
            level: Number(level),
            items: items ? items.split(', ') : []
        })
    });

    console.log(JSON.stringify(heroesResult));
}

//Task 5. Lowest Prices in Cities
function getLowestPricesInCities(cities){
    const catalogue = {};

    cities.forEach((element) => {
        let [town, product, price] = element.split(' | ');
        price = Number(price);

        if(!catalogue[product]){
            catalogue[product] = {};
        }

        catalogue[product][town] = price;
    });

    for (const product in catalogue){
        const sorted = Object
            .entries(catalogue[product])
            .sort((a, b) => a[1] - b[1]);

            console.log(`${product} -> ${sorted[0][1]} (${sorted[0][0]})`);
    }
}

//Task 6. Store Catalogue
function createSortedCatalogue(data) {

    let productsCatalogue = {};

    for (let i = 0; i < data.length; i++) {
        let [productName, productPrice] = data[i].split(' : ');
        productPrice = Number(productPrice);
        let initial = productName[0].toUpperCase();

        if (!productsCatalogue.hasOwnProperty(initial)){
            productsCatalogue[initial] = {};
        }

        productsCatalogue[initial][productName] = productPrice;
    }
        let result = [];
        let sortedByInitials = Object.keys(productsCatalogue)
            .sort((a, b) => a.localeCompare(b));

        for (const initial of sortedByInitials) {
            let sortedProducts = Object.entries(productsCatalogue[initial])
                .sort((a, b) => a[0].localeCompare(b[0]));
            result.push(initial);
            let productsAsStrings = sortedProducts.map(product => `  ${product[0]}: ${product[1]}`)
                .join('\n');
            result.push(productsAsStrings);
        }

        return result.join('\n');
}

//Task 7. Towns to JSON
function townsToJSON(data) {

    let townsData = [];

    for (let i = 1; i < data.length; i++) {
        let splitData = data[i].split(/ \| +|\| | \|/).filter(a => a);
        let latitudeAsString = Number(splitData[1])
            .toLocaleString(undefined,
                { maximumFractionDigits: 2, minimumFractionDigits: 1 });
        let longitudeAsString = Number(splitData[2])
            .toLocaleString(undefined,
                { maximumFractionDigits: 2, minimumFractionDigits: 1 });
        let town = {
            Town: splitData[0],
            Latitude: Number(latitudeAsString),
            Longitude: Number(longitudeAsString)
        };
        townsData.push(town);
    }

    let json = JSON.stringify(townsData);
    return json;
}

//Task 8. Rectangle
function createRectangleObject(width, height, color) {

    let colorWithFirstCharUppercased = color.charAt(0).toUpperCase() + color.slice(1);
    let rectangle = {
        width: width,
        height: height,
        color: colorWithFirstCharUppercased,
        calcArea() {
            return this.width * this.height;
        }
    }

    return rectangle;
}
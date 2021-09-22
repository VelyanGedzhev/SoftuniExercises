//Task 1. City Record
function setAndGetCity(name, population, treasury) {
    const city = {
        name,
        population,
        treasury
    }

    return city;
}

//Task 2. Town Population
function citiesRegistry(citiesArr) {
    const cities = {}

    for (let cityAsString of citiesArr) {
        let [name, population] = cityAsString.split(' <-> ');
        population = Number(population);

        if (cities[name] != undefined) {
            population += cities[name];
        }

        cities[name] = population;
        
    }

    for (let city in cities) {
        console.log(`${city} : ${cities[city]}`);
    }
}

//Task 3. City Taxes
function cityTaxes(name, population, treasury) {
    return {
        name, population, treasury,
        taxRate: 10,
        collectTaxes() {
            this.treasury += this.population * this.taxRate;
        },
        applyGrowth(percentage){
            this.population += Math.floor(this.population * percentage / 100);
        },
        applyRecession(){
            this.treasury -= Math.floor(this.treasury * percentage / 100);
        },
    };
}

//Task 4. Object Factory
function factory(library, orders){
    return orders.map(compose);

    function compose(order){
        const result = Object.assign({}, order.template);

        for (let part of order.parts){
            result[part] = library[part];
        } 

        return result;
    }
}

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
function createCityRecord(name, population, treasury) {

    const record = {
        name,
        population,
        treasury,
        taxRate: 10,
        collectTaxes() {
            this.treasury += Math.floor(this.population * this.taxRate);
        },
        applyGrowth(percentage) {
            this.population += Math.floor(this.population * (percentage / 100));
        },
        applyRecession(percentage) {
            this.treasury -= Math.ceil(this.treasury * (percentage / 100));
        }
    };

    return record;
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

//Task 5.Assembly Line
function createAssemblyLine() {

    return {
        hasClima: (car) => {
            car.temp = 21;
            car.tempSettings = 21;
            car.adjustTemp = () => {
                if (car.temp < car.tempSettings) {
                    car.temp++;
                } else if (car.temp > car.tempSettings) {
                    car.temp--;
                }
            };
        },
        hasAudio: (car) => {
            car.currentTrack = { name: '', artist: '' };
            car.nowPlaying = () => {
                if (car.currentTrack !== null) {
                    console.log(`Now playing '${car.currentTrack.name}' by ${car.currentTrack.artist}`);
                }
            };
        },
        hasParktronic: (car) => {
            car.checkDistance = (distance) => {
                let message = '';

                if (distance < 0.1) {
                    message = 'Beep! Beep! Beep!';
                } else if (distance >= 0.1 && distance < 0.25) {
                    message = 'Beep! Beep!';
                } else if (distance >= 0.25 && distance < 0.5) {
                    message = 'Beep!';
                }

                console.log(message);
            };
        }
    };
}
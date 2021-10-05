// Task 1. Sort Array
function sortArray(arr, command) {

    if (command == 'asc') {
        return arr.sort((a, b) => a - b);
    }

    return arr.sort((a, b) => b - a);
}

// console.log(sortArray([14, 7, 17, 6, 8], 'asc'));
// console.log(sortArray([14, 7, 17, 6, 8], 'desc'));

// Task 2. Argument Info
function argumentInfo(...arr) {
    let typeObj = {};
    arr.forEach(el => {
        solve(el)
    })
    Object.entries(typeObj)
        .sort((a, b) => b[1] - a[1])
        .map(x => console.log(`${x[0]} = ${x[1]}`));

    function solve(x) {
        let counter = 0;
        !typeObj.hasOwnProperty(typeof x) ? typeObj[typeof x] = ++counter : typeObj[typeof x] += ++counter;
        console.log(`${typeof x}: ${x}`);
    }
}

//argumentInfo({ name: 'bob' }, 3.333, 9.999)

// Task 3. Fibonacci
function getFibonator() {
    let num1 = 0
    let num2 = 1
    return () => {
        let result = num1 + num2
        num1 = num2
        num2 = result
        return num1
    }
}

// Task 4. Breakfast Robot
function robot() {
    const recipes = {
        apple: { carbohydrate: 1, flavour: 2 },
        lemonade: { carbohydrate: 10, flavour: 20 },
        burget: { carbohydrate: 5, fat: 7, flavour: 3 },
        eggs: { protein: 5, fat: 1, flavour: 1 },
        turkey: { protein: 10, carbohydrate: 10, fat: 10, flavour: 10 }
    };

    const storage = {
        carbohydrate: 0,
        flavour: 0,
        fat: 0,
        protein: 0
    };

    function restock(element, quantity) {
        storage[element] += Number(quantity);
        return 'Success';
    }

    function prepare(recipe, quantity) {
        const remainingStorage = {};

        for (let element in recipes[recipe]) {
            const remaining = storage[element] - recipes[recipe][element] * quantity;

            if (remaining < 0) {
                return `Error: not enough ${element} in stock`;
            } else {
                remainingStorage[element] = remaining;
            }
        }

        Object.assign(storage, remainingStorage);
        return 'Success';
    }

    function report() {
        return `protein=${storage.protein} carbohydrate=${storage.carbohydrate} fat=${storage.fat} flavour=${storage.flavour}`;
    }

    function control(str) {
        const [command, item, quantity] = str.split(' ');

        switch(command) {
            case 'restock': return restock(item, quantity);
            case 'prepare': return prepare(item, quantity);
            case 'report': return report();
        }
    }

    return control;
}

let manager = robot (); 
console.log (manager ("restock flavour 50")); // Success 
console.log (manager ("prepare lemonade 4")); // Error: not enough carbohydrate in stock 

// Task 5. Functional Sum
function sum(num) {
    let sum = num;

    function add(num2) {
        sum += num2;
        return add;
    }

    add.toString = () => {
        return sum;
    }

    return add;
}
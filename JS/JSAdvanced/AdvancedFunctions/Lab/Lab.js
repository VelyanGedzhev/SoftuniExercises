// Task 1. Area and Volume Calculator
function area() {
    return Math.abs(this.x * this.y);
};

function vol() {
    return Math.abs(this.x * this.y * this.z);
};

function solve(area, vol, input) {
    const cubes = JSON.parse(input);
    const result = [];

    for (let cube of cubes) {
        const cubeArea = area.apply(cube);
        const cubeVolume = vol.apply(cube);

        result.push({
            area: cubeArea,
            volume: cubeVolume
        });
    }

    return result;
}

const input = `[
    {"x":"1","y":"2","z":"10"},
    {"x":"7","y":"7","z":"10"},
    {"x":"5","y":"2","z":"10"}
]`;

console.log(solve(area, vol, input));

// Task 2. Add
function solution(n) {
    return function sum(num) {
        return num + n
    }
}

// Task 3. Currency Format
function currencyFormatter(separator, symbol, symbolFirst, value) {
    let result = Math.trunc(value) + separator;
    result += value.toFixed(2).substr(-2,2);
    if (symbolFirst) return symbol + ' ' + result;
    else return result + ' ' + symbol;
}

function createFormatter(separator, symbol, symbolFirst, formatter){
    return (value) => formatter(separator, symbol, symbolFirst, value);
}

let dollarFormatter = createFormatter(',', '$', true, currencyFormatter);
console.log(dollarFormatter(5345));   // $ 5345,00
console.log(dollarFormatter(3.1429)); // $ 3,14
console.log(dollarFormatter(2.709));  

// Task 4.
function filterEmpl2(data, criteria) {
    criteria = criteria.split('-');
    let count = 0;
    JSON.parse(data).forEach(x => sorted.call(x));

    function sorted() {
        if (this[criteria[0]] === criteria[1] || criteria[0] === 'all') {
            console.log(`${count++}. ${this.first_name} ${this.last_name} - ${this.email}`)
        }
    }
}

// Task 5. Command Processor
function createProcessor() {
    let state = '';

    return {
        append,
        removeEnd,
        removeStart,
        print
    };

    function append(str) {
        state += str;
    }

    function removeStart(n) {
        state = state.slice(n);
    }

    function removeEnd(n) {
        state = state.slice(0, -n);
    }

    function print() {
        console.log(state);
    }
}    

let firstZeroTest = createProcessor();
firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();

let secondZeroTest = createProcessor();
secondZeroTest.append('123');
secondZeroTest.append('45');
secondZeroTest.removeStart(2);
secondZeroTest.removeEnd(1);
secondZeroTest.print();


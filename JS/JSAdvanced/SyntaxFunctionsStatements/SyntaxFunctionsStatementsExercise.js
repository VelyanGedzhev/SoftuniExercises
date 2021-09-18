//Task 1. Fruit
function calculateFruits(fruit, weight, price){
    let weighthInKg = weight / 1000;
    let neededSum = weighthInKg * price;

    console.log(`I need $${neededSum.toFixed(2)} to buy ${weighthInKg.toFixed(2)} kilograms ${fruit}.`);
}

//calculateFruits('orange', 2500, 1.80);

//Task 2. Greatest Common Divisor – GCD
function findDivisor(x, y){
    x = Math.abs(x);
    y = Math.abs(y);
    while(y) {
        let t = y;
        y = x % y;
        x = t;
    }
    console.log(x);
}

//findDivisor(15, 5);
//findDivisor(2154, 458);

//Task 3. Same Numbers
function findIfTheSame(input){
    let isTheSame = true;
    let inputAsString = String(input);
    let length = inputAsString.length;
    let sum = 0;

    for(let i = 0; i < length; i++){
        let currentChar = inputAsString.charAt(i);
        sum += Number(currentChar);

        if(currentChar != inputAsString.charAt(i + 1) &&
        i < length - 1){
            isTheSame = false;
        }
    }

    console.log(isTheSame);
    console.log(sum);
}

//findIfTheSame(2222222);
//findIfTheSame(1234);

//Task 4. Previous Day
function getPreviousDay(year, month, day){
    let dateAsString = `${year}-${month}-${day}`;
    let date = new Date(dateAsString);
    date.setDate(day - 1);

    console.log(`${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()}`);
}

getPreviousDay(2016, 9, 30);
getPreviousDay(2016, 10, 1);

//Task 5. Time to Walk
function timeToWalk(steps, stepLength, kmPerSecond) {

    let totalDistanceInMeters = steps * stepLength;
    let breaksCount = Math.trunc(totalDistanceInMeters / 500);
    let allBreaksInSeconds = breaksCount * 60;
    let metersPerSecond = kmPerSecond * 0.277777778;
    let neededTimeToWalkToUniInSeconds = (totalDistanceInMeters / metersPerSecond) + allBreaksInSeconds;
    let time = new Date('2020-02-09 00:00:00');
    time.setSeconds(neededTimeToWalkToUniInSeconds);

    function covertToString(numberAsInt) {
        let numberAsString;

        if (numberAsInt == 0) {
            numberAsString = '00';
        } else if (numberAsInt > 1 && numberAsInt < 9) {
            numberAsString = `0${numberAsInt}`;
        } else {
            numberAsString = String(numberAsInt);
        }

        return numberAsString;
    }

    let hourAsString = covertToString(time.getHours());
    let minutesAsString = covertToString(time.getMinutes());
    let secondsAsString = covertToString(time.getSeconds() + 1);

    console.log(`${hourAsString}:${minutesAsString}:${secondsAsString}`);
}

//Task 6. Road Radar
function getMessageFromRadar(driverSpeed, area) {

    let message;

    switch (area) {
        case 'motorway':
            message = getMessage(driverSpeed, 130);
            break;
        case 'interstate':
            message = getMessage(driverSpeed, 90);
            break;
        case 'city':
            message = getMessage(driverSpeed, 50);
            break;
        case 'residential':
            message = getMessage(driverSpeed, 20);
            break;

    }

    console.log(message);

    function getMessage(driverSpeed, speedLimit) {

        let message;

        if (driverSpeed <= speedLimit) {
            message = `Driving ${driverSpeed} km/h in a ${speedLimit} zone`;
        } else {
            let overTheLimit = driverSpeed - speedLimit;
            let status;

            if (overTheLimit <= 20) {
                status = 'speeding';
            } else if (overTheLimit > 20 && overTheLimit <= 40) {
                status = 'excessive speeding';
            } else if (overTheLimit > 40) {
                status = 'reckless driving';
            }

            message = `The speed is ${overTheLimit} km/h faster than the allowed speed of ${speedLimit} - ${status}`;
        }

        return message;
    }
}

//Task 7. Cooking by Numbers
function cookNumbers(numberAsString, instruction1, instruction2,
    instruction3, instruction4, instruction5) {

    let number = Number(numberAsString);
    let currResult = number;
    let array = [instruction1, instruction2,
        instruction3, instruction4, instruction5
    ];

    for (let index = 0; index < array.length; index++) {
        let instruction = array[index];

        switch (instruction) {
            case 'chop':
                currResult /= 2;
                console.log(currResult);
                break;
            case 'dice':
                currResult = Math.sqrt(currResult);
                console.log(currResult);
                break;
            case 'spice':
                currResult += 1;
                console.log(currResult);
                break;
            case 'bake':
                currResult *= 3;
                console.log(currResult);
                break;
            case 'fillet':
                let toSubtract = currResult * 20.00 / 100.00;
                currResult = currResult - toSubtract;
                console.log(currResult);
                break;
        }
    }
}

//Task 8. Validity Checker
function printValidity(x1, y1, x2, y2) {

    function getDistance(x1, y1, x2, y2) {
        let distH = x1 - x2;
        let distY = y1 - y2;
        return Math.sqrt(distH ** 2 + distY ** 2);
    }

    const partialValidMessage = 'to {0, 0} is valid';
    const partialInValidMessage = 'to {0, 0} is invalid';

    if (Number.isInteger(getDistance(x1, y1, 0, 0))) {
        console.log(`{${x1}, ${y1}} ${partialValidMessage}`);
    } else {
        console.log(`{${x1}, ${y1}} ${partialInValidMessage}`);
    }

    if (Number.isInteger(getDistance(x2, y2, 0, 0))) {
        console.log(`{${x2}, ${y2}} ${partialValidMessage}`);
    } else {
        console.log(`{${x2}, ${y2}} ${partialInValidMessage}`);
    }

    if (Number.isInteger(getDistance(x1, y1, x2, y2))) {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    } else {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
    }
}
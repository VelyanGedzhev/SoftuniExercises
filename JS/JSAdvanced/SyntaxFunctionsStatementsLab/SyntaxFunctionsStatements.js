//Task 1. Echo Function
function print(input){
    let inputLength = input.length;

    console.log(inputLength);
    console.log(input);
}

//Task 2. String Length
function printSumAndAverageLength(firstString, secondString, thirdString){
    let sumLength = firstString.length + secondString.length + thirdString.length;
    let averageLength = Math.floor(sumLength / 3);

    console.log(sumLength);
    console.log(averageLength);
}

//Task 3. Largest Number
function FindLargestNumber(firstNumber, secondNumber, thirdNumber){
    var largestNumber = Math.max(firstNumber, secondNumber, thirdNumber);

    console.log(`The largest number is ${largestNumber}.`);
}

//Task 4. Circle Area
function CalculateCircleArea(radius){
    let inputType = typeof(radius);

    if(inputType == 'number'){
        let result = Math.pow(radius, 2) * Math.PI;
        console.log(result.toFixed(2));
    }
    else{
        console.log(`We can not calculate the circle area, because we receive a ${inputType}.`);
    }
}

//Task 5. Math Operations
function SolveOperation(firstnumber, secondNumber, operator){
    let result;

    switch(operator){
        case '+': result = firstnumber + secondNumber; break;
        case '-': result = firstnumber - secondNumber; break;
        case '*': result = firstnumber * secondNumber; break;
        case '/': result = firstnumber / secondNumber; break;
        case '%': result = firstnumber % secondNumber; break;
        case '**': result = firstnumber ** secondNumber; break;
    }

    console.log(result);
}

//Task 6. Sum of Numbers N…M
function FindSum(startAstring, endAsString) {
    let start = Number(startAstring);
    let end = Number(endAsString);
    let result = 0;

    for (let i = start; i <= end; i++) {
        result += i;
    }

    console.log(result);
}

//Task 7. Day of Week
function DayAsANumber(day){
    let result;

    switch(day){
        case 'Monday': result = 1; break;
        case 'Tuesday': result = 2; break;
        case 'Wednesday': result = 3; break;
        case 'Thursday': result = 4; break;
        case 'Friday': result = 5; break;
        case 'Saturday': result = 6; break;
        case 'Sunday': result = 7; break;
        default: result = 'error'
    }

    console.log(result);
}

//Task 8. Days in a month
function GetDaysInMonth(month, year){
    return new Date(year, month, 0).getDate();
}

//Task 9. Square of Stars
function PrintStarsRectangle(size = 5){

    for (let currRow = 1; currRow <= size; currRow++) {

        var elements = [];

        for (let currStar = 1; currStar <= size; currStar++) {
            elements.push('*');
        }

        console.log(elements.join(' '));
    }
}

//Task 10. Aggregate Elements
function solve(elements) {
    let sum = elements.reduce((a, b) => a + b);
    let concatenatedValues = elements.join('');
    let inversedValuesSum = aggregate(elements, 0, (a, b) => a + 1 / b);

    function aggregate(array, initValue, func) {
        let result = initValue;
        for (let i = 0; i < array.length; i++) {
            result = func(result, array[i]);
        }

        return result;
    }

    console.log(sum);
    console.log(inversedValuesSum);
    console.log(concatenatedValues);
}
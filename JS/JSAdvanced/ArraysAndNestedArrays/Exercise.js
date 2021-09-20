//Task 1. Print an Array with a Given Delimiter
function getArrayWithDelimiter(inputArr, delimeter) {
    console.log(inputArr.join(delimeter))
}

//Task 2. Print every N-th Element from an Array
function getNthElementsFromArray(inputArr, n) {
    const outputArr = [];

    for (let i = 0; i < inputArr.length; i += n) {
        outputArr.push(inputArr[i]);
    }

    return outputArr;
}

//Task 3. Add and Remove Elements
function addAndRemoveElements(commandArr) {
    let initialValue = 1;
    let outputArr = [];

    for (const command of commandArr) {

        if (command == 'add') {
            outputArr.push(initialValue);
        } else {
            outputArr.pop();
        }

        initialValue++;
    }

    if (outputArr.length == 0) {
        console.log('Empty');
    } else {
        console.log(outputArr.join('\n'));
    }
}

//Task 4. Rotate Array
function rotateAndPrintArray(inputArr, count) {

    for (let index = 0; index < count; index++) {

        let lastElement = inputArr.pop();
        inputArr.unshift(lastElement);
    }

    console.log(inputArr.join(' '));
}

//Task 5. Extract Increasing Subsequence from Array
function filterArray(inputArr) {

    let filteredArr = [];
    let currBigestNumber = 0;

    for (let index = 0; index < inputArr.length; index++) {

        let currNumber = inputArr[index];

        if (currNumber >= currBigestNumber) {
            currBigestNumber = currNumber;
            filteredArr.push(currBigestNumber);
        }
    }

    return filteredArr;
}

//Task 6. List Of Names
function sortAndPrintArray(inputArr) {

    inputArr.sort((a, b) => a.toLowerCase().localeCompare(b.toLowerCase()));

    for (let index = 0; index < inputArr.length; index++) {
        console.log(`${index + 1}.${inputArr[index]}`);
    }
}

//Task 7. Sorting Numbers
function getSortedArray(inputArr) {

    inputArr.sort((a, b) => a - b);

    for (let index = 1; index < inputArr.length; index += 2) {

        const element = inputArr.pop();
        inputArr.splice(index, 0, element);
    }

    return inputArr;
}

//Task 8. Sort an Array by 2 Criteria
function sortAndPrintArray(inputArr) {

    const twoCritetiaSort = (a, b) => {

        if (a.length == b.length)
            return a.localeCompare(b);
        else
            return a.length - b.length;
    }

    inputArr.sort(twoCritetiaSort);

    console.log(inputArr.join('\n'));
}

//Task 9. Magic Matrices
function checkIfMatrixIsMagicalAndPrintTheResult(matrix) {

    let isMatrixMagical = true;

    for (let row = 0; row < matrix.length; row++) {

        let currentRowNumbersSum = 0.00;

        for (const currNumber of matrix[row])
            currentRowNumbersSum += currNumber;

        let currentColNumbersSum = 0.00;

        for (let col = 0; col < matrix[0].length; col++)
            currentColNumbersSum += matrix[0][col];

        if (currentRowNumbersSum !== currentColNumbersSum) {
            isMatrixMagical = false;
            break;
        }
    }

    console.log(isMatrixMagical);
}
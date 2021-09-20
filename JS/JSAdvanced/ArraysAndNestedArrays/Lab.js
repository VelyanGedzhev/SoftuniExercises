//Task 1. Even Position Elements
function findEvenIndexes(inputArr) {
    const outputArr = [];

    for (let i = 0; i < inputArr.length; i += 2) {
        outputArr.push(inputArr[i]);
    }

    console.log(outputArr.join(' '));
}

//Task 2. Last K Numbers Sequence
function generateSequence(sequanceLength, elementsCountToSum) {
    let outputArr = [1];
    for (let i = 1; i < sequanceLength; i++) {
        outputArr[i] = sumLastK(outputArr, elementsCountToSum);
    }

    return outputArr;

    function sumLastK(arr, k) {
        k = arr.length > k ? k : arr.length;
        let sum = 0;
        for (let i = 1; i <= k; i++) {
            sum += arr[arr.length - i];
        }
        return sum;
    }
}

//Task 3. Sum First Last
function sum(inputArr) {
    const sum = Number(inputArr.shift()) + Number(inputArr.pop());

    return sum;
}

//Task 4. Negative / Positive Numbers
function rearrangeArray(inputArr) {
    const outputArr = [];

    for (let num of inputArr) {
        if (num < 0) {
            result.unshift(num);
        } else {
            result.push(num);
        }
    }

    console.log(outputArr.join('\n'));
}

//Task 5. Smallest Two Numbers
function findTheTwoSmallestNumbers(inputArr) {
    let [firstnumber, secondNumber] = inputArr.sort((a, b) => a - b);

    console.log(`${firstnumber} ${secondNumber}`);
}

//Task 6. Bigger Half
function getBiggerHalf(inputArr) {
    inputArr.sort((a, b) => a - b);
    const middleOfArr = Math.floor(inputArr.length / 2);
    const outputArr = inputArr.slice(middleOfArr);

    return outputArr;
}

//Task 7. Piece of Pie
function getPiecesOfPie(inputArr, firstPieName, secondPieName) {
    let firstPieIndex = inputArr.indexOf(firstPieName);
    let secondPieIndex = inputArr.indexOf(secondPieName);

    const outputArr = inputArr.slice(firstPieIndex, secondPieIndex + 1);
    return outputArr;
}

//Task 8. Process Odd Positions
function processOddPositions(inputArr) {

    return inputArr
        .filter((x, i) => i % 2 != 0)
        .map(x => x *= 2)
        .reverse()
        .join(' ');
}

//Task 9. Biggest Element
function getBiggestElement(matrix) {
    let arr = [];

    for (let row = 0; row < matrix.length; row++) {

        for (let col = 0; col < matrix[row].length; col++) {

            arr.push(matrix[row][col]);
        }
    }

    arr.sort((a, b) => b - a);

    return arr[0];
}

// Task 10. Diagonal Sums
function calculateAndPrintTheSumOfDiagonals(matrix) {
    let primaryDiagonalSum = 0.00;
    let secondaryDiagonalSum = 0.00;

    for (let index = 0; index < matrix.length; index++) {

        primaryDiagonalSum += matrix[index][index];
        secondaryDiagonalSum += matrix[index][matrix.length - index - 1];
    }

    console.log(`${primaryDiagonalSum} ${secondaryDiagonalSum}`);
}

// 11. Equal Neighbors
function getEqualNeighborsPairsCount(matrix) {
    let pairsCount = 0;

    for (let row = 0; row < matrix.length - 1; row++) {

        for (let col = 0; col < matrix[row].length; col++) {

            let upElement = matrix[row][col];
            let downElement = matrix[row + 1][col];

            if (upElement === downElement)
                pairsCount++;
        }
    }

    for (let row = 0; row < matrix.length; row++) {

        for (let col = 0; col < matrix[row].length - 1; col++) {

            let leftElement = matrix[row][col];
            let rigthElement = matrix[row][col + 1];

            if (leftElement === rigthElement)
                pairsCount++;
        }

    }

    return pairsCount;
}

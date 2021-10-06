// Task 1. Sub Sum
function sumRange(arr, startIndex, endIndex) {
    let sum = 0;

    if (!Array.isArray(arr)) {
        return NaN;
    }

    if (startIndex < 0) {
        startIndex = 0;
    }

    if (endIndex > arr.length - 1) {
        endIndex = arr.length - 1;
    }

    for (let i = startIndex; i <= endIndex; i++) {
        sum += Number(arr[i]);
    }

    return sum;
}

// Task 2. Playing Cards
function createCard(face, suit) {
    const faces = ['2','3','4','5','6','7','8','9','10','J','Q','K','A'];
    const suits = {
        'S': 'u\2660',
        'H': 'u\2665',
        'D': 'u\2666',
        'C': 'u\2663'
    };

    if (!faces.includes(face)) {
        throw new Error('Invalid card face.');
    }

    if (!Object.keys(suits).includes(suit)) {
        throw new Error('Invalid card suit.');
    }

    return {
        face,
        suit: suits[suit],
        toString() {
            return this.face + this.suit;
        }
    };
}

// Task 3. Deck of Cards
function createDeck(cards) {
    let result = [];

    for (let card of cards) {
        const face = card.slice(0 , -1);
        const suit = card.slice(-1);

        try {
            result.push(createCard(face, suit));
        } catch {
            console.log('Invalid card: ' + card);
            return;
        }
    }

    function createCard(face, suit) {
        const faces = ['2','3','4','5','6','7','8','9','10','J','Q','K','A'];
        const suits = {
            'S': 'u\2660',
            'H': 'u\2665',
            'D': 'u\2666',
            'C': 'u\2663'
        };
    
        if (!faces.includes(face)) {
            throw new Error('Invalid card face.');
        }
    
        if (!Object.keys(suits).includes(suit)) {
            throw new Error('Invalid card suit.');
        }
    
        return {
            face,
            suit: suits[suit],
            toString() {
                return this.face + this.suit;
            }
        };
    }
}

// Task 4. Sum of Numbers
function sum(arr) {
    let sum = 0;
    for (let num of arr){
        sum += Number(num);
    }
    return sum;
}

// Task 5. Check for Symmetry
function isSymmetric(arr) {
    if (!Array.isArray(arr)){
        return false; // Non-arrays are non-symmetric
    }
    let reversed = arr.slice(0).reverse(); // Clone and reverse
    let equal = (JSON.stringify(arr) == JSON.stringify(reversed));
    return equal;
}

// Task 6. RGB to Hex
function rgbToHexColor(red, green, blue) {
    if (!Number.isInteger(red) || (red < 0) || (red > 255)){
        return undefined; // Red value is invalid
    }
    if (!Number.isInteger(green) || (green < 0) || (green > 255)){
        return undefined; // Green value is invalid
    }
    if (!Number.isInteger(blue) || (blue < 0) || (blue > 255)){
        return undefined; // Blue value is invalid
    }
    return "#" +
        ("0" + red.toString(16).toUpperCase()).slice(-2) +
        ("0" + green.toString(16).toUpperCase()).slice(-2) +
        ("0" + blue.toString(16).toUpperCase()).slice(-2);
}

module.exports = {
    sumRange,
    createCard,
    createDeck,
    sum,
    isSymmetric,
    rgbToHexColor
};
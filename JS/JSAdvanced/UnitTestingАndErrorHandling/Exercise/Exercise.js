// Task 1. Request Validator
function requestValidator(request) {
    const httpMethods = ['GET', 'POST', 'DELETE', 'CONNECT'];
    const httpVersions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];

    if (request.method == undefined || 
        !httpMethods.includes(request.method)) {
            throw new Error('Invalid request header: Invalid Method');
    }

    const uriPattern = /(^[\w.]+$)/;

    if (!request.uri || 
        request.uri == '' ||
        !uriPattern.test(request.uri)) {
            throw new Error('Invalid request header: Invalid URI');
    }

    if (!request.version || 
        !httpVersions.includes(request.version)) {
            throw new Error('Invalid request header: Invalid Version');
    }

    const messagePattern = /([<>\\&'"])/;

    if (request.message == undefined ||
        messagePattern.test(request.message)) {
            throw new Error('Invalid request header: Invalid Message');
    }

    return request;
}

// Task 2. Even Or Odd
function isOddOrEven(string) {
    if (typeof(string) !== 'string') {
        return undefined;
    }
    if (string.length % 2 === 0) {
        return "even";
    }

    return "odd";
}

// Task 3. Char Lookup
function lookupChar(string, index) {
    if (typeof(string) !== 'string' || !Number.isInteger(index)) {
        return undefined;
    }
    if (string.length <= index || index < 0) {
        return "Incorrect index";
    }

    return string.charAt(index);
}

// Task 4. Math Enforcer
let mathEnforcer = {
    addFive: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num + 5;
    },
    subtractTen: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num - 10;
    },
    sum: function (num1, num2) {
        if (typeof(num1) !== 'number' || typeof(num2) !== 'number') {
            return undefined;
        }
        return num1 + num2;
    }
};

module.exports = {
    isOddOrEven,
    lookupChar,
    mathEnforcer
};
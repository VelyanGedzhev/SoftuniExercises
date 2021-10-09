const { expect } = require('chai');
const { isOddOrEven, lookupChar, mathEnforcer } = require('./Exercise');
// Task 2. Even Or Odd Tests
describe('isOddOrEven Checker', () => {
    it('ShouldReturnUndefinedWhenInputIsWrongType', () => {
        expect(isOddOrEven(1)).is.undefined;
    });
    it('ShouldReturnUndefinedWhenInputIsWrongType', () => {
        expect(isOddOrEven({})).is.undefined;
    });
    it('ShouldReturnCorrectResultIfInputIsEven', () => {
        expect(isOddOrEven('even')).is.equal('even');
    });
    it('ShouldReturnCorrectResultIfInputIsEven', () => {
        expect(isOddOrEven('Jurgen')).is.equal('even');
    });
    it('ShouldReturnCorrectResultIfInputIsOdd', () => {
        expect(isOddOrEven('odd')).is.equal('odd');
    });
    it('ShouldReturnCorrectResultIfInputIsOdd', () => {
        expect(isOddOrEven('Klopp')).is.equal('odd');
    });
});

// Task 3. Char Lookup Tests
describe('lookupChar Checker', () => {
    it('ShouldReturnUndefinedWhenFirstParameterIsntString', () => {
        expect(lookupChar(1, 1)).is.undefined;
    });
    it('ShouldReturnUndefinedWhenFirstParameterIsntString', () => {
        expect(lookupChar([], 1)).is.undefined;
    });
    it('ShouldReturnUndefinedWhenFirstParameterIsntInteger', () => {
        expect(lookupChar('text', '1')).is.undefined;
    });
    it('ShouldReturnUndefinedWhenFirstParameterIsntInteger', () => {
        expect(lookupChar('text', 1.1)).is.undefined;
    });
    it('ShouldReturnUndefinedWhenSecondParameterIsntInteger', () => {
        expect(lookupChar('input', false)).is.undefined;
    });
    it('ShouldReturnCorrectResultWhenIndexBiggerThanInputLength', () => {
        expect(lookupChar('text', 5)).is.equal('Incorrect index');
    });
    it('ShouldReturnCorrectResultWhenIndexEqualInputLength', () => {
        expect(lookupChar('text', 4)).is.equal('Incorrect index');
    });
    it('ShouldReturnCorrectResultWhenIndexSmallerThanZero', () => {
        expect(lookupChar('Input', -1)).is.equal('Incorrect index');
    });
    it('ShouldReturnCorrectResultWhenBothParametersAreValid', () => {
        expect(lookupChar('text', 1)).is.equal('e');
    });
});

// Task 4. Math Enforcer Tests
describe('mathEnforcer Checker', () => {
    describe('addFive Checker', () => {
        it('ShouldAddFiveWhenInputNumberIsValid', () => {
            expect(mathEnforcer.addFive(5)).to.be.equal(10);
            expect(mathEnforcer.addFive(-5)).to.be.equal(0);
            expect(mathEnforcer.addFive(12.05)).to.be.closeTo(17.05, 0.01);
            expect(mathEnforcer.addFive(-12.05)).to.be.closeTo(-7.05, 0.01);

        });
        it('ShouldReturnUndefinedWhenInputIsNotValid', () => {
            expect(mathEnforcer.addFive('5')).to.be.undefined;
            expect(mathEnforcer.addFive()).to.be.undefined;
            expect(mathEnforcer.addFive('text')).to.be.undefined;
        });
    });

    describe('subtractTen Checker', () => {
        it('ShouldSubtractTenWhenInputNumberIsValid', () => {
            expect(mathEnforcer.subtractTen(15)).to.be.equal(5);
            expect(mathEnforcer.subtractTen(-15)).to.be.equal(-25);
            expect(mathEnforcer.subtractTen(7.05)).to.be.closeTo(-2.95, 0.01);
            expect(mathEnforcer.subtractTen(-7.05)).to.be.closeTo(-17.05, 0.01);
        });
        it('ShouldReturnUndefinedWhenInputIsNotValid', () => {
            expect(mathEnforcer.subtractTen('5')).to.be.undefined;
            expect(mathEnforcer.subtractTen()).to.be.undefined;
            expect(mathEnforcer.subtractTen('text')).to.be.undefined;
        });
    });

    describe('sum Checker', () => {
        it('ShouldReturnCorrectSumWhenBothNumbersAreValid', () => {
            expect(mathEnforcer.sum(5, 5)).to.be.equal(10);
            expect(mathEnforcer.sum(-5, 5)).to.be.equal(0);
            expect(mathEnforcer.sum(-5, -55)).to.be.equal(-60);
            expect(mathEnforcer.sum(5.05, 5)).to.be.closeTo(10.05, 0.01);
            expect(mathEnforcer.sum(-5.05, 5)).to.be.closeTo(-0.05, 0.01);
            expect(mathEnforcer.sum(5.05, 5.05)).to.be.closeTo(10.10, 0.01);


        });
        it('ShouldReturnUndefinedWhenInputIsNotValid', () => {
            expect(mathEnforcer.sum('5', 5)).to.be.undefined;
            expect(mathEnforcer.sum(5, '5')).to.be.undefined;
            expect(mathEnforcer.sum('5', '5')).to.be.undefined;
            expect(mathEnforcer.sum(5)).to.be.undefined;
        });
    });
});
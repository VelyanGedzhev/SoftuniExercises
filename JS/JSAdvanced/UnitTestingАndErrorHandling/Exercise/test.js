const { expect } = require('chai');
const {isOddOrEven, lookupChar} = require('./Exercise');
// Task 2. Even Or Odd Tests
describe('isOddOrEven Checker', () => {
    it('ShouldReturnUndefinedWhenInputIsWrongType', () =>{
        expect(isOddOrEven(1)).is.undefined;
    });
    it('ShouldReturnUndefinedWhenInputIsWrongType', () =>{
        expect(isOddOrEven({})).is.undefined;
    });
    it('ShouldReturnCorrectResultIfInputIsEven', () =>{
        expect(isOddOrEven('even')).is.equal('even');
    });
    it('ShouldReturnCorrectResultIfInputIsEven', () =>{
        expect(isOddOrEven('Jurgen')).is.equal('even');
    });
    it('ShouldReturnCorrectResultIfInputIsOdd', () =>{
        expect(isOddOrEven('odd')).is.equal('odd');
    });
    it('ShouldReturnCorrectResultIfInputIsOdd', () =>{
        expect(isOddOrEven('Klopp')).is.equal('odd');
    });
});

// Task 3. Char Lookup Tests
describe('lookupChar Checker', () => {
    it('ShouldReturnUndefinedWhenFirstParameterIsntString', () =>{
        expect(lookupChar(1, 1)).is.undefined;
    });
    it('ShouldReturnUndefinedWhenFirstParameterIsntString', () =>{
        expect(lookupChar([], 1)).is.undefined;
    });
    it('ShouldReturnUndefinedWhenFirstParameterIsntInteger', () =>{
        expect(lookupChar('text', '1')).is.undefined;
    });
    it('ShouldReturnUndefinedWhenFirstParameterIsntInteger', () =>{
        expect(lookupChar('text', 1.1)).is.undefined;
    });
    it('ShouldReturnUndefinedWhenSecondParameterIsntInteger', () =>{
        expect(lookupChar('input', false)).is.undefined;
    });
    it('ShouldReturnCorrectResultWhenIndexBiggerThanInputLength', () =>{
        expect(lookupChar('text', 5)).is.equal('Incorrect index');
    });
    it('ShouldReturnCorrectResultWhenIndexEqualInputLength', () =>{
        expect(lookupChar('text', 4)).is.equal('Incorrect index');
    });
    it('ShouldReturnCorrectResultWhenIndexSmallerThanZero', () =>{
        expect(lookupChar('Input', -1)).is.equal('Incorrect index');
    });
    it('ShouldReturnCorrectResultWhenBothParametersAreValid', () =>{
        expect(lookupChar('text', 1)).is.equal('e');
    });
});
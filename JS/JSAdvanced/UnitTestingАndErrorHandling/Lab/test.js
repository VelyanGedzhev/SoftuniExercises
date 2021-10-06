const { expect } = require('chai');
const { sumRange } = require('./Lab');
const { isSymmetric } = require('./Lab');
const { rgbToHexColor } = require('./Lab');

// Tests Task 1
describe('sumRange Checker', () => {
    it('ShouldWorkWithCorrectInput', () => {
        expect(sumRange([10, 20, 30, 40, 50, 60], 3, 300)).to.equal(150);
    });
});

//Tests Task 5
describe('isSymmetric Checker', () => {

    describe('ValidParameters', () => {
        it('ShouldReturnTrueWhenArrayIsSymmetricWithEvenElementsCount', () => {
            expect(isSymmetric([1, 2, 2, 1])).to.be.true;
        });
        it('ShouldReturnTrueWhenArrayIsSymmetricWithOddElementsCount', () => {
            expect(isSymmetric([1, 2, 1])).to.be.true;
        });
        it('ShouldReturnTrueWithStringArray', () => {
            expect(isSymmetric(['a', 'b', 'b', 'a'])).to.be.true;
        });
    });
    
    describe('InvalidParameters', () => {
        it('ShouldReturnFalseWhenArrayNonSymmetric', () => {
            expect(isSymmetric([1, 2, 2, 1, 3])).to.be.false;
        });
        it('ShouldReturnFalseWhenInputIsNotArray', () => {
            expect(isSymmetric('inputArray')).to.be.false;
        });
        it('ShouldReturnFalseWithStringArrayWhenNonSymmetric', () => {
            expect(isSymmetric(['a', 'b', 'c'])).to.be.false;
        });
        it('ShouldReturnFalseIfElementsOfDifferentType', () => {
            expect(isSymmetric([1, 2, '1'])).to.be.false;
        });
    }); 
});

//Tests Task 6
describe('rgbToHexColor Checker', () => {

    describe('ValidParameters', () => {
        it('ConvertWhite', () => {
            expect(rgbToHexColor(255, 255, 255)).to.equal('#FFFFFF');
        });
        it('ConvertBlack', () => {
            expect(rgbToHexColor(0, 0, 0)).to.equal('#000000');
        });
        it('ConvertSoftuniWebPageBlueTo#234465', () => {
            expect(rgbToHexColor(35, 68, 101)).to.equal('#234465');
        });
    });

    describe('InvalidParameters', () => {
        it('ReturnsUndefinedWhenMissingParamters', () => {
            expect(rgbToHexColor(255, 255)).to.equal(undefined);
        });
        it('ReturnsUndefinedWhenParametersOfWrongType', () => {
            expect(rgbToHexColor('black', 255, 255)).to.equal(undefined);
        });
        it('ReturnsUndefinedWhenValuesOutOfRange', () => {
            expect(rgbToHexColor(-1, -10, -1)).to.equal(undefined);
        });
        it('ReturnsUndefinedWhenValuesOutOfRange', () => {
            expect(rgbToHexColor(256, 257, 255)).to.equal(undefined);
        });
    }); 
});
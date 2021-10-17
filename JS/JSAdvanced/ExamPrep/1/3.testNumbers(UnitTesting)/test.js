const testNumbers = require('./testNumbers');
const {expect} = require('chai');

describe('testNumbers', () => {

    describe('sumNumber', () => {

        describe('validInput', () => {
            it('ShouldReturnCorrectSum', () => {
                expect(testNumbers.sumNumbers(5, 5)).to.equals('10.00');
                expect(testNumbers.sumNumbers(5.5555, 5.3333)).to.equals('10.89');
                expect(testNumbers.sumNumbers(5.5, 5.2)).to.equals('10.70');
                expect(testNumbers.sumNumbers(-5, 3)).to.equals('-2.00');
                expect(testNumbers.sumNumbers(-5, -5)).to.equals('-10.00');
            });
        });

        describe('invalidInput', () => {
            it('ShouldReturnUndefined', () => {
                expect(testNumbers.sumNumbers('5', 5)).to.be.undefined;
                expect(testNumbers.sumNumbers(5.5, '5.2')).to.be.undefined;
                expect(testNumbers.sumNumbers({}, [])).to.be.undefined;
                expect(testNumbers.sumNumbers(NaN)).to.be.undefined;
                expect(testNumbers.sumNumbers()).to.be.undefined;
            });
        });
    });

    describe('numberChecker', () => {

        describe('validInput', () => {
            it('ShouldReturnEven', () => {
                expect(testNumbers.numberChecker(2)).to.equals('The number is even!');
                expect(testNumbers.numberChecker(4)).to.equals('The number is even!');
                expect(testNumbers.numberChecker(-44)).to.equals('The number is even!');
            });
            it('ShouldReturnOdd', () => {
                expect(testNumbers.numberChecker(3)).to.equals('The number is odd!');
                expect(testNumbers.numberChecker(33)).to.equals('The number is odd!');
                expect(testNumbers.numberChecker(-55)).to.equals('The number is odd!');
            });
        });

        describe('invalidInput', () => {
            it('ShouldThrowError', () => {
                expect(() => testNumbers.numberChecker('3b')).to.throw('The input is not a number!');
                expect(() => testNumbers.numberChecker()).to.throw('The input is not a number!');
                expect(() => testNumbers.numberChecker({})).to.throw('The input is not a number!');
            })
        });
    });

    describe('averageSumArray', () => {

        describe('validInput', () => {
            it('ShouldReturnCorrectAverageSum', () => {
                expect(testNumbers.averageSumArray([1, 2, 3])).to.equals(2);
                expect(testNumbers.averageSumArray([1.5, 2.5, 5])).to.equals(3);
                expect(testNumbers.averageSumArray([1, -2, 4])).to.equals(1);
                
            });
        });
    });
});
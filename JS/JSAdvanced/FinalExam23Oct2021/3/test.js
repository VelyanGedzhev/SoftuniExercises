const library = require('./library');
const {expect} = require('chai');

describe('library', () => {

    describe('calcPriceOfBook', () => {
        describe('validInput', () => {
           it('ShouldReturnCorrectResult', () => {
                expect(library.calcPriceOfBook('TestBook', 1980))
                    .to.be.equal('Price of TestBook is 10.00');
                expect(library.calcPriceOfBook('TestBook', 1970))
                    .to.be.equal('Price of TestBook is 10.00');
                expect(library.calcPriceOfBook('TestBook', 1990))
                    .to.be.equal('Price of TestBook is 20.00');
                expect(library.calcPriceOfBook('TestBook', 2010))
                    .to.be.equal('Price of TestBook is 20.00');
           });
        });

        describe('invalidInput', () => {
            it('ShouldThrowError', () => {
                 expect(() => library.calcPriceOfBook('TestBook',)).to.throw('Invalid input');
                 expect(() => library.calcPriceOfBook('TestBook', 5.2)).to.throw('Invalid input');
                 expect(() => library.calcPriceOfBook('TestBook',[])).to.throw('Invalid input');
                 expect(() => library.calcPriceOfBook('TestBook',{})).to.throw('Invalid input');
                 expect(() => library.calcPriceOfBook([],1970)).to.throw('Invalid input');
                 expect(() => library.calcPriceOfBook()).to.throw('Invalid input');
                 expect(() => library.calcPriceOfBook(1970, 'TestBook')).to.throw('Invalid input');
                 expect(() => library.calcPriceOfBook({}, [])).to.throw('Invalid input');
            });
         });
    });

    describe('findBook', () => {

        describe('validInput', () => {
            it('ShouldReturnCorrectResult', () => {
                expect(library.findBook(["Troy", "Life Style", "Torronto"], 'Torronto'))
                    .to.be.equal('We found the book you want.');
                expect(library.findBook(["Troy", "Life Style", "Torronto"], 'Toronto'))
                    .to.be.equal('The book you are looking for is not here!');
                expect(library.findBook(["Troy", "Life Style", 17], 'Toronto'))
                    .to.be.equal('The book you are looking for is not here!');
                expect(library.findBook(["Troy", "Life Style", {}], 'Toronto'))
                    .to.be.equal('The book you are looking for is not here!');
            });
        });

        describe('invalidInput', () => {
            it('ShouldThrowError', () => {
                expect(() => library.findBook([])).to.throw('No books currently available');
            });
        });
    });

    describe('arrangeTheBooks', () => {

        describe('validInput', () => {
            it('ShouldReturnCorrectResult', () => {
                expect(library.arrangeTheBooks(5))
                    .to.be.equal('Great job, the books are arranged.');
            });
            it('ShouldReturnCorrectResult', () => {
                expect(library.arrangeTheBooks(39))
                    .to.be.equal('Great job, the books are arranged.');
            });
            it('ShouldReturnCorrectResult', () => {
                expect(library.arrangeTheBooks(40))
                    .to.be.equal('Great job, the books are arranged.');
            });
            it('ShouldReturnCorrectResult', () => {
                expect(library.arrangeTheBooks(41))
                    .to.be.equal('Insufficient space, more shelves need to be purchased.');
            });
            it('ShouldReturnCorrectResult', () => {
                expect(library.arrangeTheBooks(120))
                    .to.be.equal('Insufficient space, more shelves need to be purchased.');
            });
            it('ShouldReturnCorrectResult', () => {
                expect(library.arrangeTheBooks(1000))
                    .to.be.equal('Insufficient space, more shelves need to be purchased.');
            });
        });

        describe('invalidInput', () => {
            it('ShouldThrowError', () => {
                expect(() => library.calcPriceOfBook()).to.throw('Invalid input');
                expect(() => library.calcPriceOfBook([])).to.throw('Invalid input');
                expect(() => library.calcPriceOfBook({})).to.throw('Invalid input');
                expect(() => library.calcPriceOfBook(-17)).to.throw('Invalid input');
                expect(() => library.calcPriceOfBook(5.5)).to.throw('Invalid input');
                expect(() => library.calcPriceOfBook('book')).to.throw('Invalid input');
            });
        });
    });
});
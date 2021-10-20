const cinema = require('./cinema');
const {expect} = require('chai');

describe('Cinema Tests', () => {

    describe('showMovies', () => {
        it('ShouldReturnCorrectResult', () => {
            expect(cinema.showMovies([])).to.be.equal('There are currently no movies to show.');
            expect(cinema.showMovies(['Batman', 'Superman'])).to.be.equal('Batman, Superman');
        });
     });

    describe('ticketPrice', () => {
        it('ShouldThrowErrorIfProjectionTypeIsInvalid', () => {
            expect(() => cinema.ticketPrice('3b')).to.throw('Invalid projection type.');
            expect(() => cinema.ticketPrice()).to.throw('Invalid projection type.');
        });
        it('ShouldReturnCorrectResult', () => {
            expect(cinema.ticketPrice('Premiere')).to.be.equal(12.00);
            expect(cinema.ticketPrice('Normal')).to.be.equal(7.50);
            expect(cinema.ticketPrice('Discount')).to.be.equal(5.50);
        });
    });

    describe('swapSeatsInHall', () => {
        it('ShouldReturnSuccessIfSeatsCanBeSwapped', () => {
            expect(cinema.swapSeatsInHall(2, 5)).to.be.equal('Successful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(5, 2)).to.be.equal('Successful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(15, 19)).to.be.equal('Successful change of seats in the hall.');
        });

        it('ShouldReturnFailureIfSeatsCanBeSwapped', () => {
            expect(cinema.swapSeatsInHall(-2, 5)).to.be.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(5, -2)).to.be.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(-15, -19)).to.be.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(0, 19)).to.be.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall([], -19)).to.be.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(-15, {})).to.be.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(-15)).to.be.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(15)).to.be.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall()).to.be.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall({}, [])).to.be.equal('Unsuccessful change of seats in the hall.');
        });
    });
});

const { expect } = require('chai');
const isOddOrEven = require('./02.EvenOrOdd');

describe('testing isOddOrEven function', () => {
    it('non string test', () => {
        expect(isOddOrEven(1)).to.equal(undefined);
    });
    it('even string test', () => {
        expect(isOddOrEven('Flower')).to.equal('even');
    });
    it('odd string test', () => {
        expect(isOddOrEven('Cat')).to.equal('odd');
    });
});
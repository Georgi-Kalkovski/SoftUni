const { expect } = require('chai');
const sum = require('./04.SumOfNumbers');

describe('Sum function testing', () => {
    it('basic sum', () => {
        expect(sum([1])).to.equal(1);
    });

    it('sum of two nums', () => {
        expect(sum([1, 2])).to.equal(3);
    });

    it('sum of multiple nums', () => {
        expect(sum([1, 2, 3, 4])).to.equal(10);
    });
});
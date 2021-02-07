const { expect } = require('chai');
const isSymmetric = require('./05.CheckForSummetry');

describe('Symmetry function testing', () => {
    it('summetry check three elements', () => {
        expect(isSymmetric([1, 2, 1])).to.equal(true);
    });
    it('summetry check four elements', () => {
        expect(isSymmetric([1, 1, 1, 1])).to.equal(true);
    });
    it('correct summetry check string elements', () => {
        expect(isSymmetric(['a', 'a'])).to.equal(true);
    });
    it('string incorrect input', () => {
        expect(isSymmetric('a')).to.equal(false);
    });
    it('number incorrect input', () => {
        expect(isSymmetric(1)).to.equal(false);
    });
    it('incorrect summetry check', () => {
        expect(isSymmetric(['a', 'b'])).to.equal(false);
    });
    it('incorrect check for same type', () => {
        expect(isSymmetric([1, '1'])).to.equal(false);
    });
});
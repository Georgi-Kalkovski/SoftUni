const { expect } = require('chai');
const lookupChar = require('./03.CharLookup');

describe('testing lookupChar function', () => {
    it('test for undefined', () => {
        expect(lookupChar(1, 1)).to.equal(undefined);
    });
    it('correct test', () => {
        expect(lookupChar('string', 1.1)).to.equal(undefined);
    });
    it('test for undefined', () => {
        expect(lookupChar(1, 'string')).to.equal(undefined);
    });
    it('test for undefined', () => {
        expect(lookupChar('string', 'string')).to.equal(undefined);
    });
    it('test for incorrect index', () => {
        expect(lookupChar('string', -1)).to.equal('Incorrect index');
    });
    it('test for incorrect string', () => {
        expect(lookupChar('Cat', 5)).to.equal('Incorrect index');
    });
    it('correct test', () => {
        expect(lookupChar('Cat', 0)).to.equal('C');
    });
});
const { expect } = require('chai');
const mathEnforcer = require('./04.MathEnforcer');

describe('testing mathEnforcer function', () => {

    // addFive(num)

    it('addFive string', () => {
        expect(mathEnforcer.addFive('string')).to.equal(undefined);
    });
    it('addFive [1]', () => {
        expect(mathEnforcer.addFive([1])).to.equal(undefined);
    });
    it('addFive 5', () => {
        expect(mathEnforcer.addFive(5)).to.equal(10);
    });
    it('addFive 5.5', () => {
        expect(mathEnforcer.addFive(5.5)).to.equal(10.5);
    });
    it('addFive -5.5', () => {
        expect(mathEnforcer.addFive(-5.5)).to.equal(-0.5);
    });

    // subtractTen(num)

    it('subtractTen string', () => {
        expect(mathEnforcer.subtractTen('string')).to.equal(undefined);
    });
    it('subtractTen [1]', () => {
        expect(mathEnforcer.subtractTen([1])).to.equal(undefined);
    });
    it('subtractTen 5', () => {
        expect(mathEnforcer.subtractTen(5)).to.equal(-5);
    });
    it('subtractTen positive', () => {
        expect(mathEnforcer.subtractTen(5.5)).to.equal(-4.5);
    });
    it('subtractTen negative', () => {
        expect(mathEnforcer.subtractTen(-5.5)).to.equal(-15.5);
    });

    //sum(num1 , num2)

    it('sum num1 string', () => {
        expect(mathEnforcer.sum('string', 1)).to.equal(undefined);
    });
    it('sum num2 string', () => {
        expect(mathEnforcer.sum(1, 'string')).to.equal(undefined);
    });
    it('sum num1 && num2 string', () => {
        expect(mathEnforcer.sum('string', 'string')).to.equal(undefined);
    });
    it('sum num1 [1]', () => {
        expect(mathEnforcer.sum([1], 1)).to.equal(undefined);
    });
    it('sum num2 [1]', () => {
        expect(mathEnforcer.sum(1, [1])).to.equal(undefined);
    });
    it('sum num1 && num2 [1]', () => {
        expect(mathEnforcer.sum([1], [1])).to.equal(undefined);
    });
    it('sum only one number', () => {
        expect(mathEnforcer.sum(6)).to.equal(undefined);
    });
    it('sum positive', () => {
        expect(mathEnforcer.sum(6,6)).to.equal(12);
    });
    it('sum negative', () => {
        expect(mathEnforcer.sum(-6,-6)).to.equal(-12);
    });
    it('sum decimals', () => {
        expect(mathEnforcer.sum(6.6,6.6)).to.equal(13.2);
    });
});
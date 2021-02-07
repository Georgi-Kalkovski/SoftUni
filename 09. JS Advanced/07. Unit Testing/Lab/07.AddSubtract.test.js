const { expect } = require('chai');
const createCalculator = require('./07.AddSubtract');

describe('testing function createCalculator', () => {
    it('check add and subtract functionality with positive numbers', function () {
        let calculator = createCalculator();

        calculator.add(404);
        calculator.subtract('101');

        expect(calculator.get()).to.equal(303);
    });
    it('check add and subtract functionality with negative numbers', function () {
        let calculator = createCalculator();

        calculator.add('-404');
        calculator.subtract(-101);

        expect(calculator.get()).to.equal(-303);
    });
});
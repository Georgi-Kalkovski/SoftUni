const dealership = require('./03.dealership');
const { assert, expect } = require('chai');

describe('testing Dealership function', function () {
    it('testing newCarCost', function () {
        let car1 = dealership.newCarCost('BMV', 5000);
        let car2 = dealership.newCarCost('Audi A6 4K', 20001);
        let car3 = dealership.newCarCost('Audi TT 8J', 14001);
        assert.equal(car1, 5000);
        assert.equal(car2, 1);
        assert.equal(car3, 1);
    });
    it('testing carEquipment right', function () {
        let extras = ['heated seats', 'sliding roof', 'sport rims', 'navigation'];
        let indexes = [0, 1, 3];
        let result = ['heated seats', 'sliding roof', 'navigation'];
        assert.deepEqual(dealership.carEquipment(extras, indexes), result);
    });
    it('testing carEquipment out of bound', function () {
        let extras = ['heated seats', 'sliding roof', 'sport rims', 'navigation'];
        let indexes = [0, 1, 3, 5];
        let result = ['heated seats', 'sliding roof', 'navigation', undefined];
        assert.deepEqual(dealership.carEquipment(extras, indexes), result);
    });
    it("euroCategory", function () {
        expect(dealership.euroCategory(1)).to.equal('Your euro category is low, so there is no discount from the final price!');
        expect(dealership.euroCategory(4)).to.equal('We have added 5% discount to the final price: 14250.');
        expect(dealership.euroCategory(10)).to.equal('We have added 5% discount to the final price: 14250.');
    });
});
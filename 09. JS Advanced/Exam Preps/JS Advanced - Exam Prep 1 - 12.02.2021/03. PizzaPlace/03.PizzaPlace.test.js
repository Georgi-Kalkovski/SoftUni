const pizzUni = require('./03.PizzaPlace');
const { assert } = require('chai');

describe('testing pizzaPlace function', function () {
    it('testing makeAnOrder', function () {
        let obj1 = { orderedPizza: 'pizza', orderedDrink: 'drink' };
        let obj2 = { orderedPizza: 'pizza' };
        let obj3 = { orderedDrink: 'drink' };
        let obj4 = {};
        assert.equal(pizzUni.makeAnOrder(obj1), `You just ordered ${obj1.orderedPizza} and ${obj1.orderedDrink}.`);
        assert.equal(pizzUni.makeAnOrder(obj2), `You just ordered ${obj2.orderedPizza}`);
        assert.throw(() => pizzUni.makeAnOrder(obj3), 'You must order at least 1 Pizza to finish the order.');
        assert.throw(() => pizzUni.makeAnOrder(obj4), 'You must order at least 1 Pizza to finish the order.');
    });
    it('testing getRemainingWork', function () {
        let arr1 = [
            { pizzaName: 'pizza1', status: 'ready' },
            { pizzaName: 'pizza2', status: 'ready' }
        ];
        let arr2 = [
            { pizzaName: 'pizza3', status: 'preparing' },
            { pizzaName: 'pizza4', status: 'preparing' }
        ];

        assert.equal(pizzUni.getRemainingWork(arr1), 'All orders are complete!');
        assert.equal(pizzUni.getRemainingWork(arr2), `The following pizzas are still preparing: pizza3, pizza4.`);
    });
    it('testing orderType', function () {
        let typeOfOrderCarryOut = 'Carry Out';
        let typeOfOrderDelivery = 'Delivery';

        assert.equal(pizzUni.orderType(100,typeOfOrderCarryOut), 90);
        assert.equal(pizzUni.orderType( -100, typeOfOrderCarryOut), -90);
        assert.equal(pizzUni.orderType(0, typeOfOrderCarryOut), 0);

        assert.equal(pizzUni.orderType(100, typeOfOrderDelivery), 100);
        assert.equal(pizzUni.orderType(-100, typeOfOrderDelivery), -100);
        assert.equal(pizzUni.orderType(0, typeOfOrderDelivery), 0);
    });
});
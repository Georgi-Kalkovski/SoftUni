let { Repository } = require("./solution.js");
const { expect } = require('chai');

describe("Tests …", () => {
    let properties = {
        name: "string",
        age: "number",
        birthday: "object"
    };
    let correctEntity1 = {
        name: "Pesho",
        age: 22,
        birthday: new Date(1998, 0, 7)
    };
    let correctEntity2 = {
        name: "Emi",
        age: 22,
        birthday: new Date(1998, 0, 7)
    };
    let wrongEntity1 = {
        name1: "Pesho",
        age: 22,
        birthday: new Date(1998, 0, 7)
    };
    let wrongEntity2 = {
        name: 22,
        age: 22,
        birthday: new Date(1998, 0, 7)
    };
    let wrongEntity3 = {
        name: "Pesho",
        age1: 22,
        birthday: new Date(1998, 0, 7)
    };
    let wrongEntity4 = {
        name: 'Pesho',
        age: '22',
        birthday: new Date(1998, 0, 7)
    };
    let wrongEntity5 = {
        name: "Pesho",
        age: 22,
        birthday1: new Date(1998, 0, 7)
    };
    let wrongEntity6 = {
        name: 'Pesho',
        age: 22,
        birthday: 22,
    };
    let rep;
    let validEntity = {
        name: "Pesho",
        age: 22,
        birthday: new Date(1998, 0, 7)
    };
    beforeEach(() => rep = new Repository(properties));
    it('constructor', () => {
        assert.deepEqual(rep.props, properties, 'Prop object not created');
        assert.typeOf(rep.data, 'Map', 'Map data not created');
    });
    it('count', () => {
        assert(rep.count === 0, 'Empty rep')
        rep.add(correctEntity1);
        assert(rep.count === 1, 'Rep with 1 entity')
    });
    it('add', () => {
        assert(rep.add(correctEntity1) === 0, 'First entity added');
        assert(rep.data.get(0) === correctEntity1, 'Entity added to data');
        assert(rep.add(correctEntity2) === 1, 'Second entity added');
        assert(rep.data.get(1) === correctEntity2, 'Entity added to data');
 
        assert.throws(() => rep.add(wrongEntity1), Error, 'Property name is missing from the entity!');
        assert.throws(() => rep.add(wrongEntity2), TypeError, 'Property name is not of correct type!');
 
        assert.throws(() => rep.add(wrongEntity3), Error, 'Property age is missing from the entity!');
        assert.throws(() => rep.add(wrongEntity4), TypeError, 'Property age is not of correct type!');
 
        assert.throws(() => rep.add(wrongEntity5), Error, 'Property birthday is missing from the entity!');
        assert.throws(() => rep.add(wrongEntity6), TypeError, 'Property birthday is not of correct type!');
    });
    it('getId', () => {
        assert.throw(() => rep.getId(0), 'Entity with id: 0 does not exist!');
        rep.add(correctEntity1);
        assert(rep.getId(0) === correctEntity1, 'First entity added')
        assert.throw(() => rep.getId(-1), 'Entity with id: -1 does not exist!');
        assert.throw(() => rep.getId(1), 'Entity with id: 1 does not exist!');
        assert.throw(() => rep.getId(1.5), 'Entity with id: 1.5 does not exist!');
    });
    it('update', () => {
        assert.throws(() => rep.update(0, correctEntity1), Error, 'Entity with id: 0 does not exist!');
        rep.add(correctEntity1);
 
        assert.throws(() => rep.update(0, wrongEntity1), Error, 'Property name is missing from the entity!');
        assert.throws(() => rep.update(0, wrongEntity2), TypeError, 'Property name is not of correct type!');
 
        assert.throws(() => rep.update(0, wrongEntity3), Error, 'Property age is missing from the entity!');
        assert.throws(() => rep.update(0, wrongEntity4), TypeError, 'Property age is not of correct type!');
 
        assert.throws(() => rep.update(0, wrongEntity5), Error, 'Property birthday is missing from the entity!');
        assert.throws(() => rep.update(0, wrongEntity6), TypeError, 'Property birthday is not of correct type!');
 
        assert.deepEqual(rep.getId(0), correctEntity1, 'First entity incorrectly updated with new value');
 
        rep.update(0, correctEntity2);
        assert.equal(rep.getId(0), correctEntity2, 'First entity updated with new value');
    });
    it('del', () => {
        assert.throw(() => rep.del(0), 'Entity with id: 0 does not exist!');
        rep.add(correctEntity1);
        rep.add(correctEntity2);
        assert(rep.count === 2, 'entities added');
        rep.del(0);
        assert(rep.count === 1, 'first entity deleted');
        assert(rep.getId(1) === correctEntity2, 'id not affected')
        rep.del(1);
        assert(rep.count === 0, 'first entity deleted');
        assert.throw(() => rep.del(0), 'Entity with id: 0 does not exist!');
        assert.throw(() => rep.del(-1), 'Entity with id: -1 does not exist!');
        assert.throw(() => rep.del(1.5), 'Entity with id: 1.5 does not exist!');
        assert.throw(() => rep.del('test'), 'Entity with id: test does not exist!');
    });
});

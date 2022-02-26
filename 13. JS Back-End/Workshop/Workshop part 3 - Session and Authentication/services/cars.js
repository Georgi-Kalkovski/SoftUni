const Car = require('../models/Car');
const { carViewModel } = require('./util');


async function getAll(query) {
    const options = {
        isDeleted: false
    };

    if (query.search) {
        options.name = new RegExp(query.search, 'i');
    }
    if (query.from) {
        options.price = { $gte: Number(query.from) };
    }
    if (query.to) {
        if (!options.price) {
            options.price = {};
        }
        options.price.$lte = Number(query.to);
    }

    const cars = await Car.find(options);
    return cars.map(carViewModel);
}

async function getById(id) {
    const car = await Car.findById(id).where({ isDeleted: false }).populate('accessories');
    if (car) {
        return carViewModel(car);
    } else {
        return undefined;
    }
}

async function createCar(car) {
    const result = new Car(car);
    await result.save();
}

async function deleteById(id, ownerId) {
    // await Car.findByIdAndDelete(id);
    const existing = await Car.findById(id).where({ isDeleted: false });

    if (existing.owner != ownerId) {
        return false;
    }

    await Car.findByIdAndUpdate(id, { isDeleted: true });

    return true;
}

async function updateById(id, car, ownerId) {
    const existing = await Car.findById(id).where({ isDeleted: false });

    if (existing.owner != ownerId) {
        return false;
    }

    existing.name = car.name;
    existing.description = car.description;
    existing.imageUrl = car.imageUrl || undefined;
    existing.price = car.price;
    existing.accessories = car.accessories;

    await existing.save();

    return true;
}

async function attachAccessory(carId, accessoryId, ownerId) {
    const existing = await Car.findById(carId);

    if (existing.owner != ownerId) {
        return false;
    }

    existing.accessories.push(accessoryId);

    await existing.save();
}

module.exports = () => (req, res, next) => {
    req.storage = {
        getAll,
        getById,
        createCar,
        updateById,
        deleteById,
        attachAccessory
    };
    next();
};
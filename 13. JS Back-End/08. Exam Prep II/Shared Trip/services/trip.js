const Trip = require('../models/Trip');

async function getTripById(id) {
    return Trip.findById(id);
}

async function createTrip(trip) {
    const result = new Trip(trip);
    await result.save();
}

module.export = {
    getTripById,
    createTrip
};
const Trip = require('../models/Trip');

async function getAllTrips() {
    return Trip.find({}).lean();
}

async function getTripById(id) {
    return Trip.findById(id).lean();
}

async function getTripAndUsers(id) {
    return Trip.findById(id).populate('owner').populate('buddies').lean();
}


async function createTrip(trip) {
    const result = new Trip(trip);
    await result.save();
}

module.exports = {
    getAllTrips,
    getTripAndUsers,
    getTripById,
    createTrip,
};
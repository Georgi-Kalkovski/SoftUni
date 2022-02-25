const Housing = require('../models/Housing');

// preload
async function getHousingById(id) {
    return Housing.findById(id).lean();
}

async function getHousingAndUsers(id) {
    return Housing.findById(id).populate('owner').populate('rented').lean();
}

async function createHousing(housing) {
    const result = new Housing(housing);
    await result.save();
}

async function getAllHousing() {
    return Housing.find({}).lean();
}

async function updateHousing(id, housing) {
    const existing = await Housing.findById(id);

    existing.name = housing.name;
    existing.type = housing.type;
    existing.year = housing.year;
    existing.city = housing.city;
    existing.homeImage = housing.homeImage;
    existing.description = housing.description;
    existing.availablePieces = housing.availablePieces;

    await existing.save();
}

async function deleteById(id) {
    return Housing.findByIdAndDelete(id);
}

async function joinHousing(housingId, userId) {
    const housing = await Housing.findById(housingId);

    if (housing.rented.includes(userId)) {
        throw new Error('User is already part of the rent');
    }

    housing.rented.push(userId);
    await housing.save();
}

function searchHousing(type) {
    return Housing.find({type: type});
}

module.exports = {
    getHousingById,
    getHousingAndUsers,
    createHousing,
    getAllHousing,
    updateHousing,
    deleteById,
    joinHousing,
    searchHousing
};
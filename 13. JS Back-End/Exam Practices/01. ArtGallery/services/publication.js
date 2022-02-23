const Publication = require('../models/Publication');

async function getAllPublications() {
    return Publication.find({}).lean();
}

async function getPublicationById(id) {
    return Publication.findById(id).lean();
}

async function getPublicationAndUsers(id) {
    return Publication.findById(id).populate('author').populate('users').lean();
}

async function createPublication(publication) {
    const result = new Publication(publication);
    await result.save();
}

module.exports = {
    getAllPublications,
    getPublicationById,
    getPublicationAndUsers,
    createPublication
};
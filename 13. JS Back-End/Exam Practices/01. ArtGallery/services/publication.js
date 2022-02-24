const Publication = require('../models/Publication');

async function getAllPublication() {
    return Publication.find({}).lean();
}

async function getPublicationUsername(id) {
    return Publication.findById(id).populate('username');
}

async function getPublicationsByUser(userId) {
    return Publication.find({ author: userId }).populate('author', 'username');
}

async function getPublicationById(id) {
    return Publication.findById(id).lean();
}

async function getPublicationAndUsers(id) {
    return Publication.findById(id).populate('author').populate('shares').lean();
}


async function createPublication(publication) {
    const result = new Publication(publication);
    await result.save();
}

async function updatePublication(id, publication) {
    const existing = await Publication.findById(id);

    existing.title = publication.title;
    existing.tech = publication.tech;
    existing.picture = publication.picture;
    existing.certificate = publication.certificate;

    await existing.save();
}

async function deletePublication(id) {
    return Publication.findByIdAndDelete(id);
}

async function joinPublication(publicationId, userId) {
    const publication = await Publication.findById(publicationId);

    if (publication.shares.includes(userId)) {
        throw new Error('User is already part of the trip');
    }

    publication.shares.push(userId);
    await publication.save();
}

async function getPublicationsByAuthor(userId) {
    return Publication.find({ author: userId });
}

module.exports = {
    getAllPublication,
    getPublicationAndUsers,
    getPublicationById,
    createPublication,
    updatePublication,
    deletePublication,
    joinPublication,
    getPublicationsByUser,
    getPublicationUsername,
    getPublicationsByAuthor
};
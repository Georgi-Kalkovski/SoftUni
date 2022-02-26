const Ad = require('../models/Ad');

async function getAllAds() {
    return Ad.find({}).lean();
}

async function getThreeAds() {
    return Ad.find({}).lean().limit(3);
}

async function getAdsByUser(userId) {
    return Ad.find({ author: userId }).lean();
}

async function getAdById(id) {
    return Ad.findById(id).lean();
}

async function getAdAndUsers(id) {
    return Ad.findById(id).populate('author').populate('users').lean();
}

async function createAd(ad) {
    const result = new Ad(ad);
    await result.save();
}

async function updateAd(id, ad) {
    const existing = await Ad.findById(id);

    existing.headline = ad.headline;
    existing.location = ad.location;
    existing.companyName = ad.companyName;
    existing.companyDescription = ad.companyDescription;

    await existing.save();
}

async function deleteById(id) {
    return Ad.findByIdAndDelete(id);
}

async function joinAd(adId, userId) {
    const ad = await Ad.findById(adId);

    if (ad.users.includes(userId)) {
        throw new Error('User is already part of the ad');
    }

    ad.users.push(userId);
    await ad.save();
}

function searchAd(type) {
    return Ad.find({type: type});
}

module.exports = {
    getAllAds,
    getThreeAds,
    getAdsByUser,
    getAdAndUsers,
    getAdById,
    createAd,
    updateAd,
    deleteById,
    joinAd,
    searchAd
};
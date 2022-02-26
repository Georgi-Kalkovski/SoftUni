const { Schema, model, Types: { ObjectId } } = require('mongoose');

const URL_PATTERN = /^https?:\/\/(.+)$/;

const adSchema = new Schema({
    headline: { type: String, required: true, minlength: [4, 'Headline should be a minimum of 4 characters long'] },
    location: { type: String, required: true, minlength: [8, 'Location should be a minimum of 8 characters long'] },
    companyName: { type: String, required: true, minlength: [3, 'Company name should be at least 3 characters'] },
    companyDescription: { type: String, required: true, maxlength: [40, 'Company description should be a maximum of 40 characters long'] },
    author: { type: ObjectId, ref: 'User', required: true },
    users: { type: [ObjectId], ref: 'User', default: [] },
}, {
    timestamp: true
});

const Ad = model('Ad', adSchema);

module.exports = Ad;
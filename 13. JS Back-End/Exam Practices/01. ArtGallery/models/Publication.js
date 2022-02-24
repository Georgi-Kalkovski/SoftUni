const { Schema, model, Types: { ObjectId } } = require('mongoose');

// TODO change user model according to exam description
// TODO add validation

const publicationSchema = new Schema({
    title: { type: String, required: true },
    tech: { type: String, required: true },
    picture: { type: String, required: true },
    certificate: { type: String, required: true, enum: ['Yes', 'No'] },
    author: { type: ObjectId, ref: 'User', required: true },
    username: { type: String },
    shares: { type: [ObjectId], ref: 'User', default: [] }
});

const Publication = model('Publication', publicationSchema);

module.exports = Publication;
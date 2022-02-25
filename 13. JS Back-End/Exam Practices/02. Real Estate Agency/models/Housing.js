const { Schema, model, Types: { ObjectId } } = require('mongoose');

const URL_PATTERN = /^https?:\/\/(.+)$/;

const housingSchema = new Schema({
    name: { type: String, required: true, minlength: [6, 'Name should be at least 6 characters long'] },
    type: { type: String, required: true, enum: ['Apartment', 'Villa', 'House'] },
    year: { type: Number, required: true, min: 1850, max: 2021 },
    city: { type: String, required: true, minlength: [4, 'City should be at least 4 characters long'] },
    homeImage: {
        type: String, required: true, validate: {
            validator(value) {
                return URL_PATTERN.test(value);
            },
            message: 'Home Image must be a valid URL'
        }
    },
    description: { type: String, required: true, maxlength: [60, 'Property Description should be maximum 60 characters long'] },
    availablePieces: { type: Number, required: true,min: 0, max: 10 },
    rented: { type: [ObjectId], ref: 'User', default: [] },
    owner: { type: ObjectId, ref: 'User', required: true }
});


const Housing = model('Housing', housingSchema);

module.exports = Housing;
const { Schema, model, Types: { ObjectId } } = require('mongoose');

const URL_PATTERN = /^https?:\/\/(.+)$/;

const tripSchema = new Schema({
    start: { type: String, required: true, minlength: [4, 'Starting Point should be at least 4 characters long'] },
    end: { type: String, required: true, minlength: [4, 'End Point should be at least 4 characters long'] },
    date: { type: String, required: true },
    time: { type: String, required: true },
    carImg: {
        type: String, required: true, validate: {
            validator(value) {
                return URL_PATTERN.test(value);
            },
            message: 'Car Image must be a valid URL'
        }
    },
    carBrand: { type: String, required: true, minlength: [4, 'Car Brand should be at least 4 characters long'] },
    seats: { type: Number, required: true, min: 0, max: 4 },
    price: { type: Number, required: true, min: 1, max: 50 },
    description: { type: String, required: true, minlength: [10, 'Description should be at least 10 characters long'] },
    owner: { type: ObjectId, ref: 'User', required: true },
    buddies: { type: [ObjectId], ref: 'User', default: [] },
});

const Trip = model('Trip', tripSchema);

module.exports = Trip;
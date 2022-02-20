const { Schema, model, Types: { ObjectId } } = require('mongoose');

// TODO add validation
const tripSchema = new Schema({
    start: { type: String, required: true },
    end: { type: String, required: true },
    date: { type: String, required: true },
    time: { type: String, required: true },
    carImg: { type: String, required: true },
    carBrand: { type: String, required: true },
    seats: { type: Number, required: true },
    price: { type: Number, required: true },
    description: { type: String, required: true },
    owner: { type: ObjectId, ref: 'User', required: true },
    buddies: { type: [ObjectId], ref: 'User', default: [] },
});

const Trip = model('Trip', tripSchema);

module.exports = Trip;
const { model, Schema, Types: { ObjectId } } = require('mongoose');

const schema = new Schema({
    make: { type: String, required: [true, 'Make is required'] },
    model: { type: String, required: true },
    year: {
        type: Number,
        required: true,
        min: [1950, 'Year must be between 1950 and 2050'],
        max: [2050, 'Year must be between 1950 and 2050']
    },
    description: { type: String, required: true, minlength: [10, 'Description must be at least 10 characters long'] },
    price: { type: Number, required: true },
    img: { type: String, required: true },
    material: { type: String },
    owner: { type: ObjectId, ref: 'User' }
});

const Item = model('Item', schema);

module.exports = Item;
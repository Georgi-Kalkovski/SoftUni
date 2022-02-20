const { Schema, model, Types: { ObjectId } } = require('mongoose');

// TODO add validation

const userSchema = new Schema({
    email: { type: String, required: true },
    hashedPassword: { type: String, required: true },
    gender: { type: String, required: true },
    trips: { type: [ObjectId], ref: 'Trip', default: [] },
});

userSchema.index({ email: 1 }, {
    unique: true,
    collation: {
        locale: 'en',
        strength: 2
    }
});

const User = model('User', userSchema);

module.exports = User;
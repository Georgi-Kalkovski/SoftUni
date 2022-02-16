const { Schema, model } = require('mongoose');

// TODO change user model according to exam description
// TODO add validation

const userSchema = new Schema({
    username: { type: String, required: true },
    hashedPassword: { type: String, required: true },
});

userSchema.index({ username: 1 }, {
    unique: true,
    collation: {
        locale: 'en',
        strength: 2
    }
});

const User = model('User', userSchema);

module.exports = User;
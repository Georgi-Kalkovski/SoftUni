const { Schema, model } = require('mongoose');

const NAME_PATTERN = /^([a-zA-Z]+) ([a-zA-Z]+)$/;

const userSchema = new Schema({
    name: {
        type: String, required: true, validate: {
            validator(value) {
                return NAME_PATTERN.test(value);
            },
            message: 'Name must contain First Name and Last Name'
        }
    },
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
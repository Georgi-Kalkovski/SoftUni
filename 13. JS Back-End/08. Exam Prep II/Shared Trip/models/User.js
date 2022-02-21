const { Schema, model, Types: { ObjectId } } = require('mongoose');

const EMAIL_PATTERN = /^([a-zA-Z]+)@([a-zA-Z]+)\.([a-zA-Z]+)$/;

const userSchema = new Schema({
    email: {
        type: String, required: true, validate: {
            validator(value) {
                return EMAIL_PATTERN.test(value);
            },
            message: 'Email must be valid'
        }
    },
    hashedPassword: { type: String, required: true },
    gender: { type: String, required: true, enum: ['male', 'female'] },
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
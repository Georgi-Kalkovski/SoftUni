const { Schema, model, Types: { ObjectId } } = require('mongoose');

// TODO change user model according to exam description
// TODO add validation
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
    description: { type: String, required: true, maxlength: [40, 'Description should be maximum 40 characters long']  },
    ads: { type: [ObjectId], ref: 'Ad', default: [] },
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
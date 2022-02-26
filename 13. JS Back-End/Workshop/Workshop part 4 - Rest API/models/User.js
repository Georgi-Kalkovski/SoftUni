const { model, Schema } = require('mongoose');


const userSchema = new Schema({
    email: { type: String, required: [true, 'Email is required'] },
    hashedPassword: { type: String, required: true },
});


userSchema.index({ email: 1}, {
    collation: {
        locale: 'en',
        strength: 1
    }
});

const User = model('User', userSchema);

module.exports = User;
const mongoose = require('mongoose');

const signUpTemplate = new mongoose.Schema({
    email: {
        type: String,
        required: true
    },
    password: {
        type: String,
        required: true
    },
    books: [{
        bookName:String,
        page:Number,
    }],
    date: {
        type: Date,
        default: Date.now
    },
});

module.exports = mongoose.model('mytable', signUpTemplate);
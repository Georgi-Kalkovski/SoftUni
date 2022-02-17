const Post = require('../models/Post')

async function createPost(post) {
    const result = new Post(post);
    await result.save();

    return result;
}

async function getPosts() {
    return Post.find({});
}

async function getPostById(id) {
    return Post.findById(id).populate('author', 'firstName lastName');
}

module.exports = {
    createPost,
    getPosts,
    getPostById
};
const Post = require('../models/Post')

async function createPost(post) {
    const result = new Post(post);
    await result.save();

    return result;
}

async function getPosts() {
    return Post.find({});
}

async function getPostsByAuthor(userId) {
    return Post.find({ author: userId }).populate('author', 'firstName lastName');
}

async function getPostById(id) {
    return Post.findById(id).populate('author', 'firstName lastName').populate('votes', 'email');
}

async function updatePost(id, post) {
    const exisiting = await Post.findById(id);

    exisiting.title = post.title;
    exisiting.keyword = post.keyword;
    exisiting.location = post.location;
    exisiting.date = post.date;
    exisiting.image = post.image;
    exisiting.description = post.description;

    await exisiting.save();
}

async function deletePost(id) {
    return Post.findByIdAndDelete(id).populate('author', 'firstName lastName').populate('votes','email');
}

async function vote(postId, userId, value) {
    const post = await Post.findById(postId);

    if (post.votes.includes(userId)) {
        throw new Error('User has already voted');
    }

    post.votes.push(userId);
    post.rating += value;

    await post.save();
}

module.exports = {
    createPost,
    getPosts,
    getPostsByAuthor,
    getPostById,
    updatePost,
    deletePost,
    vote
};
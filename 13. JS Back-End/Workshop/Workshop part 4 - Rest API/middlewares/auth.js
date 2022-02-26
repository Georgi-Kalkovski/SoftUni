const { verifySession } = require('../services/users');

module.exports = () => (req, res, next) => {
    const token = req.headers['x-authorization'];

    try {
        if (token) {
            const userData = verifySession(token);
            req.user = userData;
        }
        next();
    } catch (err) {
        res.status(498).json({ message: 'Invalid access token. Please sign in' });
    }
};
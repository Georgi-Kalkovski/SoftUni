const authController = require('../controllers/auth') 


module.exports = (app) => {
    app.use(authController);
}
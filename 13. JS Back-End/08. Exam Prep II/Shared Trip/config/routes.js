const authController = require('../controllers/auth')
const tripController = require('../controllers/trip')
const homeController = require('../controllers/home')

module.exports = (app) => {
    app.use(authController);
    app.use(tripController);
    app.use(homeController);

    app.get('*', (req, res) => {
        res.render('404', { title: 'Page not found' });
    });
};
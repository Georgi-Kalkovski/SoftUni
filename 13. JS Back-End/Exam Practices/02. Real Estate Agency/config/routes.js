const authController = require('../controllers/auth');
const homeController = require('../controllers/home');
const housingController = require('../controllers/housing')


module.exports = (app) => {
    app.use(authController);
    app.use(homeController);
    app.use(housingController);
	
    app.get('*', (req, res) => {
        res.render('404', { title: 'Page not found' });
    });
	
};

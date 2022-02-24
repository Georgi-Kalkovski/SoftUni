const authController = require('../controllers/auth') 
const homeController = require('../controllers/home') 
const publicationController = require('../controllers/publication') 

module.exports = (app) => {
    app.use(authController);
    app.use(homeController);
    app.use(publicationController);
	
    app.get('*', (req, res) => {
        res.render('404', { title: 'Page not found' });
    });
	
};

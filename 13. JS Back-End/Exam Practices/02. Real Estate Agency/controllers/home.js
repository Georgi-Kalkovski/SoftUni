const preload = require('../middleware/preload');
const { getAllHousing, searchHousing } = require('../services/housing');

const router = require('express').Router();

router.get('/', async (req, res) => {
    const rents = await getAllHousing();
    res.render('home', { title: 'Home Page', data: rents });
});

router.get('/rents', async (req, res) => {
    const rents = await getAllHousing();
    res.render('rents', { title: 'Housing for rent', data: rents });
});

router.get('/rents/:id', preload(true), (req, res) => {
    const housing = res.locals.housing;
    housing.piecesLeft = housing.availablePieces - housing.rented.length;
    housing.rentedList = housing.rented.map(b => b.username).join(', ')
    if (req.session.user) {
        housing.hasUser = true;
        housing.isOwner = req.session.user._id == housing.owner._id;

        if (housing.rented.some(b => b._id == req.session.user._id)) {
            housing.isJoined = true;
        }
    }

    res.render('details', { title: 'Rents Details', data: housing });
});

router.get('/search', async (req, res) => {
    const type = req.params.type;
    const found = await searchHousing(type)
    res.render('search', { title: 'Housing for rent', found });
});


module.exports = router;
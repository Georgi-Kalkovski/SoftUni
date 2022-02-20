const preload = require('../middleware/preload');
const { getAllTrips } = require('../services/trip');

const router = require('express').Router();

router.get('/', (req, res) => {
    res.render('home');
});

router.get('/trips', async (req, res) => {
    const trips = await getAllTrips();
    res.render('catalog', { title: 'Shared Trips', trips });
});

router.get('/trips/:id', preload(true), (req, res) => {
    if (req.session.user) {
        res.locals.trip.hasUser = true;
        res.locals.trip.isOwner = req.session.user._id == res.locals.trip.owner._id;
    }

    res.render('details', { title: 'Trips Details' });
});


module.exports = router;
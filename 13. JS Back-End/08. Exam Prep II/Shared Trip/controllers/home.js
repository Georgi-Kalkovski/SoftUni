const { isUser } = require('../middleware/guards');
const preload = require('../middleware/preload');
const { getAllTrips, getTripsByUser } = require('../services/trip');

const router = require('express').Router();

router.get('/', (req, res) => {
    res.render('home');
});

router.get('/trips', async (req, res) => {
    const trips = await getAllTrips();
    res.render('catalog', { title: 'Shared Trips', trips });
});

router.get('/trips/:id', preload(true), (req, res) => {
    const trip = res.locals.trip;
    trip.remainingSeats = trip.seats - trip.buddies.length;
    trip.buddiesList = trip.buddies.map(b => b.email).join(', ')
    if (req.session.user) {
        trip.hasUser = true;
        trip.isOwner = req.session.user._id == trip.owner._id;

        if (trip.buddies.some(b => b._id == req.session.user._id)) {
            trip.isJoined = true;
        }
    }

    res.render('details', { title: 'Trips Details' });
});

router.get('/profile', isUser(), async (req, res) => {
    const tripsByUser = await getTripsByUser(res.locals.user._id);
    res.locals.user.tripCount = tripsByUser.length;
    res.locals.user.trips = tripsByUser;
    res.render('profile', { title: 'Profile Page' });
});


module.exports = router;
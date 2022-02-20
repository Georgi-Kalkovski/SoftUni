const { isUser } = require('../middleware/guards');
const { mapErrors } = require('../util/mappers')

const router = require('express').Router();
const { createTrip } = require('../services/trip');

router.get('/create', isUser(), (req, res) => {
    res.render('create', { title: 'Create Trip Offer', data: {} });
});

router.post('/create', isUser(), async (req, res) => {
    const trip = {
        startPoint: req.body.startPoint,
        endPoint: req.body.endPoint,
        date: req.body.date,
        time: req.body.time,
        carImg: req.body.carImg,
        carBrand: req.body.carBrand,
        seats: req.body.seats,
        price: req.body.price,
        description: req.body.description,
        owner: req.session.user._id
    };
    try {
        await createTrip(trip);
        res.redirect('/trip');
    } catch (err) {
        const errors = mapErrors(err);
        res.render('create', { title: 'Create Trip Offer', data: trip, errors });
    }
    console.log(req.body);
    res.redirect('/trips');
});


module.exports = router;
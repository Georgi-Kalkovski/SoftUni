const { isUser, isOwner } = require('../middleware/guards');
const preload = require('../middleware/preload');
const { createHousing, updateHousing, deleteById, joinHousing } = require('../services/housing');
const mapErrors = require('../util/mappers');

const router = require('express').Router();

router.get('/create', isUser(), (req, res) => {
    res.render('create', { title: 'Create Housing Offer', data: {} });
});

router.post('/create', isUser(), async (req, res) => {
    const housing = {
        name: req.body.name,
        type: req.body.type,
        year:  Number(req.body.year),
        city: req.body.city,
        homeImage: req.body.homeImage,
        description: req.body.description,
        availablePieces : Number(req.body.availablePieces),
        owner: req.session.user._id
    };

    try {
        await createHousing(housing);
        res.redirect('/rents');
    } catch (err) {
        console.log(err);
        const errors = mapErrors(err);
        res.render('create', { title: 'Create Housing Offer', data: housing, errors });
    }
});
router.get('/edit/:id', preload(), isOwner(), (req, res) => {
    res.render('edit', { title: 'Edit Offer' });
});

router.post('/edit/:id', preload(), isOwner(), async (req, res) => {
    const id = req.params.id;

    const housing = {
        name: req.body.name,
        type: req.body.type,
        year:  Number(req.body.year),
        city: req.body.city,
        homeImage: req.body.homeImage,
        description: req.body.description,
        availablePieces : Number(req.body.availablePieces),
        owner: req.session.user._id
    };

    try {
        await updateHousing(id, housing);
        res.redirect('/rents/' + id);
    } catch (err) {
        console.log(err);
        const errors = mapErrors(err);
        housing._id = id;
        res.render('edit', { title: 'Edit Housing Offer', housing, errors });
    }
});

router.get('/delete/:id', preload(), isOwner(), async (req, res) => {
    await deleteById(req.params.id);
    res.redirect('/rents');
});

router.get('/join/:id', isUser(), async (req, res) => {
    const id = req.params.id;
    try {
        await joinHousing(id, req.session.user._id);
    } catch (err) {
        console.log(err);
    } finally {
        res.redirect('/rents/' + id);
    }
});
module.exports = router;
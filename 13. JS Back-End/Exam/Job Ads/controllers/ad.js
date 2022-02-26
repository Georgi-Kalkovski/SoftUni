const { isUser, isOwner } = require('../middleware/guards');
const preload = require('../middleware/preload');
const { createAd, updateAd, deleteById, joinAd } = require('../services/ad');
const mapErrors = require('../util/mappers')

const router = require('express').Router();

router.get('/create', isUser(), (req, res) => {
    res.render('create', { title: 'Create Ad Offer', data: {} });
});

router.post('/create', isUser(), async (req, res) => {
    const ad = {
        headline: req.body.headline,
        location: req.body.location,
        companyName: req.body.companyName,
        companyDescription: req.body.companyDescription,
        author: req.session.user._id
    };

    try {
        await createAd(ad);
        res.redirect('/ads');
    } catch (err) {
        console.log(err);
        const errors = mapErrors(err);
        res.render('create', { title: 'Create Ad Offer', data: ad, errors });
    }
});

router.get('/edit/:id', preload(), isOwner(), (req, res) => {
    res.render('edit', { title: 'Edit Offer' });
});

router.post('/edit/:id', preload(), isOwner(), async (req, res) => {
    const id = req.params.id;

    const ad = {
        headline: req.body.headline,
        location: req.body.location,
        companyName: req.body.companyName,
        companyDescription: req.body.companyDescription,
        author: req.session.user._id
    };

    try {
        await updateAd(id, ad);
        res.redirect('/ads/' + id);
    } catch (err) {
        console.log(err);
        const errors = mapErrors(err);
        ad._id = id;
        res.render('edit', { title: 'Edit Ad Offer', ad, errors });
    }
});

router.get('/delete/:id', preload(), isOwner(), async (req, res) => {
    await deleteById(req.params.id);
    res.redirect('/ads');
});

router.get('/join/:id', isUser(), async (req, res) => {
    const id = req.params.id;
    try {
        await joinAd(id, req.session.user._id);
    } catch (err) {
        console.log(err);
    } finally {
        res.redirect('/ads/' + id);
    }
});

module.exports = router;
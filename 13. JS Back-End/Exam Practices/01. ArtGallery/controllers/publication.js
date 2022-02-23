const router = require('express').Router();
const { isUser } = require('../middleware/guards');
const { createPublication } = require('../services/publication');
const { mapErrors } = require('../util/mappers')

router.get('/create', isUser(), (req, res) => {
    res.render('create', { title: 'Create Publication', data: {} });
});

router.post('/create', isUser(), async (req, res) => {
    const publication = {
        title: req.body.title,
        technique: req.body.technique,
        picture: req.body.picture,
        certificate: req.body.certificate,
        author: req.session.user._id
    };

    try {
        await createPublication(publication);
        res.redirect('/gallery');
    } catch (err) {
        console.log(err);
        const errors = mapErrors(err);
        res.render('create', { title: 'Create Publication', data: publication, errors });
    }
});

module.exports = router;
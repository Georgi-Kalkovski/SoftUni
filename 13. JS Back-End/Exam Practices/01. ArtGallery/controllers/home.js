const { getAllPublication, getPublicationById, getPublicationsByAuthor } = require('../services/publication');
const { publicationViewModel } = require('../util/mappers');
const { isUser } = require('../middleware/guards')

const router = require('express').Router();

router.get('/', (req, res) => {
    res.render('home', { title: 'Home Page' });
});

router.get('/gallery', async (req, res) => {
    const publications = (await getAllPublication()).map(publicationViewModel);
    res.render('gallery', { title: 'Gallery Page', publications })
});

router.get('/gallery/:id', async (req, res) => {
    const id = req.params.id;
    const publication = publicationViewModel(await getPublicationById(id));
    console.log(publication)
    if (publication.shares) {
        publication.hasShared = true;
    }
    res.render('details', { title: publication.title, publication });
});

router.get('/profile', isUser(), async (req, res) => {
    const publications = (await getPublicationsByAuthor(req.session.user._id)).map(publicationViewModel);
    const data = {
        publications,
        username: req.session.user.username,
        address: req.session.user.address,
    }
    if (data.publications != []) {
        publications.isAuthor = true;
    }
    if (publications.shares) {
        publications.hasShared = true;
    }
    res.render('profile', { title: 'My Publications', data })
});

module.exports = router;
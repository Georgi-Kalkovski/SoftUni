const { getAllPublications, getPublicationById } = require('../services/publication');
const { publicationsViewModel } = require('../util/mappers');

const router = require('express').Router();

router.get('/', (req, res) => {
    res.render('home');
});

router.get('/gallery', async (req, res) => {
    const gallery = await getAllPublications();
    res.render('gallery', { title: 'ArtGallery ', gallery });
});


router.get('/gallery/:id', async (req, res) => {
    const id = req.params.id;
    const publication = publicationsViewModel(await getPublicationById(id));

    console.log(publication)
    if (req.session.user) {
        publication.hasUser = true;
        publication.userName = publication;
        if (req.session.user._id == publication.author._id) {
            publication.isAuthor = true;
        } else {
            publication.hasShared = publication.users.find(v => v._id == req.session.user._id) != undefined;
        }
    }
    res.render('details', { title: publication.title, publication });
});

module.exports = router;
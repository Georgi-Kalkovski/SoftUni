const preload = require('../middleware/preload');
const { getAllAds, getThreeAds, searchAd } = require('../services/ad');

const router = require('express').Router();

router.get('/', preload(true), async (req, res) => {
    let ads = await getThreeAds();
    const ad = res.locals.ad;
    ad.usersCount = ad.users.length;
    res.render('home', { title: 'Home Page', ads });
});

router.get('/ads', async (req, res) => {
    const ads = await getAllAds();
    res.render('ads', { title: 'All Ads', ads });
});

router.get('/ads/:id', preload(true), (req, res) => {
    const ad = res.locals.ad;
    ad.usersCount = ad.users.length;
    ad.usersList = ad.users.map(b => b.email).join(', ')
    if (req.session.user) {
        ad.hasUser = true;
        ad.isOwner = req.session.user._id == ad.author._id;

        if (ad.users.some(b => b._id == req.session.user._id)) {
            ad.isJoined = true;
        }
    }

    res.render('details', { title: 'Ad Details', data: ad });
});

router.get('/search', async (req, res) => {
    const email = req.params.email;
    const found = await searchAd(email);
    res.render('search', { title: 'Search for ad', found });
});

module.exports = router;
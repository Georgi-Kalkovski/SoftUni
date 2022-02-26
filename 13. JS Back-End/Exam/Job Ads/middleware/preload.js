const adService = require('../services/ad');

function preload(populate) {
    return async function (req, res, next) {
        const id = req.params.id;
        
        if (populate) {
            res.locals.ad = await adService.getAdAndUsers(id);
        } else {
            res.locals.ad = await adService.getAdById(id);

        }
        next();
    };
}

module.exports = preload;
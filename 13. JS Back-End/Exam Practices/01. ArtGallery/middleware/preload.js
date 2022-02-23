const publicationsService = require('../services/publication');

function preload(populate) {
    return async function (req, res, next) {
        const id = req.params.id;
        
        if (populate) {
            res.locals.publications = await publicationsService.getPublicationAndUsers(id);
        } else {
            res.locals.publications = await publicationsService.getPublicationById(id);

        }
        next();
    };
}

module.exports = preload;
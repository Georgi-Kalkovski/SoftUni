const housingService = require('../services/housing');

function preload(populate) {
    return async function (req, res, next) {
        const id = req.params.id;
        
        if (populate) {
            res.locals.housing = await housingService.getHousingAndUsers(id);
        } else {
            res.locals.housing = await housingService.getHousingById(id);

        }
        next();
    };
}

module.exports = preload;
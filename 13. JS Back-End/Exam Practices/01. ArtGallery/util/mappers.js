function mapErrors(err) {
    if (Array.isArray(err)) {
        return err;
    } else if (err.name == 'ValidationError') {
        return Object.values(err.errors).map(e => ({ msg: e.message }));
    } else if (typeof err.message == 'string') {
        return [{ msg: err.message }];
    } else {
        return [{ msg: 'Request error' }];
    }
}



function publicationViewModel(publication) {
    return {
        _id: publication._id,
        title: publication.title,
        tech: publication.tech,
        picture: publication.picture,
        certificate: publication.certificate,
        author: authorViewModel(publication.author),
        shares: publication.shares.map(sharesViewModel),
        username: publication.username
    };
}

function authorViewModel(user) {
    return {
        _id: user._id,
        username: user.username
    };
}

function sharesViewModel(user) {
    return {
        _id: user._id,
        username: user.username
    };
}


module.exports = {
    mapErrors,
    publicationViewModel
};
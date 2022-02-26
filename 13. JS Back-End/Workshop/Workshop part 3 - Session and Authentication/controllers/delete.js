module.exports = {
    async get(req, res) {
        const id = req.params.id;
        const car = await req.storage.getById(id);

        if (car.owner != req.session.user.id) {
            console.log('User is not owner!');
            return res.redirect('/login');
        }

        if (car) {
            res.render('delete', { title: `Delete Listing - ${car.name}`, car });
        } else {
            res.redirect('404');
        }
    },
    async post(req, res) {
        const id = req.params.id;

        try {
            if (await req.storage.deleteById(id, req.session.user.id)) {
                res.redirect('/');
            } else {
                return res.redirect('/login');
            }
        } catch (err) {
            console.log('Attempted to delete non-existent Id', id);
            res.redirect('/404');
        }
    }
};
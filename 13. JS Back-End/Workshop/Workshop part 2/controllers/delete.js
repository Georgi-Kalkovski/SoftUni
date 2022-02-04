module.exports = {
    async get(req, res) {
        const id = req.params.id;
        const car = await req.storage.getById(id);

        if (car) {
            res.render('delete', { title: `Delete Listing - ${car.name}`, car });
        } else {
            res.redirect('404');
        }
    },
    async post(req, res) {
        const id = req.params.id;
        
        try {
            await req.storage.deleteById(id);
            res.redirect('/');
        } catch (err) {
            console.log('Attempted to delete non-existent Id', id);
            res.redirect('/404');
        }
    }
};
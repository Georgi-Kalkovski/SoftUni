module.exports = {
    async details(req, res) {
        const id = req.params.id;
        const car = await req.storage.getById(id);

        console.log(car);

        if (car) {
            res.render('details', { title: `Carbicle - ${car.name}`, car });
        } else {
            res.redirect('/404');
        }
    }
};
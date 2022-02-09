module.exports = {
    registerGet(req, res) {
        res.render('register', { title: 'Register' });
    },
    async registerPost(req, res) {
        if (req.body.username == '' || req.body.password == '') {
            return res.redirect('/register');
        }
        if (req.body.password != req.body.repeatPassword) {
            return res.redirect('/register');
        }

        try {
            await req.auth.register(req.body.username, req.body.password);
            res.redirect('/');
        } catch (err) {
            console.error(err.message);
            res.redirect('/register');
        }
    },
    loginGet(req, res) {
        res.render('login', { title: 'Login' });
    },
    async loginPost(req, res) {
        try {
            await req.auth.login(req.body.username, req.body.password);
            res.redirect('/');
        } catch (err) {
            console.error(err.message);
            res.redirect('/login');
        }
    },
    logout(req, res) {
        req.auth.logout();
        res.redirect('/');
    },
};
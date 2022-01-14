const http = require('http');
const { catalogController, createController, deleteController } = require('./controllers/catalogController');
const { homeController, aboutController } = require('./controllers/homeController');

const router = require('./router');

const server = http.createServer(router.main);

router.get('/', homeController);
router.get('/about', aboutController);
router.get('/catalog', catalogController);
router.post('/create', createController);
router.get('/delete', deleteController);

server.listen(3000);
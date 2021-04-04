
const { chromium } = require('playwright-chromium');
const { expect } = require('chai');

const host = 'http://localhost:3000'; // Application host (NOT service host - that can be anything)
const interval = 300;
const timeout = 6000;
const DEBUG = true;
const slowMo = 500;

const mockData = require('./mock-data.json');
const endpoints = {
    register: '/users/register',
    login: '/users/login',
    logout: '/users/logout',
    home: '/data/wiki?sortBy=_createdOn%20desc&distinct=category',
    catalog: '/data/wiki?sortBy=_createdOn%20desc',
    create: '/data/wiki',
    details: (id) => `/data/wiki/${id}`,
    search: (query) => `/data/wiki?where=title%20LIKE%20%22${query}%22`
};


let browser;
let context;
let page;

describe('E2E tests', function () {
    // Setup
    this.timeout(DEBUG ? 120000 : timeout);
    before(async () => browser = await chromium.launch(DEBUG ? { headless: false, slowMo } : {}));
    after(async () => await browser.close());
    beforeEach(async () => {
        context = await browser.newContext();
        setupContext(context);
        page = await context.newPage();
    });
    afterEach(async () => {
        await page.close();
        await context.close();
    });


    // Test proper
    describe('Authentication [ 20 Points ]', () => {
        it('register does not work with empty fields [ 5 Points ]', async () => {
            const { post } = await createHandler(endpoints.register, { post: {} });

            await page.goto(host);
            await page.waitForTimeout(interval);

            await page.click('nav >> text=Register');
            await page.waitForTimeout(interval);

            await page.waitForSelector('form');
            await page.click('[type="submit"]');
            await page.waitForTimeout(interval);

            expect(post.isCalled).to.be.false;
        });

        it('register makes correct API call [ 5 Points ]', async () => {
            const data = mockData.users[0];
            const { post } = await createHandler(endpoints.register, { post: data });

            await page.goto(host);
            await page.waitForTimeout(interval);

            await page.click('nav >> text=Register');
            await page.waitForTimeout(interval);

            await page.waitForSelector('form');
            await page.fill('[name="email"]', data.email);
            await page.fill('[name="password"]', data.password);
            await page.fill('[name="rep-pass"]', data.password);

            const [request] = await Promise.all([
                post.waitForRequest(),
                page.click('[type="submit"]')
            ]);

            const postData = JSON.parse(request.postData());

            expect(postData.username).to.equal(data.username);
            expect(postData.password).to.equal(data.password);
        });

        it('login makes correct API call [ 5 Points ]', async () => {
            const data = mockData.users[0];
            const { post } = await createHandler(endpoints.login, { post: data });

            await page.goto(host);
            await page.waitForTimeout(interval);

            await page.click('nav >> text=Login');
            await page.waitForTimeout(interval);

            await page.waitForSelector('form');
            await page.fill('[name="email"]', data.email);
            await page.fill('[name="password"]', data.password);

            const [request] = await Promise.all([
                post.waitForRequest(),
                page.click('[type="submit"]')
            ]);

            const postData = JSON.parse(request.postData());
            expect(postData.username).to.equal(data.username);
            expect(postData.password).to.equal(data.password);
        });

        it('logout makes correct API call [ 5 Points ]', async () => {
            const data = mockData.users[0];
            const { post: loginPost } = await createHandler(endpoints.login, { post: data });
            const { get: logoutGet } = await createHandler(endpoints.logout, { get: { data: '', options: { json: false, status: 204 } } });

            await page.goto(host);
            await page.waitForTimeout(interval);

            await page.click('nav >> text=Login');
            await page.waitForTimeout(interval);

            await page.waitForSelector('form');
            await page.fill('[name="email"]', data.email);
            await page.fill('[name="password"]', data.password);

            await Promise.all([
                loginPost.waitForResponse(),
                page.click('[type="submit"]')
            ]);

            await page.waitForTimeout(interval);

            const [request] = await Promise.all([
                logoutGet.waitForRequest(),
                page.click('nav >> text=Logout')
            ]);

            const token = request.headers()['x-authorization'];
            expect(token).to.equal(data.accessToken);
        });
    });

    describe('Navigation bar [ 5 Points ]', () => {
        it('guest user should see correct navigation [ 2.5 Points ]', async () => {
            await page.goto(host);
            await page.waitForTimeout(interval);

            expect(await page.isVisible('nav >> text=Catalogue')).to.be.true;
            expect(await page.isVisible('nav >> text=Search')).to.be.true;
            expect(await page.isVisible('nav >> text=Login')).to.be.true;
            expect(await page.isVisible('nav >> text=Register')).to.be.true;

            expect(await page.isVisible('nav >> text=Create')).to.be.false;
            expect(await page.isVisible('nav >> text=Logout')).to.be.false;
        });

        it('logged user should see correct navigation [ 2.5 Points ]', async () => {
            // Login user
            const data = mockData.users[0];
            await page.goto(host);
            await page.waitForTimeout(interval);

            await page.click('nav >> text=Login');
            await page.waitForTimeout(interval);

            await page.waitForSelector('form');
            await page.fill('[name="email"]', data.email);
            await page.fill('[name="password"]', data.password);

            await page.click('[type="submit"]');
            await page.waitForTimeout(interval);

            //Test for navigation
            expect(await page.isVisible('nav >> text=Catalogue')).to.be.true;
            expect(await page.isVisible('nav >> text=Search')).to.be.true;
            expect(await page.isVisible('nav >> text=Create')).to.be.true;
            expect(await page.isVisible('nav >> text=Logout')).to.be.true;

            expect(await page.isVisible('nav >> text=Login')).to.be.false;
            expect(await page.isVisible('nav >> text=Register')).to.be.false;
        });
    });

    describe('Catalog [ 20 Points ]', () => {
        it('show empty catalog [ 2.5 Points ]', async () => {
            await createHandler(endpoints.catalog, { get: [] });
            await page.goto(host);
            await page.waitForTimeout(interval);

            await page.click('nav >> text=Catalogue');
            await page.waitForTimeout(interval);

            const titles = await page.$$eval('#catalog-page article h3', t => t.map(s => s.textContent));
            expect(titles.length).to.equal(0);
            expect(await page.isVisible('text=No articles yet')).to.be.true;
        });

        it('show catalog [ 7.5 Points ]', async () => {
            await page.goto(host);
            await page.waitForTimeout(interval);

            await page.click('nav >> text=Catalogue');
            await page.waitForTimeout(interval);

            const titles = await page.$$eval('#catalog-page h3', t => t.map(s => s.textContent));

            expect(titles.length).to.equal(mockData.catalog.length);
            expect(titles[0]).to.contains(mockData.catalog[0].title);
            expect(titles[1]).to.contains(mockData.catalog[1].title);
            expect(titles[2]).to.contains(mockData.catalog[2].title);
            expect(titles[3]).to.contains(mockData.catalog[3].title);
            expect(titles[4]).to.contains(mockData.catalog[4].title);
            expect(await page.isVisible('text=No articles yet')).to.be.false;
        });

        it('show details [ 5 Points ]', async () => {
            const data = mockData.catalog[0];

            await page.goto(host);
            await page.waitForTimeout(interval);

            await page.click('nav >> text=Catalogue');
            await page.waitForTimeout(interval);

            await page.waitForSelector('#catalog-page');
            await page.click(`.article-preview:has-text("${data.title}")`);
            await page.waitForTimeout(interval);

            expect(await page.isVisible(`h1:has-text("${data.title}")`)).to.be.true;
            expect(await page.isVisible(`strong:has-text("${data.category}")`)).to.be.true;
            expect(await page.isVisible(`p:has-text("${data.content}")`)).to.be.true;
        });

        it('guest does NOT see edit/delete buttons [ 5 Points ]', async () => {
            await page.goto(host);
            await page.waitForTimeout(interval);

            await page.click('nav >> text=Catalogue');
            await page.waitForTimeout(interval);

            await page.waitForSelector('#catalog-page');
            await page.click(`.article-preview:has-text("${mockData.catalog[0].title}")`);
            await page.waitForTimeout(interval);

            expect(await page.isVisible('text="Delete"')).to.be.false;
            expect(await page.isVisible('text="Edit"')).to.be.false;
        });
    });

    describe('CRUD [ 40 Points ]', () => {

        // Login user
        beforeEach(async () => {
            const data = mockData.users[0];
            await page.goto(host);
            await page.waitForTimeout(interval);
            await page.click('text=Login');
            await page.waitForTimeout(interval);
            await page.waitForSelector('form');
            await page.fill('[name="email"]', data.email);
            await page.fill('[name="password"]', data.password);
            await page.click('[type="submit"]');
            await page.waitForTimeout(interval);
        });

        it('create does NOT work with empty fields [ 5 Points ]', async () => {
            const { post } = await createHandler(endpoints.create, { post: '' });

            await page.click('text=Create');
            await page.waitForTimeout(interval);

            await page.waitForSelector('form');
            page.click('[type="submit"]');
            await page.waitForTimeout(interval);

            expect(post.isCalled).to.be.false;
        });

        it('create makes correct API call for logged in user [ 10 Points ]', async () => {
            const data = mockData.catalog[0];
            const { post } = await createHandler(endpoints.create, { post: data });

            await page.click('text=Create');
            await page.waitForTimeout(interval);

            await page.waitForSelector('form');
            await page.fill('[name="title"]', data.title);
            await page.fill('[name="category"]', data.category);
            await page.fill('[name="content"]', data.content);

            const [request] = await Promise.all([
                post.waitForRequest(),
                page.click('[type="submit"]')
            ]);

            const postData = JSON.parse(request.postData());

            expect(postData.title).to.equal(data.title);
            expect(postData.category).to.equal(data.category);
            expect(postData.content).to.equal(data.content);
        });

        it('non-author does NOT see delete and edit buttons [ 2.5 Points ]', async () => {
            await page.click('nav >> text=Catalogue');
            await page.waitForTimeout(interval);

            await page.waitForSelector('#catalog-page');
            await page.click(`.article-preview:has-text("${mockData.catalog[1].title}")`);
            await page.waitForTimeout(interval);

            expect(await page.isVisible('text="Delete"')).to.be.false;
            expect(await page.isVisible('text="Edit"')).to.be.false;
        });

        it('author sees delete and edit buttons [ 2.5 Points ]', async () => {
            await page.click('nav >> text=Catalogue');
            await page.waitForTimeout(interval);

            await page.waitForSelector('#catalog-page');
            await page.click(`.article-preview:has-text("${mockData.catalog[0].title}")`);
            await page.waitForTimeout(interval);

            expect(await page.isVisible('text="Delete"')).to.be.true;
            expect(await page.isVisible('text="Edit"')).to.be.true;
        });

        it('edit should populate form with correct data [ 5 Points ]', async () => {
            const data = mockData.catalog[0];
            await createHandler(endpoints.details(data._id), { get: data });

            await page.click('nav >> text=Catalogue');
            await page.waitForTimeout(interval);

            await page.waitForSelector('#catalog-page');
            await page.click(`.article-preview:has-text("${data.title}")`);
            await page.waitForTimeout(interval);

            await page.click('text=Edit');
            await page.waitForTimeout(interval);

            await page.waitForSelector('form');

            const formData = {
                title: await page.$eval('[name="title"]', t => t.value),
                category: await page.$eval('[name="category"]', t => t.value),
                content: await page.$eval('[name="content"]', t => t.value)
            };
            expect(formData.title).to.equal(data.title);
            expect(formData.category).to.equal(data.category);
            expect(formData.content).to.equal(data.content);
        });

        it('edit does NOT work with empty fields [ 5 Points ]', async () => {
            const data = mockData.catalog[0];
            const { put } = await createHandler(endpoints.details(data._id), { get: data, put: '' });

            await page.click('nav >> text=Catalogue');
            await page.waitForTimeout(interval);

            await page.waitForSelector('#catalog-page');
            await page.click(`.article-preview:has-text("${data.title}")`);
            await page.waitForTimeout(interval);

            await page.click('text=Edit');
            await page.waitForTimeout(interval);

            await page.waitForSelector('form');
            await page.fill('[name="title"]', '');
            await page.fill('[name="category"]', '');
            await page.fill('[name="content"]', '');

            await page.click('[type="submit"]');
            await page.waitForTimeout(interval);

            expect(put.isCalled).to.be.false;
        });

        it('edit makes correct API call for logged in user [ 5 Points ]', async () => {
            const data = mockData.catalog[0];
            const { put } = await createHandler(endpoints.details(data._id), { get: data, put: '' });

            await page.click('nav >> text=Catalogue');
            await page.waitForTimeout(interval);

            await page.waitForSelector('#catalog-page');
            await page.click(`.article-preview:has-text("${data.title}")`);
            await page.waitForTimeout(interval);

            await page.click('text=Edit');
            await page.waitForTimeout(interval);

            await page.waitForSelector('form');

            await page.fill('[name="title"]', data.title + 'edit');
            await page.fill('[name="content"]', data.content + 'edit');

            const [request] = await Promise.all([
                put.waitForRequest(),
                page.click('[type="submit"]')
            ]);

            const postData = JSON.parse(request.postData());

            expect(postData.title).to.contains(data.title + 'edit');
            expect(postData.category).to.contains(data.category);
            expect(postData.content).to.contains(data.content + 'edit');
        });

        it('delete makes correct API call for logged in user [ 5 Points ]', async () => {
            const data = mockData.catalog[0];
            const { delete: del } = await createHandler(endpoints.details(data._id), { get: data, delete: '' });

            await page.click('nav >> text=Catalogue');
            await page.waitForTimeout(interval);

            await page.waitForSelector('#catalog-page');
            await page.click(`.article-preview:has-text("${data.title}")`);
            await page.waitForTimeout(interval);

            page.on('dialog', dialog => dialog.accept());

            await Promise.all([
                del.waitForResponse(),
                page.click('text="Delete"')
            ]);

            expect(del.isCalled).to.be.true;
        });
    });

    describe('Home Page [ 15 Points ]', async () => {
        it('all categories filled [ 5 Points ]', async () => {
            const arts = mockData.catalog;
            await page.goto(host);
            await page.waitForTimeout(interval);

            expect(await page.textContent('section.recent:has-text("JavaScript")')).to.contains(arts[0].title);
            expect(await page.textContent('section.recent:has-text("C#")')).to.contains(arts[1].title);
            expect(await page.textContent('section.recent:has-text("Java"):not(:has-text("JavaScript"))')).to.contains(arts[2].title);
            expect(await page.textContent('section.recent:has-text("Python")')).to.contains(arts[3].title);

            expect(await page.isVisible('text=No articles yet')).to.be.false;
        });

        it('all categories empty [ 5 Points ]', async () => {
            await createHandler(endpoints.home, { get: [] });

            await page.goto(host);
            await page.waitForTimeout(interval);

            expect(await page.textContent('section.recent:has-text("JavaScript")')).to.contains('No articles yet');
            expect(await page.textContent('section.recent:has-text("C#")')).to.contains('No articles yet');
            expect(await page.textContent('section.recent:has-text("Java"):not(:has-text("JavaScript"))')).to.contains('No articles yet');
            expect(await page.textContent('section.recent:has-text("Python")')).to.contains('No articles yet');
        });

        it('mixed content [ 5 Points ]', async () => {
            const arts = mockData.catalog.slice(0, 2);
            await createHandler(endpoints.home, { get: arts });

            await page.goto(host);
            await page.waitForTimeout(interval);

            expect(await page.textContent('section.recent:has-text("JavaScript")')).to.contains(arts[0].title);
            expect(await page.textContent('section.recent:has-text("C#")')).to.contains(arts[1].title);
            expect(await page.textContent('section.recent:has-text("Java"):not(:has-text("JavaScript"))')).to.contains('No articles yet');
            expect(await page.textContent('section.recent:has-text("Python")')).to.contains('No articles yet');
        });
    });

    describe('Search Page [ 5 Points ]', async () => {

        it('show no matches [ 2.5 Points ]', async () => {
            await createHandler(endpoints.search('arrays'), { get: [] });

            await page.goto(host);
            await page.waitForTimeout(interval);

            await page.click('nav >> text=Search');
            await page.waitForTimeout(interval);

            await page.fill('[name="search"]', 'arrays');
            await page.click('[type="submit"]');
            await page.waitForTimeout(interval);

            expect(await page.isVisible('text=No matching articles')).to.be.true;
        });

        it('show results [ 2.5 Points ]', async () => {
            await createHandler(endpoints.search('arrays'), { get: mockData.catalog.slice(0, 2) });

            await page.goto(host);
            await page.waitForTimeout(interval);

            await page.click('nav >> text=Search');
            await page.waitForTimeout(interval);

            await page.fill('[name="search"]', 'arrays');
            await page.click('[type="submit"]');
            await page.waitForTimeout(interval);

            const matches = await page.$$eval('.article-preview h3', t => t.map(s => s.textContent));

            expect(matches.length).to.equal(2);
            expect(matches[0]).to.contains(mockData.catalog[0].title);
            expect(matches[1]).to.contains(mockData.catalog[1].title);
        });

    });
});

async function setupContext(context) {
    // Authentication
    await createHandler(endpoints.login, { post: mockData.users[0] }, context);
    await createHandler(endpoints.register, { post: mockData.users[0] }, context);
    await createHandler(endpoints.logout, { get: { data: '', options: { json: false, status: 204 } } }, context);

    // Catalog and Details
    await createHandler(endpoints.home, { get: mockData.catalog.slice(0, 4) }, context);
    await createHandler(endpoints.catalog, { get: mockData.catalog }, context);
    await createHandler(endpoints.details('1001'), { get: mockData.catalog[0] }, context);
    await createHandler(endpoints.details('1002'), { get: mockData.catalog[1] }, context);
    await createHandler(endpoints.details('1003'), { get: mockData.catalog[2] }, context);
    await createHandler(endpoints.details('1004'), { get: mockData.catalog[3] }, context);
    await createHandler(endpoints.details('1005'), { get: mockData.catalog[4] }, context);

    // Block external calls
    await context.route(url => url.href.slice(0, host.length) != host, route => {
        if (DEBUG) {
            console.log('Preventing external call to ' + route.request().url());
        }
        route.abort();
    });
}

/**
 * @typedef {Object} MethodHandler
 * @property {() => Promise<Request>} waitForRequest
 * @property {() => Promise<Response>} waitForResponse
 * @property {boolean} isCalled
 */

/**
 * @typedef {Object} RequestHandler
 * @property {MethodHandler} get
 * @property {MethodHandler} post
 * @property {MethodHandler} put
 * @property {MethodHandler} patch
 * @property {MethodHandler} delete
 */

/**
 * @typedef {Object} MockResponse
 * @property {*?} data Data to include in the response body
 * @property {{json: boolean, status: number}?} options Response options
 */

/**
 * @typedef ResponseDescriptor
 * @property {?MockResponse|Object} get
 * @property {?MockResponse|Object} post
 * @property {?MockResponse|Object} put
 * @property {?MockResponse|Object} patch
 * @property {?MockResponse|Object} delete
 */

/**
 * Mock server serponse at specified path and methods
 * @param {string} match Path to resource. Partial match will be performed
 * @param {ResponseDescriptor?} handlers Optional. Methods to handle and response to return
 * @param {Object?} context Optional. Context to which the handler will be attached
 * @returns {Promise<RequestHandler>}
 */
async function createHandler(match, handlers = {}, context) {
    const methodHandlers = {};
    const result = {};
    ['get', 'post', 'put', 'patch', 'delete'].forEach(method => Object.defineProperty(result, method, {
        get: () => undefined,
        set: (value) => createMethodHandler(method, ...parseOptions(value)),
        configurable: true
    }));

    context = context || page;
    Object.entries(handlers).forEach(([k, v]) => result[k] = v);

    await context.route(urlPredicate, (route, request) => {
        if (DEBUG) {
            console.log('>>>', request.method(), request.url());
        }

        const handler = methodHandlers[request.method().toLowerCase()];
        if (handler == undefined) {
            route.continue();
        } else {
            handler(route, request);
        }
    });


    return result;

    function createMethodHandler(method, returns, options) {
        let called = false;

        method = method.toLowerCase();
        methodHandlers[method] = (route, request) => {
            called = true;
            route.fulfill(respond(returns, options));
        };

        const props = {
            waitForRequest: () => context.waitForRequest(urlPredicate),
            waitForResponse: () => context.waitForResponse(urlPredicate)
        };
        Object.defineProperty(props, 'isCalled', { get: () => called });
        Object.defineProperty(result, method, { get: () => props });
    }

    function parseOptions(value) {
        if (value.hasOwnProperty('data') && value.hasOwnProperty('options')) {
            return [value.data, value.options];
        } else {
            return [value];
        }
    }

    function urlPredicate(current) {
        const url = (current instanceof URL ? current.href : current.url()).toLowerCase();
        return url.slice(-match.length) == match.toLowerCase();
    }
}

function respond(data, options = {}) {
    options = Object.assign({
        json: true,
        status: 200
    }, options);

    const headers = {
        'Access-Control-Allow-Origin': '*'
    };
    if (options.json) {
        headers['Content-Type'] = 'application/json';
        data = JSON.stringify(data);
    }

    return {
        status: options.status,
        headers,
        body: data
    };
}

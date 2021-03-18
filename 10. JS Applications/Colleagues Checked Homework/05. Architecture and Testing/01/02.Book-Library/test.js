const { chromium } = require('playwright-chromium');
const { expect } = require('chai');

const host = 'http://localhost:3000/02.Book-Library'; // Application host (NOT service host - that can be anything)
const DEBUG = false;

const mockData = require('./mock-data.json');

function json(data) {
    return {
        status: 200,
        headers: {
            'Access-Control-Allow-Origin': '*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    };
}

let browser;
let context;
let page;

describe('E2E tests', function () {
    if (DEBUG) {
        this.timeout(120000);
    } else {
        this.timeout(6000);
    }

    before(async () => {
        if (DEBUG) {
            browser = await chromium.launch({ headless: false, slowMo: 500 });
        } else {
            browser = await chromium.launch();
        }
    });

    after(async () => {
        await browser.close();
    });

    beforeEach(async () => {
        context = await browser.newContext();

        // Block external calls
        /*
        await context.route(url => url.href.slice(0, host.length) != host, route => {
            if (DEBUG) {
                console.log('aborting', route.request().url());
            }
            route.abort();
        });
        */

        page = await context.newPage();
    });

    afterEach(async () => {
        await page.close();
        await context.close();
    });

    describe('tests library', () => {
        it('load books', async () => {
            await page.route('**/jsonstore/collections/books*', (request) => request.fulfill(json(mockData)));
            await page.goto(host);

            await page.click('#loadBooks');

            await page.waitForSelector('td');

            const rows = await page.$$eval('tr', x => x.map(r => r.textContent));
            expect(rows[1]).to.includes('J.K.Rowling');
            expect(rows[1]).to.includes("Harry Potter and the Philosopher's Stone");
            expect(rows[2]).to.includes("Svetlin Nakov");
            expect(rows[2]).to.includes("C# Fundamentals");

            const rowsHTML = await page.$$eval('tr', x => x.map(r => r.innerHTML));
            expect(rowsHTML[1]).to.includes('<button class="editBtn">Edit</button>');
            expect(rowsHTML[1]).to.includes('<button class="deleteBtn">Delete</button>');
            expect(rowsHTML[2]).to.includes('<button class="editBtn">Edit</button>');
            expect(rowsHTML[2]).to.includes('<button class="deleteBtn">Delete</button>');
        });

        it('add new book should work correct', async () => {
            const author = 'Aleko Konstantinov';
            const title = 'Bay Ganyo';
            await page.route('**/jsonstore/collections/books*', (request) => request.fulfill(json({'123':{author, title}})));
            await page.goto(host);

            await page.fill('#createForm > input[name="title"]', title);
            await page.fill('#createForm > input[name="author"]', author);

            const [request] = await Promise.all([
                page.waitForRequest(request => request.url().includes('/jsonstore/collections/books') && request.method() === 'POST'),
                page.click('#createForm > button')
            ])

            const isVisible = await page.isVisible('#createForm');
            expect(isVisible).to.be.true;

            const isVisibleCreate = await page.isVisible('#editForm');
            expect(isVisibleCreate).to.be.false;
            
            const result = JSON.parse(request.postData());
            expect(result.title).to.equal(title);
            expect(result.author).to.equal(author);

            await page.click('#loadBooks');

            await page.waitForSelector('td');

            const rows = await page.$$eval('tr', x => x.map(r => r.textContent));
            expect(rows[1]).to.includes(title);
            expect(rows[1]).to.includes(author);
            
        });

        it('add new book should not work with empty fields', async () => {
            const author = 'Aleko Konstantinov';
            const title = 'Bay Ganyo';
            await page.route('**/jsonstore/collections/books*', (request) => request.fulfill(json({'123':{author, title}})));
            await page.goto(host);

            
            const [request] = await Promise.all([
                page.click('#createForm > button'),
                page.on('dialog', async dialog => {
                    console.log(dialog.message());
                    await dialog.accept();
                    
                  })
            ])

            await page.click('#loadBooks');

            await page.waitForSelector('td');

            const rows = await page.$$eval('tr', x => x.map(r => r.textContent));
            expect(rows.length).to.equals(2);
            
        });

        it('edit should work correct', async () => {

            const author = 'Aleko Konstantinov';
            const title = 'Bay Ganyo';
            await page.route('**/jsonstore/collections/books*', (request) => request.fulfill(json({'123':{author, title}})));
            await page.goto(host);

            await page.click('#loadBooks');
            
            await page.waitForSelector('td');
            
            await page.route('**/jsonstore/collections/books/123*', (request) => request.fulfill(json({author, title})));
            await page.click('td > .editBtn');

            const isVisible = await page.isVisible('#createForm');
            expect(isVisible).to.be.false;

            const isVisibleCreate = await page.isVisible('#editForm');
            expect(isVisibleCreate).to.be.true;

            const titleOld = await page.$eval('#editForm >> [name="title"]', x => x.value);
            expect(titleOld).to.equal(title)
            const authorOld = await page.$eval('#editForm >> [name="author"]', x => x.value);
            expect(authorOld).to.equal(author);
            

            await page.fill('#editForm >> [name="author"]', 'ivan');
            await page.fill('#editForm >> [name="title"]', 'bay ganyo');
            const [request] = await Promise.all([
                page.waitForRequest(request => request.url().includes('/jsonstore/collections/books') && request.method() === 'PUT'),
                page.click('text=Save')
            ])

            const result = JSON.parse(request.postData());
            expect(result.title).to.equal('bay ganyo');
            expect(result.author).to.equal('ivan');

            expect(request.method()).to.equal('PUT');
        });

        it('delete should work correct', async () => {
            const author = 'Aleko Konstantinov';
            const title = 'Bay Ganyo';
            await page.route('**/jsonstore/collections/books*', (request) => request.fulfill(json({'123':{author, title}})));
            await page.goto(host);
            await page.click('#loadBooks');
            await page.waitForSelector('td');

            await page.route('**/jsonstore/collections/books/123*', (request) => request.fulfill(json()));
            const [request] = await Promise.all([
                page.waitForRequest(request => request.url().includes('/jsonstore/collections/books') && request.method() === 'DELETE'),
                page.click('td > .deleteBtn'),
                page.on('dialog', async dialog => {
                    console.log(dialog.message());
                    await dialog.accept();
                    
                  })
            ])

            expect(request.method()).to.equal('DELETE');
            
        });
    })
})
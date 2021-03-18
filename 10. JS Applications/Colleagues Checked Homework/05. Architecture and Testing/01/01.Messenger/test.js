const { chromium } = require('playwright-chromium');
const { expect } = require('chai');

const host = 'http://localhost:3000/01.Messenger'; // Application host (NOT service host - that can be anything)
const DEBUG = true;

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

    describe('messenger', () => {
        it('load messages in the text area', async () => {
            await page.route('**/jsonstore/messenger*', (request) => request.fulfill(json(mockData)));
            await page.goto(host);

            await page.click('#refresh');

            const content = await page.$eval('#messages', el => el.value);
            expect(content).to.contain('Spami: Hello, are you there?')

        });

        it('send message work correct', async () => {
            const name = 'ivan';
            const content = 'Hello world!'
           

            await page.route('**/jsonstore/messenger*', (request) => request.fulfill(json({'123': {'author': name, content}})));
            await page.goto(host);

            await page.fill('#author', name);
            await page.fill('#content', content);

            const [request] = await Promise.all([
                page.waitForRequest(request => request.url().includes('/jsonstore/messenger') && request.method() === 'POST'),
                page.click('#submit')
                
            ])
            
            const result = JSON.parse(request.postData());
            expect(result.author).to.equal(name);
            expect(result.content).to.equal(content);

            await page.click('#refresh');

            const contentResult = await page.$eval('#messages', el => el.value);
            expect(contentResult).to.equal(`${name}: ${content}`)
        })
    })
});
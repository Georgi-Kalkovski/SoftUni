const { chromium } = require('playwright-chromium');
const { expect } = require('chai');

let browser, page; // Declare reusable variables

describe('E2E tests', function () {
    this.timeout(6000);

    //before(async () => { browser = await chromium.launch({ headless: false, slowMo: 500 }); });
    before(async () => { browser = await chromium.launch(); });
    after(async () => { await browser.close(); });
    beforeEach(async () => { page = await browser.newPage(); });
    afterEach(async () => { await page.close(); });

    it('load index', async () => {
        await page.goto('http://localhost:3000');

        const content = await page.content();
        expect(content).to.contains('FORM');
        expect(content).to.contains('TITLE');
        expect(content).to.contains('AUTHOR');
        expect(content).to.contains('Action');
    });

    it('load books', async () => {
        await page.goto('http://localhost:3000');

        await page.click('#loadBooks');
        expect('tbody').to.not.be.empty;
    });
    
    it('add book', async () => {
        await page.goto('http://localhost:3000');

        await page.fill('#createForm input[name=title]', 'Test title');
        await page.fill('#createForm input[name=author]', 'Test Author');
        await page.click('#submitBtn');
    });

    it('edit book', async () => {
        await page.goto('http://localhost:3000');

        await page.click('#loadBooks');
        await page.click('.editBtn');
        await page.fill('#editForm input[name=title]', 'Testing the Edit Title');
        await page.fill('#editForm input[name=author]', 'Testing the Edit Author');
        await page.click('#saveBtn');
    });

    it('delete book', async () => {
        await page.goto('http://localhost:3000');

        await page.click('#loadBooks');
        await page.click('.deleteBtn');
    });
});

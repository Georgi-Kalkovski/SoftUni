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

    it("load messages", async () => {
        await page.goto('http://localhost:3000');

        await page.fill("#author", 'Test');
        await page.fill("#content", 'Hello from Test');
        await page.click("#submit");
    });

    it('send message', async () => {
        await page.goto('http://localhost:3000');

        await page.click('#refresh');
    });
});

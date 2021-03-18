const { chromium } = require("playwright-chromium");

const { expect } = require("chai");

let browser, page; // Declare reusable variables

describe("E2E tests", function () {
    this.timeout(10000);
    before(async () => {
        browser = await chromium.launch({ headless: false, slowMo: 500 });
    });

    after(async () => {
        await browser.close();
    });

    beforeEach(async () => {
        page = await browser.newPage();
    });

    afterEach(async () => {
        await page.close();
    });

    it("load stati page", async () => {
        await page.goto("http://localhost:3000");
        //await page.screenshot({ path: "index.png" });

        const content = await page.content();
        expect(content).to.contains("Send");
        expect(content).to.contains("Refresh");
    });

    it("click refresh", async () => {
        await page.goto("http://localhost:3000");
        await page.click("text=Refresh");

        const content = await page.$eval("#messages", (el) => el.value);
        expect(content).to.contains('Spami: Hello, are you there?\nGarry: Yep, whats up :?\nSpami: How are you? Long time no see? :)\nGeorge: Hello, guys! :))\nSpami: Hello, George nice to see you! :)))');
    });

    it('click send', async () =>{
        await page.goto("http://localhost:3000");
        await page.fill('#author', 'Peter');
        await page.fill('#content', 'Hello');
        await page.click("text=Send");
        await page.click("text=Refresh");
        const content = await page.$eval("#messages", (el) => el.value);
        expect(content).to.contains('Spami: Hello, are you there?\nGarry: Yep, whats up :?\nSpami: How are you? Long time no see? :)\nGeorge: Hello, guys! :))\nSpami: Hello, George nice to see you! :)))\nPeter: Hello');

    });
});
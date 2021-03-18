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

    it("load static page", async () => {
        await page.goto("http://localhost:3000");

        const content = await page.content();
        expect(content).to.contains("LOAD ALL BOOKS");
        expect(content).to.contains("Submit");
    });
    it("load books", async () => {
        await page.goto("http://localhost:3000");

        await page.click("text=LOAD ALL BOOKS");
        await page.waitForSelector("tr");

        const visible = await page.isVisible("tbody tr");

        expect(visible).to.be.true;
    });

    it("Check is books loaded", async () => {
        await page.goto("http://localhost:3000");

        await page.click("text=LOAD ALL BOOKS");

        const content = await page.content();

        expect(content).to.contains(`Harry Potter and the Philosopher's Stone`);
        expect(content).to.contains(`C# Fundamentals`);
        expect(content).to.contains(`J.K.Rowling`);
        expect(content).to.contains(`Svetlin Nakov`);
        expect(content).to.contains(`Edit`);
        expect(content).to.contains(`Delete`);
    });

    it("test in tr", async () => {
        await page.goto("http://localhost:3000");

        await page.click("text=LOAD ALL BOOKS");

        const content = await page.$$eval("#tableWithBooks tr", (tr) =>
            tr.map((s) => s.textContent)
        );

        const book1 = content[0];
        const book2 = content[1];
        expect(book1).to.equal(
            `\n            Harry Potter and the Philosopher\'s Stone\n            J.K.Rowling\n            \n                Edit\n                Delete\n            \n        `
        );
        expect(book2).to.equal(
            `\n            C# Fundamentals\n            Svetlin Nakov\n            \n                Edit\n                Delete\n            \n        `
        );
    });

    it("test in tr", async () => {
        await page.goto("http://localhost:3000");

        await page.click("text=LOAD ALL BOOKS");

        const content = await page.$$eval("#tableWithBooks tr", (tr) =>
            tr.map((s) => s.textContent)
        );

        const newBook = content[2];

        expect(newBook).to.equal(
            `\n            Harry Potter and the Philosopher\'s Stone\n            J.K.Rowling\n            \n                Edit\n                Delete\n            \n        `
        );
    });

    it("test submit data", async () => {
        await page.goto("http://localhost:3000");

        await page.fill("#createTitle", "Hunger Games");
        await page.fill("#createAuthor", "Suzanne Collins");
        await page.click("text=Submit");
        await page.click("text=LOAD ALL BOOKS");

        const content = await page.$$eval("#tableWithBooks tr", (tr) =>
            tr.map((s) => s.textContent)
        );

        const newBook = content[2];

        expect(newBook).to.equal(
            "\n            Hunger Games\n            Suzanne Collins\n            \n                Edit\n                Delete\n            \n        "
        );
    });
    it.only("test edit data", async () => {
        await page.goto("http://localhost:3000");
        await page.click("#loadBooks");
        await page.click(".editBtn");
        await page.fill("#editTitle", "Harry Pot");
        await page.fill(`#editAut`, `R.R.R`);
        await page.click("#Save");
        await page.click("text=Submit");

        await page.click(`text=LOAD ALL BOOKS`);

        const content = await page.$$eval("#tableWithBooks tr", (tr) =>
            tr.map((s) => s.textContent)
        );

        const newBook = content[0];

        expect(newBook).to.equal(
            "\n            Harry Pot\'s\n            R.R.R\n            \n                Edit\n                Delete\n            \n        "
        );
    });
});
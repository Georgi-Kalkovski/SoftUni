function solve() {
    const inputTextArea = document.querySelector("#exercise > textarea:nth-child(2)")
    const generateBtn = document.querySelector("#exercise > button:nth-child(3)").addEventListener('click', onGenerateClick);
    const infoSection = document.querySelector("#exercise > div > div > div > div > table > tbody");
    const infoOutput = document.querySelector("#exercise > textarea:nth-child(5)")
    const buyBtn = document.querySelector("#exercise > textarea:nth-child(5)")

    function onGenerateClick() {
        const item = {};
        item = JSON.parse(inputTextArea.value);

        infoSection.append(item);
    }
}
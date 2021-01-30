function extractText() {
    let node = document.querySelectorAll("ul#items li");
    let result = document.querySelector("#result");
    for (let li of node) {
        result.value += li.textContent + "\n";
    }
}
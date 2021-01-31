function addItem() {
    let text = document.querySelector("#newItemText").value;
    let list = document.querySelector("#items");
    let item = document.createElement('a', '[Delete]');
    item.href = '#';
    list.appendChild(item).textContent = text;
}
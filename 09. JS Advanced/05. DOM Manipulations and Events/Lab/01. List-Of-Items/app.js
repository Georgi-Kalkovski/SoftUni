function addItem() {
    const list = document.querySelector("#items");

    const newLi = document.createElement('li');

    let text = document.querySelector("#newItemText").value;
    
    list.appendChild(newLi).textContent = text;
}
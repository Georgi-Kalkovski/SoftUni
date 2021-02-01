function addItem() {


    const text = document.querySelector("#newText");

    const li = createElement('li', text.value);

    const a = createElement('a', '[Delete]');
    a.href = "#";
    a.addEventListener('click', (event) => {
        event.target.parentNode.remove();
        //li.remove();
    });

    li.appendChild(a); 

    document.querySelector("#items").appendChild(li);
    
    function createElement(type, content) {
        const element = document.createElement(type);
        element.textContent = content;
        
        return element;
    }
}
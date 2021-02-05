function solve() {
    let buttons = [...document.getElementsByTagName("button")];
  
    buttons[0].addEventListener('click', generate);
  
    buttons[1].addEventListener('click', buy);
  
    let textAreas = [...document.getElementsByTagName("textarea")];
    let table = document.querySelector('table > tbody');
  
    function generate() {
      let inputFurniture = JSON.parse(textAreas[0].value);
  
      for (const furniture of inputFurniture) {
        let trElement = createElement('tr');
  
        //Image
        let tdImg = createElement('td');
        let img = createElement('img');
        img.src = furniture.img;
        tdImg.appendChild(img);
  
        //Name
        let tdName = createElement('td');
        let name = createElement('p', furniture.name);
        tdName.appendChild(name);
  
        //Price
        let tdPrice = createElement('td');
        let price = createElement('p', furniture.price);
        tdPrice.appendChild(price);
  
        //Decoration factor
        let tdDecorationFactor = createElement('td');
        let decorationFactor = createElement('p', furniture.decFactor);
        tdDecorationFactor.appendChild(decorationFactor);
  
        let tdCheckbox = createElement('td');
        let checkbox = createElement('input');
        checkbox.type = 'checkbox';
        tdCheckbox.appendChild(checkbox);
  
        trElement.appendChild(tdImg);
        trElement.appendChild(tdName);
        trElement.appendChild(tdPrice);
        trElement.appendChild(tdDecorationFactor);
        trElement.appendChild(tdCheckbox);
        table.appendChild(trElement);
      }
    }
  
    function buy() {
      let tableRows = [...document.querySelectorAll('table > tbody > tr')];
  
      let boughtProducts = [];
      let totalSum = 0;
      let totalFactor = 0;
  
      for (const row of tableRows) {
  
        if (row.children[4].children[0].checked) {
          let name = row.children[1].children[0].textContent;
          let price = Number(row.children[2].children[0].textContent);
          let decFactor = Number(row.children[3].children[0].textContent);
  
          boughtProducts.push(name);
          totalSum += price;
          totalFactor += decFactor;
        }
      }
  
      textAreas[1].value +=
        `Bought furniture: ${boughtProducts.join(", ")}` +
        "\n" +
        `Total price: ${totalSum.toFixed(2)}` +
        "\n" +
        `Average decoration factor: ${totalFactor / boughtProducts.length}`;
    }
  
    function createElement(type, content) {
      const element = document.createElement(type);
      element.textContent = content;
      return element;
    }
  }
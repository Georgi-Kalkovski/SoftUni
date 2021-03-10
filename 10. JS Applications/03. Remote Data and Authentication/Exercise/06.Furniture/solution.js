async function getAll() {
  try {
    const response = await fetch('http://localhost:3030/data/furniture');

    if (response.ok == false) {
      const error = await response.json();
      throw new Error(error.message);
    }

    const data = await response.json();
    return data;
  } catch (error) {
    alert(error.message);
  }
}

function create(type, content, attributes, appendElements) {
  const el = document.createElement(type);

  if (content) {
    el.textContent = content;
  }

  if (attributes) {
    Object.entries(attributes).forEach(([key, value]) => el.setAttribute(key, value));
  }

  if (appendElements) {
    appendElements.forEach(element => {
      el.appendChild(element);
    });
  }

  return el;
}

async function renderTabel() {
  const data = await getAll();
  const tbody = document.querySelector('tbody');
  tbody.innerHTML = '';

  data.forEach(el => {
    console.log(el);
    const img = create('img', undefined, { src: el.img });
    const imgTd = create('td', undefined, undefined, [img]);

    const nameP = create('p', el.name);
    const nameTd = create('td', undefined, undefined, [nameP]);

    const priceP = create('p', el.price);
    const priceTd = create('td', undefined, undefined, [priceP]);

    const factorP = create('p', el.factor);
    const factorTd = create('td', undefined, undefined, [factorP]);

    const input = create('input', undefined, { type: 'checkbox', disabled: true });
    const inputTd = create('td', undefined, undefined, [input]);

    const tr = create('tr', undefined, undefined, [imgTd, nameTd, priceTd, factorTd, inputTd]);
    tbody.appendChild(tr);
  });
}

renderTabel();
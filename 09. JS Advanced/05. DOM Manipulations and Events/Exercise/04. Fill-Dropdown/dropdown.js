function addItem() {

    const newItemText = document.getElementById('newItemText');
    const newItemValue = document.getElementById('newItemValue');

        const newOption = document.createElement('OPTION');
        newOption.textContent = newItemText.value;
        newOption.value = newItemValue.value;
        const selectItem = document.getElementById('menu');
        selectItem.appendChild(newOption);
        newItemText.value = '';
        newItemValue.value = '';
}
function solve() {

    function convertToBinary(num) {
        let bin = 0;
        let rem, i = 1;
        while (num != 0) {
            rem = num % 2;
            num = parseInt(num / 2);
            bin = bin + rem * i;
            i = i * 10;
        }
        return bin;
    }

    var binOpt = document.createElement('option');
    binOpt.appendChild(document.createTextNode('Binary'));
    binOpt.value = 'binary';

    var hexOpt = document.createElement('option');
    hexOpt.appendChild(document.createTextNode('Hexadecimal'));
    hexOpt.value = 'hexadecimal';
    
    let menuTo = document.querySelector("#selectMenuTo");
    menuTo.appendChild(binOpt);
    menuTo.appendChild(hexOpt);

    document.getElementsByTagName('button')[0].addEventListener('click', onClick);

    function onClick() {
        let number = Number(document.getElementById('input').value);

        if(menuTo.options[menuTo.selectedIndex].text == 'Binary'){
            document.getElementById('result').value = convertToBinary(number);
        }

        if(menuTo.options[menuTo.selectedIndex].text == 'Hexadecimal'){
            let hexString = number.toString(16).toUpperCase();
            document.getElementById('result').value = hexString;
        }
    }
}
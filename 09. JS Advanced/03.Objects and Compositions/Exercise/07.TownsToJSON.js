function TownsToJSON(input) {

    let arr = [];

    for (let i = 1; i < input.length; i++) {
        let customInput = input[i].split('|');
        customInput.shift();
        customInput.pop();
        let innerArr = {};
        innerArr.Town = customInput[0].trim();
        innerArr.Latitude = Math.round(Number(customInput[1].trim())* 100) / 100;
        innerArr.Longitude = Math.round(Number(customInput[2].trim())* 100) / 100;
        arr.push(innerArr);
    }

let result = JSON.stringify(arr);

    return result;
}

console.log(TownsToJSON(
    ['| Town | Latitude | Longitude |',
        '| Sofia | 42.696552 | 23.32601 |',
        '| Beijing | 39.913818 | 116.363625 |']
));
console.log(TownsToJSON(
    ['| Town | Latitude | Longitude |',
        '| Veliko Turnovo | 43.0757 | 25.6172 |',
        '| Monatevideo | 34.50 | 56.11 |']
));
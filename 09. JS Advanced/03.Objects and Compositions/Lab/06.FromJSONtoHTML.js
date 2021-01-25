function fromJSONToHTMLTable(input) {

    input = JSON.parse(input);

    function escapeHtml(value) {
        let result = '';
        if(typeof value === 'number') {
            return value;
        }
        for(let i = 0; i < value.length; i++) {
            switch(value[i]) {
                case '&': result += '&amp;'; break;
                case '<': result += '&lt;'; break;
                case '>': result += '&gt;'; break;
                case '"': result += '&quot;'; break;
                case '\'': result += '&#39;'; break;
                default: result += value[i]; break;
            }
        }
        return result;
    }

    let keys = (input) => {
        let keys = Object.keys(input[0]);
        let checkedKey = '';
        for (let key of keys) {
            checkedKey += '<th>' + escapeHtml(key) + '</th>';
        }
        console.log(`<tr>${checkedKey}</tr>`);
    }

    let values = (input) => {
        for (let i = 0; i < Object.values(input).length; i++) {
            let values = Object.values(input[i]);
            let checkedValue = '';
            for (let value of values) {
                checkedValue += '<td>' + escapeHtml(String(value)) + '</td>';
            }
            console.log(`<tr>${checkedValue}</tr>`);
        }
    }

    console.log('<table>');
    keys(input);
    values(input);
    console.log('</table>');
}

fromJSONToHTMLTable('[{"Name":"Stamat","Score":5.5},{"Name":"Rumen","Score":6}]');
fromJSONToHTMLTable('[{"Name":"Pesho","Score":4," Grade":8},{"Name":"Gosho","Score":5," Grade":8},{"Name":"Angel","Score":5.50," Grade":10}]');
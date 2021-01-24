function fromJSONToHTMLTable(input) {

    input = JSON.parse(input);

    let regex = /(<([^>]+)>)/gi;

    let keys = (input) => {
        let keys = Object.keys(input[0]);
        console.log(`<tr><th>${keys.join('</th><th>')}</th></tr>`);
    }

    let values = (input) => {
        for (let i = 0; i < Object.values(input).length; i++) {
            let value = Object.values(input[i]);
            console.log(`<tr><td>${value.join('</td><td>')}</td></tr>`);
        }
    }

    console.log('<table>');
    keys(input);
    values(input);
    console.log('</table>');
}

fromJSONToHTMLTable('[{"Name":"Stamat","Score":5.5},{"Name":"Rumen","Score":6}]');
fromJSONToHTMLTable('[{"Name":"Pesho","Score":4," Grade":8},{"Name":"Gosho","Score":5," Grade":8},{"Name":"Angel","Score":5.50," Grade":10}]');

// 100/100 ANSWER

/* function solve(arr) {
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
 
    arr = JSON.parse(arr);
    let table = '<table>';
 
    const keys = Object.keys(arr[0]);
    table += '\n\t<tr>';
    keys.forEach(key => {
        table += `<th>${escapeHtml(key)}</th>`;
    });
    table += '</tr>';
 
    arr.forEach(person => {
        const values = Object.values(person);
        table += '\n\t<tr>';
        values.forEach(value => {
            table += `<td>${escapeHtml(value)}</td>`;
        });
        table += '</tr>';
    });
 
    table += '\n</table>';
    return table;
} */
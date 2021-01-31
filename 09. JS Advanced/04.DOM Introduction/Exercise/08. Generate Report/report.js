function generateReport() {
    const cols = [];
    const result = [];
    const headers = Array.from(document.getElementsByTagName('thead')[0].children[0].children);
    const rows = Array.from(document.getElementsByTagName('tbody')[0].children);

    headers.forEach((header, index) => {
        if (header.children[0].checked) {
            cols.push(index);
        }
    });

    for (const row of rows) {
        let employee = {};
        for (const col of cols) {
            let current = row.children[col].textContent;
            employee[headers[col].children[0].getAttribute('name')] = current;
        }
        result.push(employee);
    }

    document.getElementById('output').value = JSON.stringify(result, undefined, 4);
}
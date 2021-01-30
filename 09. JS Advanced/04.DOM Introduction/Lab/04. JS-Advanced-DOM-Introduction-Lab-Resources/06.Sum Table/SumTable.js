function sumTable() {
    let node = document.querySelectorAll("table tr");
    let sum = 0;
    for (let i = 1; i < node.length - 1; i++) {
        let cols = node[i].children;
        sum += Number(cols[cols.length - 1].textContent);
    }
    document.getElementById("sum").textContent = sum;
}
  
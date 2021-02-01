function deleteByEmail() {

    const input = document.querySelector("input[name=email]").value;
    const list = document.querySelector("tbody").children;
    const resultMessage = document.getElementById("result");

    for (let i = 0; i < list.length; i++) {
        const email = list[i].children[1].textContent;
        if (input == email) {
            list[i].remove();
            resultMessage.textContent = 'Deleted.';
        } else {
            resultMessage.textContent = 'Not found.';
        }
    }
}

    //for (const tableData of list) {
    //    const email = tableData.children[1].textContent;
    //    if (input == email) {
    //        tableData.remove();
    //        resultMessage.textContent = 'Deleted.';
    //    } else {
    //        resultMessage.textContent = 'Not found.';
    //    }
    //}
function AddRemoveElements(arr) {
    let myArr = [];
    let number = 1;

    for (let i = 0; i < arr.length; i++) {

        if (arr[i] == 'add') {
            myArr.push(number);
        }
        else {
            myArr.pop();
            //myArr.splice(-1, 1);
        }
        number += 1;
    }
    
    return myArr.length != 0 ? result.join('\n') : 'Empty';
    //if (myArr.length == 0) {
    //    return 'Empty';
    //}
    //else {
    //    return myArr.join('\n');
    //}
}

console.log(AddRemoveElements(['add', 'add', 'add', 'add']));
console.log(AddRemoveElements(['add', 'add', 'remove', 'add', 'add']));
console.log(AddRemoveElements(['remove', 'remove', 'remove']));
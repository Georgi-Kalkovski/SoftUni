function createSortedList() {

    let arr = [];
    function add(element) {
        arr.push(element);
        this.size++;
        arr.sort((a, b) => a - b);
    }
    function remove(index) {
        if (index >= 0 && index < arr.length) {
            arr.splice(index, 1)
            this.size--;
        }
    }
    function get(index) {
        if (index >= 0 && index < arr.length) {
            return arr[index]
        }
    }

    return {
        add,
        remove,
        get,
        size : 0
    }
}

let list = createSortedList();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));

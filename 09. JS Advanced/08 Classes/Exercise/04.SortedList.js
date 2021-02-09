class List {
    constructor() {
        this.list = [];
        this.size = 0;
    }

    add(num) {
        this.list.push(num);
        this.list.sort((a, b) => a - b);
        this.size++;
    }
    remove(i) {
        if (i >= 0 && i < this.list.length) {
            this.list.splice(i, 1);
            this.size--;
        }
    }
    get(i) {
        if (i >= 0 && i < this.list.length) {
            return this.list[i];
        }
    }
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));

class Rectangle {
    constructor(width, height, color) {
        this.width = Number(width);
        this.height = Number(height);
        this.color = color.charAt(0).toUpperCase() + color.slice(1);
    }
    calcArea(){
        return this.width * this.height;
    }
}

let rect = new Rectangle(4, 5, 'Red');
console.log(rect.width);
console.log(rect.height);
console.log(rect.color);
console.log(rect.calcArea());
 
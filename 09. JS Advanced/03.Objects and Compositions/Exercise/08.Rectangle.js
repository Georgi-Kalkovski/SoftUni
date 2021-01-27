function rectangle(num1, num2, string) {

    width = Number(num1);
    height = Number(num2);
    function calcArea() { return width * height };
    color =  string.charAt(0).toUpperCase() + string.slice(1);

    return{
        width,
        height,
        color,
        calcArea,
    }
}

let rect = rectangle(4, 5, 'red');
console.log(rect.width);
console.log(rect.height);
console.log(rect.color);
console.log(rect.calcArea());

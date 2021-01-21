function stringLength(a, b, c) {
    let total = 0;
    total += a.length;
    total += b.length;
    total += c.length;
    let average = Math.floor(total / 3);

    console.log(total);
    console.log(average);
}

stringLength('chocolate', 'ice cream', 'cake');
stringLength('pasta', '5', '22.3');
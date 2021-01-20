function DiagonalSums(matrix) {

    let sum1 = 0;
    let sum2 = 0;

    for (let i = 0; i < matrix.length; i++) {
        sum1 += matrix[i][i];
        sum2 += matrix[i][matrix.length - i - 1]
    }

    return sum1 + ' ' + sum2;
}

console.log(DiagonalSums(
    [[20, 40],
    [10, 60]]
));
console.log(DiagonalSums(
    [[3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]]
));
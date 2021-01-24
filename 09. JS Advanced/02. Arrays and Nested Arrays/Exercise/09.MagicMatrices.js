function MagicMatrices(matrix) {

    let sumChecker = matrix[0].reduce((result, curr) => result + curr, 0);
    let isEqual = true;

    for (let i = 0; i < matrix.length; i++) {

        let sumRow = matrix[i].reduce((result, curr) => result + curr, 0);
        let sumCol = 0;

        for (let j = 0; j < matrix.length; j++) {
            sumCol += matrix[j][i];
        }

        if (sumCol !== sumRow || sumChecker !== sumCol || sumChecker !== sumRow) {
            isEqual = false;
        }
    }
    return isEqual;
}

console.log(MagicMatrices([[1, 0, 0]]));
console.log(MagicMatrices([[4, 5, 6], [6, 5, 4], [5, 5, 5]]));
console.log(MagicMatrices([[11, 32, 45], [21, 0, 1], [21, 1, 1]]));
console.log(MagicMatrices([[1, 0, 0], [0, 0, 1], [0, 1, 0]]));
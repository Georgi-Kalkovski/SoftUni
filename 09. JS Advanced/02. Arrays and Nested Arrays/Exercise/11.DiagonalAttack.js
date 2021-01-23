function DiagonalAttack(inputMatrix) {

    let diagonalSum1 = 0;
    let diagonalSum2 = 0;

    for (let i = 0; i < inputMatrix.length; i++) {
        diagonalSum1 += Number(inputMatrix[i].split(' ')[i]);
    }
    for (let i = 0; i < inputMatrix.length; i++) {
        diagonalSum2 += Number(inputMatrix[i].split(' ')[inputMatrix.length - i - 1]);
    }


    if (diagonalSum1 == diagonalSum2) {
        return printSpecialMatrix(inputMatrix);
    } else {
        return printMatrix(inputMatrix);
    }

    function printSpecialMatrix(inputMatrix) {

        for (let i = 0; i < inputMatrix.length; i++) {

            let row = '';
            let currentRow = inputMatrix[i].split(' ');

            for (let j = 0; j < currentRow.length; j++) {
                if (i == j || inputMatrix.length - i - 1 == j) {
                    row += currentRow[j] + ' ';
                    continue;
                }
                row += diagonalSum1 + ' ';
            }
            row = row.trimEnd(' ');
            console.log(row);
        }
    }

    function printMatrix(matrix) {
        for (let i = 0; i < matrix.length; i++) {
            console.log(matrix[i]);
        }
    }
}

DiagonalAttack(['5 3 12 3 1', '11 4 23 2 5', '101 12 3 21 10', '1 4 5 2 2', '5 22 33 11 1']);
DiagonalAttack
    (['1 1 1',
        '1 1 1',
        '1 1 0']);
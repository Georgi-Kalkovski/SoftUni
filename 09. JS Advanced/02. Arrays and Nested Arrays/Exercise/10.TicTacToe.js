function TicTacToe(inputMatrix) {

    let matrix =
        [[false, false, false],
        [false, false, false],
        [false, false, false]];

    let counter = 0;
    let player = 'X';

    for (let i = 0; i <= inputMatrix.length; i++) {

        if (counter == 9) {
            return "The game ended! Nobody wins :(" + '\n' +
                matrix[0][0] + '\t' + matrix[0][1] + '\t' + matrix[0][2] + '\n' +
                matrix[1][0] + '\t' + matrix[1][1] + '\t' + matrix[1][2] + '\n' +
                matrix[2][0] + '\t' + matrix[2][1] + '\t' + matrix[2][2];
        }

        let coordinates = [inputMatrix[i].split(' ')];
        let cord1 = Number(coordinates[0][0]);
        let cord2 = Number(coordinates[0][1]);

        if (matrix[cord1][cord2] == false) {
            matrix[cord1][cord2] = player;
            counter++;
        } else {
            console.log("This place is already taken. Please choose another!");
            continue;
        }

        if (matrix[0][0] == matrix[0][1] && matrix[0][1] == matrix[0][2] && matrix[0][0] != false ||
            matrix[1][0] == matrix[1][1] && matrix[1][1] == matrix[1][2] && matrix[1][0] != false ||
            matrix[2][0] == matrix[2][1] && matrix[2][1] == matrix[2][2] && matrix[2][0] != false ||
            matrix[0][0] == matrix[1][0] && matrix[1][0] == matrix[2][0] && matrix[0][0] != false ||
            matrix[0][1] == matrix[1][1] && matrix[1][1] == matrix[2][1] && matrix[0][1] != false ||
            matrix[0][2] == matrix[1][2] && matrix[1][2] == matrix[2][2] && matrix[0][2] != false ||
            matrix[0][0] == matrix[1][1] && matrix[1][1] == matrix[2][2] && matrix[0][0] != false ||
            matrix[0][2] == matrix[1][1] && matrix[1][1] == matrix[2][0] && matrix[0][2] != false) {

            return `Player ${player} wins!` + '\n' +
                matrix[0][0] + '\t' + matrix[0][1] + '\t' + matrix[0][2] + '\n' +
                matrix[1][0] + '\t' + matrix[1][1] + '\t' + matrix[1][2] + '\n' +
                matrix[2][0] + '\t' + matrix[2][1] + '\t' + matrix[2][2];
        }

        if (player == 'X') { player = 'O'; }
        else { player = 'X'; }
    }
}

console.log(TicTacToe(["0 1", "0 0", "0 2", "2 0", "1 0", "1 1", "1 2", "2 2", "2 1", "0 0"]));
console.log(TicTacToe(["0 0", "0 0", "1 1", "0 1", "1 2", "0 2", "2 2", "1 2", "2 2", "2 1"]));
console.log(TicTacToe(["0 1", "0 0", "0 2", "2 0", "1 0", "1 2", "1 1", "2 1", "2 2", "0 0"]));
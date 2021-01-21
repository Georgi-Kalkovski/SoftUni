function TicTacToe(matrix) {

    let myMatrix =
        [[false, false, false],
        [false, false, false],
        [false, false, false]];

    let counter = 0;

    for (let i = 0; i < matrix.length; i++) {

        if (counter == 9) {
            console.log("The game ended! Nobody wins :(");
            return;
        }

        let player = '';
        let coordinates = [matrix[i].split(' ')];

        if (i % 2 == 0) {
            player = 'X';
        } else {
            player = 'O';
        }

        let cord1 = Number(coordinates[0][0]);
        let cord2 = Number(coordinates[0][1]);

        if (myMatrix[cord1][cord2] == false) {
            myMatrix[cord1][cord2] = player;
            counter++;
        } else {
            console.log("This place is already taken. Please choose another!");
        }

        if (matrix[0][0] == matrix[0][1] && matrix[0][1] == matrix[0][2] && matrix[0][0] != false ||
            matrix[1][0] == matrix[1][1] && matrix[1][1] == matrix[1][2] && matrix[1][0] != false ||
            matrix[2][0] == matrix[2][1] && matrix[2][1] == matrix[2][2] && matrix[2][0] != false ||
            matrix[0][0] == matrix[1][0] && matrix[1][0] == matrix[2][0] && matrix[0][0] != false ||
            matrix[0][1] == matrix[1][1] && matrix[1][1] == matrix[2][1] && matrix[0][1] != false ||
            matrix[0][2] == matrix[1][2] && matrix[1][2] == matrix[2][2] && matrix[0][2] != false ||
            matrix[0][0] == matrix[1][1] && matrix[1][1] == matrix[2][2] && matrix[0][0] != false ||
            matrix[0][2] == matrix[1][1] && matrix[1][1] == matrix[2][0] && matrix[0][2] != false) {
            return `Player ${player} wins`;
        }
    }
}

console.log(TicTacToe(["0 1", "0 0", "0 2", "2 0", "1 0", "1 1", "1 2", "2 2", "2 1", "0 0"]));
//console.log(TicTacToe(["0 0", "0 0", "1 1", "0 1", "1 2", "0 2", "2 2", "1 2", "2 2", "2 1"]));
//console.log(TicTacToe(["0 1", "0 0", "0 2", "2 0", "1 0", "1 2", "1 1", "2 1", "2 2", "0 0"]));
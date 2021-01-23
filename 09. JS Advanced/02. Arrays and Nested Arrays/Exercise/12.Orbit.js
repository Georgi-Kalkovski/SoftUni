function Orbit(arr) {
    let rows = arr[0];
    let cols = arr[1];
    let starRow = arr[2];
    let starCol = arr[3];

    let matrix = [];
    
    for(let i=0; i<rows; i++) {
        matrix.push([]);
    }

    for(let row = 0; row< rows; row++) {
        for(let col=0; col<cols; col++) {
            matrix[row][col] = Math.max(Math.abs(row - starRow), Math.abs(col - starCol)) + 1;
        }
    }

    console.log(matrix.map(row => row.join(" ")).join("\n"));
}

Orbit([4, 4, 0, 0]);
Orbit([5, 5, 2, 2]);
Orbit([3, 3, 2, 2]);
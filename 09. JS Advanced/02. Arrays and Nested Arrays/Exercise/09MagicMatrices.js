function MagicMatrices(arr) {

    let isEqual = true;

    for (let i = 0; i < arr.length; i++) {

        let currentRow = arr[i].reduce((a, b) => a + b, 0);
        let currentCol = 0;

        for (let j = 0; j < arr.length; j++) {
            currentCol += arr[j][i];
        } 

        if (currentCol != currentRow) {
            isEqual = false;
        }
    }

    return isEqual;
}

console.log(MagicMatrices([[4, 5, 6], [6, 5, 4], [5, 5, 5]]));
console.log(MagicMatrices([[11, 32, 45], [21, 0, 1], [21, 1, 1]]));
console.log(MagicMatrices([[1, 0, 0], [0, 0, 1], [0, 1, 0]]));
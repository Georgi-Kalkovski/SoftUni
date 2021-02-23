describe('numberOperations', () => {
    describe('powNumber', () => {
        it('the function returns the power of the given number', () => {
            expect(numberOperations.powNumber(5)).to.equal(25);
        });
    });
    
    describe('numberChecker', () => {
        it('the function parses the input to number, and validates it', () => {
            assert.throw(() => numberOperations.numberChecker(NaN), 'The input is not a number!');
        });
        it('above or below 100', () => {
            expect(numberOperations.numberChecker(99)).to.equal('The number is lower than 100!');
            expect(numberOperations.numberChecker(100)).to.equal('The number is greater or equal to 100!');
            expect(numberOperations.numberChecker(105)).to.equal('The number is greater or equal to 100!');
        });
    });

    describe('sumArrays', () => {
        it('The function returns new array, which represents the sum of the two arrays by indexes', () => {
 
            expect(numberOperations.sumArrays([1, 2,], [2, 3])).to.deep.equal([3, 5]);
            expect(numberOperations.sumArrays([-1, -2,], [-1, -2])).to.deep.equal([-2, -4]);
            expect(numberOperations.sumArrays([0, 0,], [0, 0])).to.deep.equal([0, 0]);
            expect(numberOperations.sumArrays([1, 2, 3], [1, 2])).to.deep.equal([2, 4, 3]);
            expect(numberOperations.sumArrays([1, 2], [1, 2, 3])).to.deep.equal([2, 4, 3]);
            expect(numberOperations.sumArrays([1], [1])).to.deep.equal([2]);
        });
    });
});
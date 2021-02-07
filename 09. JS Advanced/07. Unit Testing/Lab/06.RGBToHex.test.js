const { expect } = require('chai');
const rgbToHexColor = require('./06.RGBToHex');

describe('RGB to Hex check', () => {
    it('should be used number and not string', () => {
        expect(rgbToHexColor('red', 0, 0)).to.equal(undefined);
    });
    it('should be used number and not string', () => {
        expect(rgbToHexColor(0, 'green', 0)).to.equal(undefined);
    });
    it('should be used number and not string', () => {
        expect(rgbToHexColor(0, 0, 'blue')).to.equal(undefined);
    });
    it('should not be negative number', () => {
        expect(rgbToHexColor(-1, 0, 0)).to.equal(undefined);
    });
    it('should not be negative number', () => {
        expect(rgbToHexColor(0, -1, 0)).to.equal(undefined);
    });
    it('should not be negative number', () => {
        expect(rgbToHexColor(0, 0, -1)).to.equal(undefined);
    });
    it('should be below the number 256', () => {
        expect(rgbToHexColor(256, 0, 0)).to.equal(undefined);
    });
    it('should be below the number 256', () => {
        expect(rgbToHexColor(0, 256, 0)).to.equal(undefined);
    });
    it('should be below the number 256', () => {
        expect(rgbToHexColor(0, 0, 256)).to.equal(undefined);
    });
    it('test for black color', () => {
        expect(rgbToHexColor(0, 0, 0)).to.equal('#000000');
    });
    it('test for white color', () => {
        expect(rgbToHexColor(255, 255, 255)).to.equal('#FFFFFF');
    });
});
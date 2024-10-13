import { expect } from 'chai';
import { rgbToHexColor } from '../rgb-to-hex.js'; // Adjust path based on your file structure

describe('rgbToHexColor', () => {
    it('should convert valid RGB values to hex format', () => {
        expect(rgbToHexColor(255, 255, 255)).to.equal('#FFFFFF');
        expect(rgbToHexColor(0, 0, 0)).to.equal('#000000');
        expect(rgbToHexColor(255, 0, 0)).to.equal('#FF0000');
        expect(rgbToHexColor(0, 255, 0)).to.equal('#00FF00');
        expect(rgbToHexColor(0, 0, 255)).to.equal('#0000FF');
        expect(rgbToHexColor(255, 165, 0)).to.equal('#FFA500'); // Orange
    });

    it('should return undefined for invalid red value', () => {
        expect(rgbToHexColor(-1, 100, 100)).to.be.undefined;
        expect(rgbToHexColor(256, 100, 100)).to.be.undefined;
        expect(rgbToHexColor('255', 100, 100)).to.be.undefined; // Non-integer
        expect(rgbToHexColor(255.5, 100, 100)).to.be.undefined; // Non-integer
    });

    it('should return undefined for invalid green value', () => {
        expect(rgbToHexColor(100, -1, 100)).to.be.undefined;
        expect(rgbToHexColor(100, 256, 100)).to.be.undefined;
        expect(rgbToHexColor(100, '100', 100)).to.be.undefined; // Non-integer
        expect(rgbToHexColor(100, 100.5, 100)).to.be.undefined; // Non-integer
    });

    it('should return undefined for invalid blue value', () => {
        expect(rgbToHexColor(100, 100, -1)).to.be.undefined;
        expect(rgbToHexColor(100, 100, 256)).to.be.undefined;
        expect(rgbToHexColor(100, 100, '100')).to.be.undefined; // Non-integer
        expect(rgbToHexColor(100, 100, 100.5)).to.be.undefined; // Non-integer
    });

    it('should return undefined for non-integer inputs', () => {
        expect(rgbToHexColor('red', 'green', 'blue')).to.be.undefined;
        expect(rgbToHexColor([], {}, null)).to.be.undefined;
    });
});
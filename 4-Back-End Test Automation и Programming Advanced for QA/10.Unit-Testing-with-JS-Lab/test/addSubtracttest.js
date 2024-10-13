import { expect } from 'chai';
import { createCalculator } from '../addSubtract.js'; // Adjust path based on your file structure

describe('createCalculator', () => {
    let calculator;

    beforeEach(() => {
        calculator = createCalculator(); // Create a new calculator instance for each test
    });

    it('should start with a value of 0', () => {
        expect(calculator.get()).to.equal(0);
    });

    it('should add numbers correctly', () => {
        calculator.add(5);
        expect(calculator.get()).to.equal(5);
        calculator.add(3);
        expect(calculator.get()).to.equal(8);
        calculator.add('2'); // Test with string
        expect(calculator.get()).to.equal(10);
    });

    it('should subtract numbers correctly', () => {
        calculator.subtract(2);
        expect(calculator.get()).to.equal(-2);
        calculator.subtract(3);
        expect(calculator.get()).to.equal(-5);
        calculator.subtract('2'); // Test with string
        expect(calculator.get()).to.equal(-7);
    });

    it('should handle adding and subtracting correctly', () => {
        calculator.add(10);
        calculator.subtract(3);
        expect(calculator.get()).to.equal(7);
        calculator.add(5);
        expect(calculator.get()).to.equal(12);
        calculator.subtract(12);
        expect(calculator.get()).to.equal(0);
    });

    it('should maintain internal state independently', () => {
        const calculator2 = createCalculator(); // Create another instance
        calculator.add(5);
        expect(calculator.get()).to.equal(5);
        expect(calculator2.get()).to.equal(0); // Should be independent
    });
});
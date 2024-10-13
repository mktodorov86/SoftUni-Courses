import { sum } from '../sumNumbers.js'; // Adjust path based on your file structure
import { expect } from 'chai';

describe('sum()', () => {
  it('should return 6 when the input is [1, 2, 3]', () => {
    const result = sum([1, 2, 3]);
    expect(result).to.equal(6);
  });

  it('should return 0 for an empty array', () => {
    const result = sum([]);
    expect(result).to.equal(0);
  });

  it('should handle negative numbers', () => {
    const result = sum([-1, -2, -3]);
    expect(result).to.equal(-6);
  });
  it('should handle mixed positive and negative numbers', () => {
    const result = sum([-1, 2, -3, 4]);
    expect(result).to.equal(2);
  });

  it('should handle an array with a single number', () => {
    const result = sum([5]);
    expect(result).to.equal(5);
  });

  it('should convert string numbers to actual numbers', () => {
    const result = sum(['1', '2', '3']);
    expect(result).to.equal(6);
  });
});
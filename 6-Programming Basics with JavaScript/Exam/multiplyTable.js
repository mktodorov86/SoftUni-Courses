function multiplicationTable(input) {
    let num = input[0];
    
    let firstDigit = Number(num[2]);  // най-дясната цифра
    let secondDigit = Number(num[1]); // средната цифра
    let thirdDigit = Number(num[0]);  // най-лявата цифра

    for (let a = 1; a <= firstDigit; a++) {
        for (let b = 1; b <= secondDigit; b++) {
            for (let c = 1; c <= thirdDigit; c++) {
                let result = a * b * c;
                console.log(`${a} * ${b} * ${c} = ${result};`);
            }
        }
    }
}

function sumNumbers(number)
{
    let digits = number.toString().split('');
    let sumOfDigits = 0;

    for(let digit of digits)
    {
        sumOfDigits += Number(digit);
    }

    console.log(sumOfDigits);
}




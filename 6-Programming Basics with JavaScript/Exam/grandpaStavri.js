function rakiaCalculator(input) {
    let days = Number(input[0]);
    let totalLiters = 0;
    let totalDegreesSum = 0;

    let index = 1;
    for (let i = 0; i < days; i++) {
        let liters = Number(input[index]);
        let degrees = Number(input[index + 1]);
        totalLiters += liters;
        totalDegreesSum += liters * degrees;
        index += 2;
    }

    let averageDegrees = totalDegreesSum / totalLiters;

    console.log(`Liter: ${totalLiters.toFixed(2)}`);
    console.log(`Degrees: ${averageDegrees.toFixed(2)}`);

    if (averageDegrees < 38) {
        console.log("Not good, you should baking!");
    } else if (averageDegrees <= 42) {
        console.log("Super!");
    } else {
        console.log("Dilution with distilled water!");
    }
}

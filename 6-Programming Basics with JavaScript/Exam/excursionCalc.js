function excursionCalculator(groupCount, season) {
    let pricePerPerson = 0;

    if (groupCount <= 5) {
        if (season === "spring") {
            pricePerPerson = 50.00;
        } else if (season === "summer") {
            pricePerPerson = 48.50;
        } else if (season === "autumn") {
            pricePerPerson = 60.00;
        } else if (season === "winter") {
            pricePerPerson = 86.00;
        }
    } else {
        if (season === "spring") {
            pricePerPerson = 48.00;
        } else if (season === "summer") {
            pricePerPerson = 45.00;
        } else if (season === "autumn") {
            pricePerPerson = 49.50;
        } else if (season === "winter") {
            pricePerPerson = 85.00;
        }
    }

    let total = pricePerPerson * groupCount;

    if (season === "summer") {
        total *= 0.85; // 15% discount
    } else if (season === "winter") {
        total *= 1.08; // 8% increase
    }

    console.log(`${total.toFixed(2)} leva.`);
}

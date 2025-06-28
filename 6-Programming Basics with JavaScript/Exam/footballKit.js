function footballKit(tshirtPrice, requiredAmount) {
    let shortsPrice = tshirtPrice * 0.75;
    let socksPrice = shortsPrice * 0.20;
    let bootsPrice = (tshirtPrice + shortsPrice) * 2;

    let total = tshirtPrice + shortsPrice + socksPrice + bootsPrice;
    let discountedTotal = total * 0.85;

    if (discountedTotal >= requiredAmount) {
        console.log("Yes, he will earn the world-cup replica ball!");
        console.log(`His sum is ${discountedTotal.toFixed(2)} lv.`);
    } else {
        let needed = requiredAmount - discountedTotal;
        console.log("No, he will not earn the world-cup replica ball.");
        console.log(`He needs ${needed.toFixed(2)} lv. more.`);
    }
}

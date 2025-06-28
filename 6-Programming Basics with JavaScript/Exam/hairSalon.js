function hairSalon(input) {
    let target = Number(input[0]);
    let totalEarned = 0;
    let index = 1;

    while (index < input.length) {
        let command = input[index];

        if (command === "closed") {
            break;
        }

        index++;
        let serviceType = input[index];

        if (command === "haircut") {
            if (serviceType === "mens") {
                totalEarned += 15;
            } else if (serviceType === "ladies") {
                totalEarned += 20;
            } else if (serviceType === "kids") {
                totalEarned += 10;
            }
        } else if (command === "color") {
            if (serviceType === "touch up") {
                totalEarned += 20;
            } else if (serviceType === "full color") {
                totalEarned += 30;
            }
        }

        if (totalEarned >= target) {
            break;
        }

        index++;
    }

    if (totalEarned >= target) {
        console.log("You have reached your target for the day!");
    } else {
        let diff = target - totalEarned;
        console.log(`Target not reached! You need ${diff}lv. more.`);
    }

    console.log(`Earned money: ${totalEarned}lv.`);
}

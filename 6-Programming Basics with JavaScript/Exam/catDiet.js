function catDiet(fatPercent, proteinPercent, carbPercent, totalCalories, waterPercent) {
    const fatGrams = (fatPercent / 100 * totalCalories) / 9;
    const proteinGrams = (proteinPercent / 100 * totalCalories) / 4;
    const carbGrams = (carbPercent / 100 * totalCalories) / 4;

    const totalFoodWeight = fatGrams + proteinGrams + carbGrams;
    const caloriesPerGram = totalCalories / totalFoodWeight;
    const dryMatterCalories = caloriesPerGram * ((100 - waterPercent) / 100);

    console.log(dryMatterCalories.toFixed(4));
}
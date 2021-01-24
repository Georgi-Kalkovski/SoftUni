function TownPopulation(name, population, treasury) {
    let city = {};
    city.name = name;
    city.population = population;
    city.treasury = treasury;
    return city;
}

console.log(TownPopulation('Tortuga', 7000, 15000));
console.log(TownPopulation('Santo Domingo', 12000, 23500));
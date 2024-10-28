function herroes(array){
    let heroes=[];
    array.forEach(heroData=> {
        let[heroName, heroLevel, heroItems]=heroData.split(' / ');

        heroLevel = Number(heroLevel);
        heroes.push({name: heroName, level: heroLevel, items: heroItems})
    });
    heroes.sort((a, b) => a.level - b.level);

    heroes.forEach(hero => {
        console.log(`Hero: ${hero.name}`);
        console.log(`level => ${hero.level}`);
        console.log(`items => ${hero.items}`);
    })
}

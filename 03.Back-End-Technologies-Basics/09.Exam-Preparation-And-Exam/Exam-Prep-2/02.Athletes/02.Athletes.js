function solve(athletes) {
    function getAthletesBySport(sport) {
        const filteredAthletes=athletes.filter(athlet=>athlet.sport===sport);
        return filteredAthletes;
    }
  
    function addAthlete(id, name, sport, medals, country) {
        const athleteToAdd = {id, name, sport, medals, country}
        athletes.push(athleteToAdd);
        return athletes;
    }
  
    function getAthleteById(id) {
        const findAthleteById=athletes.find(athlet=>athlet.id===id);
        if(findAthleteById== undefined){
           return  `Athlete with ID ${id} not found`;
        }
        else{
            return findAthleteById;
        }
    }
  
    function removeAthleteById(id) {
        const indexRemoveAthleteById=athletes.findIndex(athlet=>athlet.id===id);
        if(indexRemoveAthleteById === -1){
            return `Athlete with ID ${id} not found`;
        }
        else{
            athletes.splice(indexRemoveAthleteById, 1);
            return athletes;
        }
    }
  
    function updateAthleteMedals(id, newMedals) {
        const findAthleteById=athletes.find(athlet=>athlet.id===id);
        
        if(findAthleteById){
            findAthleteById.medals = newMedals;
            return athletes;
        }
        else{
            return `Athlete with ID ${id} not found`;
        }

    }
  
    function updateAthleteCountry(id, newCountry) {
        const findAthleteById=athletes.find(athlet=>athlet.id===id);
        if(findAthleteById){
            findAthleteById.country = newCountry;
            return athletes;
        }
        else{
            return `Athlete with ID ${id} not found`;
        }

    }
  
    return {
        getAthletesBySport,
        addAthlete,
        getAthleteById,
        removeAthleteById,
        updateAthleteMedals,
        updateAthleteCountry
    };
}

let athletes = [
    { id: 1, name: "Usain Bolt", sport: "Sprinting", medals: 8, country: "Jamaica" },
    { id: 2, name: "Michael Phelps", sport: "Swimming", medals: 23, country: "USA" },
    { id: 3, name: "Simone Biles", sport: "Gymnastics", medals: 7, country: "USA" }
  ];


const olympics = solve(athletes);
const updatedAthlete = olympics.addAthlete(4, "Ivan Prezhdarov", "Swimming", 14, "Germany");
console.log(JSON.stringify(updatedAthlete));




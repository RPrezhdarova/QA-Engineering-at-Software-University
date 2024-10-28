function town(array){
    array.forEach(townInfo => {
        let[town, latitude, longitude] = townInfo.split(' | ');
        latitude = Number(latitude).toFixed(2);
        longitude = Number(longitude).toFixed(2);
        let townObject ={
            town: town,
            latitude: latitude,
            longitude: longitude
        }
        console.log(townObject);
    });
}

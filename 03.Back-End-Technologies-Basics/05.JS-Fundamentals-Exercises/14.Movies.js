function movies(commands){
    let movies={};
    commands.forEach(command =>{
        if(command.startsWith('addMovie ')){
            let movieName=command.substring(9);
            movies[movieName]={name: movieName}        
            }
        else if(command.includes('directedBy')){
            let [movieName, director]= command.split(' directedBy ');
            if (movies[movieName])
                {
                    movies[movieName].director = director;
                }
        }
        else if(command.includes('onDate')){
            let [movieName, date]= command.split(' onDate ');
            if (movies[movieName])
                {
                    movies[movieName].date = date;
                }
        }
    });
    for (let movieName in movies){
        let movie = movies[movieName];
        if(movie.name && movie.director && movie.date){
            console.log(JSON.stringify(movie))
        }
    }
}

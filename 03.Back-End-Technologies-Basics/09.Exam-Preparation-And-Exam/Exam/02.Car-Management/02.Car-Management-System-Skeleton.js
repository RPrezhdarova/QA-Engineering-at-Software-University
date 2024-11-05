function solve(cars) {
    function getCarsByBrand(brand) {
        const filteredCards=cars.filter(car => car.brand === brand);
        return filteredCards;
    }

    function addCar(id, brand, model, year, price, inStock) {
        const newCar = { id, brand, model, year, price, inStock };
        cars.push(newCar);
        return cars;
    }

    function getCarById(id) {
        const foundCar= cars.find(car=> car.id === id);
        if(foundCar == undefined){
            return `Car with ID ${id} not found`;
        }
        else{
            return foundCar;
        }
    }

    function removeCarById(id) {
        const indexOfRemovedCar=cars.findIndex(car => car.id === id);
        if(indexOfRemovedCar === -1){
            return `Car with ID ${id} not found`;
        }
        else{
            cars.splice(indexOfRemovedCar, 1)
            return cars;
        }
    }

    function updateCarPrice(id, newPrice) {
        const car = cars.find(car => car.id === id);
        if(car){
            car.price = newPrice;
            return cars;
        }
        else{
            return `Car with ID ${id} not found`;
        }
    }

    function updateCarStock(id, inStock) {
        const car = cars.find(car => car.id === id);
        if(car){
            car.inStock = inStock;
            return cars;
        }
        else{
            return `Car with ID ${id} not found`;
        }
    }

    return {
        getCarsByBrand,
        addCar,
        getCarById,
        removeCarById,
        updateCarPrice,
        updateCarStock
    };
}

let cars = [
    { id: 1, brand: "Toyota", model: "Corolla", year: 2020, price: 20000, inStock: true },
    { id: 2, brand: "Honda", model: "Civic", year: 2019, price: 22000, inStock: true },
    { id: 3, brand: "Ford", model: "Mustang", year: 2021, price: 35000, inStock: false }
  ];

  const dealership = solve(cars);
  const updatedCars = dealership.updateCarStock(1, false);
  console.log(JSON.stringify(updatedCars));
  


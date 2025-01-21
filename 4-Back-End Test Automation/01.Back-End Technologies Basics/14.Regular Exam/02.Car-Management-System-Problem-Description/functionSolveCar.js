function solve(cars) {
    function getCarsByBrand(brand) {
        return cars.filter(function(car) {
            return car.brand === brand;
        });
    }

    function addCar(id, brand, model, year, price, inStock) {
        var newCar = { id: id, brand: brand, model: model, year: year, price: price, inStock: inStock };
        cars.push(newCar);
        return cars;
    }

    function getCarById(id) {
        var car = cars.find(function(car) {
            return car.id === id;
        });
        return car || "Car with ID " + id + " not found";
    }

    function removeCarById(id) {
        var index = cars.findIndex(function(car) {
            return car.id === id;
        });
        if (index === -1) {
            return "Car with ID " + id + " not found";
        }
        cars.splice(index, 1);
        return cars;
    }

    function updateCarPrice(id, newPrice) {
        var car = cars.find(function(car) {
            return car.id === id;
        });
        if (!car) {
            return "Car with ID " + id + " not found";
        }
        car.price = newPrice;
        return cars;
    }

    function updateCarStock(id, inStock) {
        var car = cars.find(function(car) {
            return car.id === id;
        });
        if (!car) {
            return "Car with ID " + id + " not found";
        }
        car.inStock = inStock;
        return cars;
    }

    return {
        getCarsByBrand: getCarsByBrand,
        addCar: addCar,
        getCarById: getCarById,
        removeCarById: removeCarById,
        updateCarPrice: updateCarPrice,
        updateCarStock: updateCarStock
    };
}
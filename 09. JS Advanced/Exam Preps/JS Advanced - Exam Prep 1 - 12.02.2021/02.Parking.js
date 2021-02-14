class Parking {
    constructor(capacity) {
        this.capacity = capacity;
        this.vehicles = [];
    }

    addCar(carModel, carNumber) {
        if (this.capacity <= 0) {
            throw new Error("Not enough parking space.");
        }
        let car = {
            carModel,
            carNumber,
            payed: false
        }
        this.vehicles.push(car);
        this.capacity--;
        return `The ${carModel}, with a registration number ${carNumber}, parked.`;
    }

    removeCar(carNumber) {
        let car = this.vehicles.find(c => c.carNumber == carNumber);
        if (!car) {
            throw new Error("The car, you're looking for, is not found.");
        }
        if (car.payed == false) {
            throw new Error(`${carNumber} needs to pay before leaving the parking lot.`);
        }
        const index = this.vehicles.indexOf(car);
        if (index > -1) {
            this.vehicles.splice(index, 1);
        }
        this.capacity++;
        return `${carNumber} left the parking lot.`;
    }
    pay(carNumber) {
        let car = this.vehicles.find(c => c.carNumber == carNumber);
        if (!car) {
            throw new Error(`${carNumber} is not in the parking lot.`);
        }
        if (car.payed) {
            throw new Error(`${carNumber}'s driver has already payed his ticket.`);
        }
        car.payed = true;
        return `${carNumber}'s driver successfully payed for his stay.`;
    }
    getStatistics(carNumber) {
        if (!carNumber) {
            //return [
            //    rows
            //].join('\n');     // does \n to every row

            let result = `The Parking Lot has ${this.capacity} empty spots left.`
            // this.vehicles.sort((a, b) => a.carModel.localeCompare(b.carModel))       // does equal sort like the one below
            // .map(car => `${car.carModel} == ${car.carNumber} - ${car.payed == true ? "Has payed" : "Not payed"}`)     //  like the forof below
            this.vehicles.sort(function (a, b) {
                if (a.carModel < b.carModel) { return -1; }
                if (a.carModel > b.carModel) { return 1; }
                return 0;
            })
            for (const car of this.vehicles) {
                result += `\n${car.carModel} == ${car.carNumber} - ${car.payed == true ? "Has payed" : "Not payed"}`;
            }
            return result;
        }

        let car = this.vehicles.find(c => c.carNumber == carNumber);
        return `${car.carModel} == ${car.carNumber} - ${car.payed == true ? "Has payed" : "Not payed"}`;
    }
}

const parking = new Parking(12);

console.log(parking.addCar("Volvo t600", "TX3691CA"));
console.log(parking.addCar("Volvo t6asd00", "TX36das91CA"));
console.log(parking.getStatistics());

console.log(parking.pay("TX3691CA"));
console.log(parking.pay("TX36das91CA"));
console.log(parking.removeCar("TX3691CA"));

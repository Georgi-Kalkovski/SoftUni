function BreakfastRobot() {
    let bill = {

        inventory: { protein: 0, carbohydrate: 0, fat: 0, flavour: 0 },

        restock: (item, quota) => {
            quota = Number(quota)
            bill.inventory[item] += quota
            return 'Success'
        },

        report: () => {
            let status = []
            for (let key in bill.inventory) {
                status.push(`${key}=${bill.inventory[key]}`)
            }
            return status.join(' ')
        },

        apple: (quota) => {
            quota = Number(quota)
            const carb = 1 * quota
            const fl = 2 * quota
            if (bill.inventory.carbohydrate < carb || bill.inventory.flavour < fl) {
                let ingradient = bill.inventory.carbohydrate < carb ? 'carbohydrate' : 'flavour'
                return `Error: not enough ${ingradient} in stock`
            } else {
                bill.inventory.carbohydrate -= carb
                bill.inventory.flavour -= fl
                return `Success`
            }
        },

        lemonade: (quota) => {
            quota = Number(quota)
            const carb = 10 * quota
            const fl = 20 * quota
            if (bill.inventory.carbohydrate < carb || bill.inventory.flavour < fl) {
                let ingradient = bill.inventory.carbohydrate < carb ? 'carbohydrate' : 'flavour'
                return `Error: not enough ${ingradient} in stock`
            } else {
                bill.inventory.carbohydrate -= carb
                bill.inventory.flavour -= fl
                return `Success`
            }
        },

        burger: (quota) => {
            quota = Number(quota)
            const carb = 5 * quota
            const fat = 7 * quota
            const fl = 3 * quota
            if (bill.inventory.carbohydrate < carb) {
                return `Error: not enough carbohydrate in stock`
            } else if (bill.inventory.fat < fat) {
                return `Error: not enough fat in stock`
            } else if (bill.inventory.flavour < fl) {
                return `Error: not enough flavour in stock`
            } else {
                bill.inventory.carbohydrate -= carb
                bill.inventory.fat -= fat
                bill.inventory.flavour -= fl
                return `Success`
            }
        },

        eggs: (quota) => {
            quota = Number(quota)
            const prot = 5 * quota
            const fat = 1 * quota
            const fl = 1 * quota
            if (bill.inventory.protein < prot) {
                return `Error: not enough protein in stock `
            } else if (bill.inventory.fat < fat) {
                return `Error: not enough fat in stock`
            } else if (bill.inventory.flavour < fl) {
                return `Error: not enough flavour in stock`
            } else {
                bill.inventory.protein -= prot
                bill.inventory.fat -= fat
                bill.inventory.flavour -= fl
                return `Success`
            }
        },

        turkey: (quota) => {
            quota = Number(quota)
            const prot = 10 * quota
            const carb = 10 * quota
            const fat = 10 * quota
            const fl = 10 * quota
            if (bill.inventory.protein < prot) {
                return `Error: not enough protein in stock`
            } else if (bill.inventory.carbohydrate < carb) {
                return `Error: not enough carbohydrate in stock`
            }
            else if (bill.inventory.fat < fat) {
                return `Error: not enough fat in stock`
            } else if (bill.inventory.flavour < fl) {
                return `Error: not enough flavour in stock`
            } else {
                bill.inventory.protein -= prot
                bill.inventory.carbohydrate -= carb
                bill.inventory.fat -= fat
                bill.inventory.flavour -= fl
                return `Success`
            }
        }
    }

    return function (input) {
        let [command, item, quota] = input.split(' ')
        return command == 'prepare' ? bill[item](quota) : bill[command](item, quota)
    }
}

let manager1 = BreakfastRobot();
console.log(manager1("restock carbohydrate 10"));
console.log(manager1("restock flavour 10"));
console.log(manager1("prepare apple 1"));
console.log(manager1("restock fat 10"));
console.log(manager1("prepare burger 1"));
console.log(manager1("report"));

let menager2 = BreakfastRobot();
console.log(manager1("prepare turkey 1"));
console.log(manager1("restock protein 10"));
console.log(manager1("prepare turkey 1"));
console.log(manager1("restock carbohydrate 10"));
console.log(manager1("prepare turkey 1"));
console.log(manager1("restock fat 10"));
console.log(manager1("prepare turkey 1"));
console.log(manager1("restock flavour 10"));
console.log(manager1("prepare turkey 1"));
console.log(manager1("report"));
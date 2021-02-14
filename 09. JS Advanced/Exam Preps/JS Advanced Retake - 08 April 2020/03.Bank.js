class Bank {
    constructor(bankName) {
        this.bankName = bankName;
        this.allCustomers = [];
        this.transactions = [];
    }
    newCustomer(customer) {
        let newCustomer = {
            firstName: customer.firstName,
            lastName: customer.lastName,
            personalId: customer.personalId
        }
        if (this.allCustomers.includes(newCustomer)) {
            throw new Error(`${newCustomer.firstName} ${newCustomer.lastName} is already our customer!`)
        }
        this.allCustomers.push(newCustomer)
        return newCustomer;
    }
    depositMoney(personalId, amount) {
        let personFound = this.allCustomers.find(e => e.personalId == personalId);
        if (!personFound) {
            throw new Error(`We have no customer with this ID!`);
        }
        if (!personFound.totalMoney) {
            personFound.totalMoney = Number(0);
        }
        personFound.totalMoney += Number(amount);
        this.transactions.push([personFound.firstName, personFound.lastName, 'made depostit of', Number(amount)]);
        return `${personFound.totalMoney}$`;
    }
    withdrawMoney(personalId, amount) {
        let personFound = this.allCustomers.find(e => e.personalId == personalId);
        if (!personFound) {
            throw new Error(`We have no customer with this ID!`);
        }
        if (personFound.totalMoney < amount) {
            throw new Error(`${personFound.firstName} ${personFound.lastName} does not have enough money to withdraw that amount!`);
        }
        this.transactions.push([personFound.firstName, personFound.lastName, 'withdrew', Number(amount)]);
        personFound.totalMoney -= amount;
        return `${personFound.totalMoney}$`;
    }
    customerInfo(personalId) {
        let personFound = this.allCustomers.find(e => e.personalId == personalId);
        if (!personFound) {
            throw new Error(`We have no customer with this ID!`);
        }
        let result = `Bank name: ${this.bankName}\n` +
            `Customer name: ${personFound.firstName} ${personFound.lastName}\n` +
            `Customer ID: ${personFound.personalId}\n` +
            `Total Money: ${personFound.totalMoney}$\n` +
            `Transactions:`
        let counter = 0;
        for (const transaction of this.transactions) {
            if (transaction[0] == personFound.firstName && transaction[1] == personFound.lastName) {
                counter++;
            }
        }
        for (const transaction of this.transactions.reverse()) {
            if (transaction[0] == personFound.firstName && transaction[1] == personFound.lastName) {
                result += `\n${counter}. ${transaction[0]} ${transaction[1]} ${transaction[2]} ${transaction[3]}$!`;
                counter--;
            }
        }
        return result;
    }
}

let bank = new Bank('SoftUni Bank');

console.log(bank.newCustomer({ firstName: 'Svetlin', lastName: 'Nakov', personalId: 6233267 }));
console.log(bank.newCustomer({ firstName: 'Svetlin', lastName: 'Nakov', personalId: 6233267 }));
console.log(bank.newCustomer({ firstName: 'Mihaela', lastName: 'Mileva', personalId: 4151596 }));

bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596, 555);

console.log(bank.withdrawMoney(6233267, 125));

console.log(bank.customerInfo(6233267));

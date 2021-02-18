class Bank {
    constructor(bankName) {
        this._bankName = bankName;
        this.allCustomers = [];
    }

    newCustomer(customer) {
        let current = this.allCustomers.find(x => x.personalId == customer.personalId);

        if (current) {
            throw new Error(`${customer.firstName} ${customer.lastName} is already our customer!`)
        }

        this.allCustomers.push(customer);

        return customer;
    }

    depositMoney(personalId, amount) {
        let customer = this.allCustomers.find(x => x.personalId == personalId);

        if (!customer) {
            throw new Error('We have no customer with this ID!');
        }

        if (!customer.hasOwnProperty('totalMoney')) {
            customer.totalMoney = 0;
            customer.transactions = [];
        }

        customer.totalMoney += Number(amount);
        customer.transactions.push(`${customer.firstName} ${customer.lastName} made deposit of ${amount}$!`)

        return `${customer.totalMoney}$`;
    }

    withdrawMoney(personalId, amount) {
        let customer = this.allCustomers.find(x => x.personalId == personalId);

        if (!customer) {
            throw new Error('We have no customer with this ID!');
        }

        if (customer.totalMoney < amount) {
            throw new Error(`${customer.firstName} ${customer.lastName} does not have enough money to withdraw that amount!`)
        }

        customer.totalMoney -= amount;
        customer.transactions.push(`${customer.firstName} ${customer.lastName} withdrew ${amount}$!`)

        return `${customer.totalMoney}$`;
    }

    customerInfo(personalId) {
        let customer = this.allCustomers.find(x => x.personalId == personalId);

        if (!customer) {
            throw new Error('We have no customer with this ID!');
        }

        console.log();
        return [
            `Bank name: ${this._bankName}`,
            `Customer name: ${customer.firstName} ${customer.lastName}`,
            `Customer ID: ${customer.personalId}`,
            `Total Money: ${customer.totalMoney}$`,
            `Transactions:`,
            customer.transactions
                .map((x, index) => `${index + 1}. ${x}`)
                .reverse()
                .join('\n')
        ].join('\n');
    }
}
let bank = new Bank('SoftUni Bank');

console.log(bank.newCustomer({ firstName: 'Svetlin', lastName: 'Nakov', personalId: 6233267 }));
console.log(bank.newCustomer({ firstName: 'Mihaela', lastName: 'Mileva', personalId: 4151596 }));

bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596, 555);

console.log(bank.withdrawMoney(6233267, 125));

console.log(bank.customerInfo(6233267));

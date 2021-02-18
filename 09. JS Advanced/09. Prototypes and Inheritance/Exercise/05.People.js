function solve() {

    class Employee {

        constructor(name, age) {
            if (new.target === Employee) {
                throw new Error("Canot instansiate directly.")
            }
            this.name = name
            this.age = age
            this.salary = 0
            this.tasks = []
        }
        work() {
            let currentTask = this.tasks.shift()
            console.log(this.name + currentTask)
            this.tasks.push(currentTask)
        }
        collectSalary() {

            if (this instanceof Manager) {
                console.log(`${this.name} received ${this.salary + this.dividend} this month.`)
            } else {
                console.log(`${this.name} received ${this.salary} this month.`)
            }

        }

    }
    class Junior extends Employee {
        constructor(name, age) {
            super(name, age)
            this.tasks.push(` is working on a simple task.`)
        }
    }
    class Senior extends Employee {
        constructor(name, age) {
            super(name, age)
            this.tasks.push(` is working on a complicated task.`)
            this.tasks.push(` is taking time off work.`)
            this.tasks.push(` is supervising junior workers.`)
        }
    }
    class Manager extends Employee {
        constructor(name, age) {
            super(name, age)
            this.dividend = 0
            this.tasks.push(` scheduled a meeting.`)
            this.tasks.push(` is preparing a quarterly report.`)
        }
    }


    return {
        Employee,
        Junior,
        Senior,
        Manager
    }
}
let result = solve()
var guy1 = new result.Junior('pesho', 20);
var guy2 = new result.Senior('gosho', 21);
var guy3 = new result.Manager('ivan', 22);

guy3.dividend = 5
guy3.salary =10
console.log(guy3.dividend)
console.log(guy3.collectSalary())
class Company {
    constructor() {
        this.departments = [];
    }

    addEmployee(username, salary, position, department) {
        if ([...arguments].some(x => x == '' || x == undefined || x == null) || salary < 0) {
            throw new Error('Invalid input!');
        }

        let employee = {
            username,
            salary,
            position,
            department
        }
        this.departments.push(employee);
        return `New employee is hired. Name: ${username}. Position: ${position}`;
    }

    bestDepartment() {
        const deps = this.departments;
        let sorting = new Array();
        deps.sort(function (a, b) {
            return a.department.localeCompare(b.department)
        });
        let bestName = '';
        let bestAverage = 0;
        let bestSorting = [];

        while (deps.length > 0) {

            let currentDep = deps[0].department;
            let sum = 0;
            let counter = 0;

            while (currentDep == deps[0].department) {
                sum += deps[0].salary;
                counter++;
                sorting.push(deps[0])
                deps.shift();

                if (deps.length == 0) { break; }
            }
            let average = sum / counter;
            if (average > bestAverage) {
                bestAverage = average;
                bestName = currentDep
                bestSorting = Array.from(sorting);
            } else {
                sorting = [];
            }
        }
        bestSorting = bestSorting.sort(function (a, b) {
            return b.salary - a.salary || a.username.localeCompare(b.username);
        });
        let result = `Best Department is: ${bestName}\nAverage salary: ${bestAverage.toFixed(2)}`;
        for (let employee of bestSorting) {
            result += `\n${employee.username} ${Number(employee.salary)} ${employee.position}`;
        }
        return result;
    }
}

// WORKING CODE

/*class Company {
    constructor() {
        this.departments = [];
    }
 
    addEmployee(username, salary, position, department) {
        if ([...arguments].some(a => a === null || a === undefined || a === '') || salary < 0) {
            throw new Error('Invalid input!');
        } else {
            const newEmployee = {
                username: username,
                salary: salary,
                position: position,
                department: department,
            };
            if (this.departments.filter(function (e) {return e.name === department;}).length > 0) {
                for (let existingDepartment of this.departments) {
                    if (existingDepartment.name === department) {
                        existingDepartment.users.push(newEmployee);
                        existingDepartment.totalSalary += salary;
                    }
                }
            } else {
                let newDepartment = {
                    name: department,
                    users: [newEmployee],
                    totalSalary: salary,
                    averageSalary() {
                        return this.totalSalary / this.users.length;
                    },
                };
                this.departments.push(newDepartment);
            }
            return `New employee is hired. Name: ${username}. Position: ${position}`;
        }
    }
 
    bestDepartment() {
        let bestDepartment = this.departments.sort((a, b) => a.averageSalary - b.averageSalary)[0];
        bestDepartment.users = bestDepartment.users.sort(function (a, b) {
            if (a.username === b.username) {
                return b.username - a.username;
            }
            return a.salary < b.salary ? 1 : -1;
        });
        let result = `Best Department is: ${bestDepartment.name}\nAverage salary: ${bestDepartment.averageSalary().toFixed(2)}`;
        for (let user of bestDepartment.users) {
            result += `\n${user.username} ${user.salary} ${user.position}`;
        }
        return result;
    }
}*/

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());

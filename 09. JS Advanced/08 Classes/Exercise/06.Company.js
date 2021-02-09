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
        const deps = this.departments.sort(function (a, b) {
            return a.department.localeCompare(b.department)
        });
        let bestName = '';
        let bestAverage = 0;

        while (deps.length > 0) {

            let currentDep = deps[0].department;
            let sum = 0;
            let counter = 0;

            while (currentDep == deps[0].department) {
                sum += deps[0].salary;
                counter++;
                deps.shift();

                if (deps.length == 0) { break; }
            }
            let average = sum / counter;
            if (average > bestAverage) {
                bestAverage = average;
                bestName = currentDep
            }
        }
        const sorting = this.departments.sort(function (a, b) {
            if (a.salary > b.salary) return 1;
            if (a.name < b.name) return -1;
        });
        console.log(`Best Department is: ${bestName}\nAverage salary: ${bestAverage.toFixed(2)}`);
        for (const employee of sorting) {
            console.log(`${employee.username} ${Number(employee.salary)} ${employee.position}`)
        }
        return;
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());

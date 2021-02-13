function toStringExtension() {
    class Person {
        constructor(name, email) {
            this.name = name;
            this.email = email;
        }

        toString(value) {
            return `${this.constructor.name} (name: ${this.name}, email: ${this.email}${value === undefined ? '' : `, ${value}`})`;
        }
    }

    class Student extends Person {
        constructor(name, email, course) {
            super(name, email);
            this.course = course;
        }

        toString() {
            return super.toString(`course: ${this.course}`);
        }
    }

    class Teacher extends Person {
        constructor(name, email, subject) {
            super(name, email);
            this.subject = subject;
        }

        toString() {
            return super.toString(`subject: ${this.subject}`);
        }
    }

    return {
        Person,
        Teacher,
        Student
    }
}
function toStringExtension() {
    class Person {
        constructor(name, email) {
            this.name = name;
            this.email = email;
        }
        toString() {
            return `Teacher (name: ${name}, email:${email})`;
        }

    }
    //toString() {
    //       if (Person) {
    //           return `Person (name: ${name}, email: ${email})`;
    //       }
    //       if (Teacher) {
    //           return `Teacher (name: ${name}, email:${email}, subject:${subject})`;
    //       }
    //       if (Student) {
    //           return `Student (name: ${name}, email: ${email}, course: ${course})`;
    //       }
    //   }

    class Teacher extends Person {
        constructor(name, email, subject) {
            super(name, email);
            this.subject = subject;
        }
        toString() {
            return `Teacher (name: ${name}, email:${email}, subject:${subject})`;
        }

    };
    class Student extends Person {
        constructor(name, email, course) {
            super(name, email);
            this.course = course;
        }
        toString() {
            return `Student (name: ${name}, email: ${email}, course: ${course})`;
        }
    }
    if (Person) {
        toString() {
            return `Person (name: ${name}, email: ${email})`;
        }
    }
    return {
        Person,
        Teacher,
        Student
    }
}

let classes = toStringExtension();
let Person = classes.Person;
let Teacher = classes.Teacher;
let Student = classes.Student;
let p = new Person("Pesho", 'Pesho@pesh.com');
console.log(p.toString())
expect(p.toString()).to.equal('Person (name: Pesho, email: Pesho@pesh.com)');

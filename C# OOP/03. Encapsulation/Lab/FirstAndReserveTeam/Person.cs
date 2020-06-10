namespace PersonsInfo
{
    using System;
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            if (firstName.Length >= 3)
            {
                this.firstName = firstName;
                
            }
            else throw new ArgumentException("First name cannot contain fewer than 3 symbols!");

            if (lastName.Length >= 3)
            {
                this.lastName = lastName;
            }
            else throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");

            if (age > 0)
            {
                this.age = age;
            }
            else throw new ArgumentException("Age cannot be zero or a negative integer!");

            if (salary > 460.0m)
            {
                this.salary = salary;
            }
            else throw new ArgumentException("Salary cannot be less than 460 leva!");
        }

        public int Age
        {
            get
            {
                return this.age;
            }
        }

        public override string ToString()
        {
            return $"{this.firstName} {this.lastName} receives {this.salary:F2} leva.";
        }

        public void IncreaseSalary(decimal bonus)
        {
            if (this.age >= 30)
            {
                this.salary += this.salary * bonus / 100;
            }
            else
            {
                this.salary += this.salary * bonus / 200;
            }
        }
    }
}

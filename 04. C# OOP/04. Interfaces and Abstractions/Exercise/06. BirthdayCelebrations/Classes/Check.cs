namespace BirthdayCelebrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Check : Robot, Citizen, Pet
    {
        private string name;
        private int age;
        private string id;
        private string model;
        private DateTime birthdate;
        public Check(string name, int age, string id, DateTime birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }
        public Check(string model, string id)
        {
            Id = id;
            Model = model;
        }

        public Check(string name, DateTime birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public DateTime Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }
    }
}

namespace BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Check : Citizens, Robots
    {
        private string name;
        private int age;
        private string id;
        private string model;

        public Check(string model, string id)
        {
            Model = model;
            Id = id;
        }

        public Check(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
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

    }
}

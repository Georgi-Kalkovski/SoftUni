﻿namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Child : Person
    {
        public Child(string name, int age)
            : base(name, age)
        {
            if (base.Age > 15)
            {
                base.Name = name;
                base.Age = age;
            }
        }
    }
}

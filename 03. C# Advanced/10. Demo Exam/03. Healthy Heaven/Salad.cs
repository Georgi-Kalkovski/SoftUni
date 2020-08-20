using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    public class Salad
    {
        public List<Vegetable> Products { get; set; }

        public Salad(List<Vegetable> products, string name)
        {
            Products = products;
            Name = name;
        }

        public string Name { get; set; }

        public int GetTotalCalories()
        {
            int sum = Products.Sum(x=>x.Calories);
            return sum;
        }
        public int GetProductCount()
        {
            return Products.Count;

        }
        public void Add(Vegetable product)
        {
            Products.Add(product);
        }

        public override string ToString()
        {
            return $"* Salad {this.Name} is {Products.Sum(x => x.Calories)} calories and have {Products.Count} products: {string.Join("\n", Name)}";
        }
    }
}

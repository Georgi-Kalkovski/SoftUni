using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Store_Boxes
{

    class Box
    {
        public string SerialNumber { get; set; }
        public string Item { get; set; }
        public int ItemQuantity { get; set; }
        public double PriceBox { get; set; }
        public double PriceOfBoxes { get; set; }
    }
	
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> listOfBoxes = new List<Box>();
			
            while (true)
            {
                List<string> input = Console.ReadLine()
                    .Split()
                    .ToList();

                if (input[0] == "end")
                {
                    break;
                }

                Box box = new Box();

                var serialNumber = input[0];
                var item = input[1];
                var itemQuantity = input[2];
                var priceBox = input[3];
                var priceofBoxes = double.Parse(itemQuantity) * double.Parse(priceBox);

                box.SerialNumber = serialNumber;
                box.Item = item;
                box.ItemQuantity = int.Parse(itemQuantity);
                box.PriceBox = double.Parse(priceBox);
                box.PriceOfBoxes = priceofBoxes;

                listOfBoxes.Add(box);
            }
			
            var newList = listOfBoxes.OrderByDescending(x => x.PriceOfBoxes).ToList();

            foreach (Box box in newList)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item} - ${box.PriceBox:F2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceOfBoxes:F2}");
            }
        }
    }
}

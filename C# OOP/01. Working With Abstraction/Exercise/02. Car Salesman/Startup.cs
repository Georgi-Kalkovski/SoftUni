namespace CarSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CarSalesman
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            for (int i = 0; i < count; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = parameters[0];
                int power = int.Parse(parameters[1]);

                if (parameters.Length == 2)
                {
                    engines.Add(new Engine(model, power));
                }

                else if (parameters.Length == 3)
                {
                    if (parameters[2].All(Char.IsDigit))
                    {
                        int displacement = int.Parse(parameters[2]);

                        engines.Add(new Engine(model, power, displacement));
                    }

                    else
                    {
                        string efficiency = parameters[2];

                        engines.Add(new Engine(model, power, efficiency));
                    }
                }

                else if (parameters.Length == 4)
                {
                    int displacement = int.Parse(parameters[2]);
                    string efficiency = parameters[3];

                    engines.Add(new Engine(model, power, displacement, efficiency));
                }
            }

            count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = parameters[0];
                string engineModel = parameters[1];

                Engine engine = engines.FirstOrDefault(x => x.model == engineModel);

               if (parameters.Length == 2)
                {
                    cars.Add(new Car(model, engine));
                }

                else if (parameters.Length == 3)
                {
                    if (parameters[2].All(Char.IsDigit))
                    {
                        int weight = int.Parse(parameters[2]);

                        cars.Add(new Car(model, engine, weight));
                    }

                    else
                    {
                        string color = parameters[2];

                        cars.Add(new Car(model, engine, color));
                    }
                }

                else if (parameters.Length == 4)
                {
                    int weight = int.Parse(parameters[2]);
                    string color = parameters[3];
                    
                    cars.Add(new Car(model, engine, weight, color));
                }
            }

            cars.ForEach(Console.WriteLine);
        }
    }

}

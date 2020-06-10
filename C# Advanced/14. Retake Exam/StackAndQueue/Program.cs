using System;
using System.Collections.Generic;
using System.Linq;

namespace StackAndQueue
{
    public class Program
    {
        static void Main(string[] args)
        {
            int doll = 150;
            int woodenTrain = 250;
            int teddyBear = 300;
            int bicycle = 400;

            int dollsCounter = 0;
            int woodenTrainsCounter = 0;
            int teddyBearsCounter = 0;
            int bicyclesCounter = 0;

            var materials = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            var magic = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            while (materials.Count > 0 && magic.Count > 0)
            {
                if (materials.Peek() == 0 || magic.Peek() == 0)
                {
                    if (materials.Peek() == 0)
                    {
                        materials.Pop();
                    }
                    if (magic.Peek() == 0)
                    {
                        magic.Dequeue();
                    }
                }

                else if (materials.Peek() * magic.Peek() == doll ||
                    materials.Peek() * magic.Peek() == woodenTrain ||
                    materials.Peek() * magic.Peek() == teddyBear ||
                    materials.Peek() * magic.Peek() == bicycle)
                {
                    if (materials.Peek() * magic.Peek() == doll)
                    {
                        materials.Pop();
                        magic.Dequeue();
                        dollsCounter++;
                    }
                    if (materials.Peek() * magic.Peek() == woodenTrain)
                    {
                        materials.Pop();
                        magic.Dequeue();
                        woodenTrainsCounter++;
                    }
                    if (materials.Peek() * magic.Peek() == teddyBear)
                    {
                        materials.Pop();
                        magic.Dequeue();
                        teddyBearsCounter++;
                    }
                    if (materials.Peek() * magic.Peek() == bicycle)
                    {
                        materials.Pop();
                        magic.Dequeue();
                        bicyclesCounter++;
                    }
                }

                else if (materials.Peek() * magic.Peek() < 0)
                {
                    var sum = materials.Pop() + magic.Dequeue();
                    materials.Push(sum);

                }

                else if (materials.Peek() * magic.Peek() > 0)
                {
                    magic.Dequeue();
                    materials.Push(materials.Pop() + 15);
                }
            }

            if (dollsCounter > 0 && woodenTrainsCounter > 0 ||
                teddyBearsCounter > 0 && bicyclesCounter > 0)
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }

            if (materials.Count > 0)
            {
                Console.WriteLine($"Materials left: {string.Join(", ", materials)}");
            }
            if (magic.Count > 0)
            {
                Console.WriteLine($"Magic left: {string.Join(", ", magic)}");
            }

            if (bicyclesCounter > 0)
            {
                Console.WriteLine($"Bicycle: {bicyclesCounter}");
            }
            if (dollsCounter > 0)
            {
                Console.WriteLine($"Doll: {dollsCounter}");
            }
            if (teddyBearsCounter > 0)
            {
                Console.WriteLine($"Teddy bear: {teddyBearsCounter}");
            }
            if (woodenTrainsCounter > 0)
            {
                Console.WriteLine($"Wooden train: {woodenTrainsCounter}");
            }
        }
    }
}

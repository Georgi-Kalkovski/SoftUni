using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Man_O_War
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> statusOfPirateShip = Console.ReadLine()
                .Split(">")
                .Select(int.Parse)
                .ToList();

            List<int> statusOfWarship = Console.ReadLine()
                .Split(">")
                .Select(int.Parse)
                .ToList();

            int maximumHealth = int.Parse(Console.ReadLine());
            
            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split();
                string command = input[0];

                if (command == "Retire")
                {
                    break;
                }

                else if (command == "Fire")
                {
                    int index = int.Parse(input[1]);
                    int damage = int.Parse(input[2]);
					
                    if (index >= 0 && index < statusOfWarship.Count)
                    {
                        statusOfWarship[index] -= damage;
						
                        if (statusOfWarship[index] <= 0)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            return;
                        }
                    }
                }
				
                else if (command == "Defend")
                {
                    int firstIndex = int.Parse(input[1]);
                    int secondIndex = int.Parse(input[2]);
                    int damage = int.Parse(input[3]);

                    if (firstIndex >= 0 && firstIndex < statusOfPirateShip.Count &&
                        secondIndex >= 0 && secondIndex < statusOfPirateShip.Count)
                    {
                        for (int i = firstIndex; i <= secondIndex; i++)
                        {
                            statusOfPirateShip[i] -= damage;
							
                            if (statusOfPirateShip[i] <= 0)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                return;
                            }
                        }
                    }
                }
				
                else if (command == "Repair")
                {
                    int index = int.Parse(input[1]);
                    int health = int.Parse(input[2]);
					
                    if (index >= 0 && index < statusOfPirateShip.Count)
                    {
                        statusOfPirateShip[index] += health;
                        if (statusOfPirateShip[index] > maximumHealth)
                        {
                            statusOfPirateShip[index] = maximumHealth;
                        }
                    }
                }
				
                else if (command == "Status")
                {
                    int counter = 0;
					
                    foreach (var section in statusOfPirateShip)
                    {
                        if (maximumHealth * 0.20 > section)
                        {
                            counter++;
                        }
                    }
					
                    Console.WriteLine($"{counter} sections need repair.");
                }
            }
			
            Console.WriteLine($"Pirate ship status: {statusOfPirateShip.Sum()}");
            Console.WriteLine($"Warship status: {statusOfWarship.Sum()}");
        }
    }
}

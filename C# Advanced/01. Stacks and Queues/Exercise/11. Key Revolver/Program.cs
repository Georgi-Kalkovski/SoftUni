using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int sizeOfBarrel = int.Parse(Console.ReadLine());
            List<int> bullets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int[] locks = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int valueOfIntelligence = int.Parse(Console.ReadLine());

            Queue<int> locksQueue = new Queue<int>(locks);
            Queue<int> barrelQueue = new Queue<int>();
            int bullet = bullets.Count;
            int bulletsLeft = bullets.Count;
			
            while (barrelQueue.Count != sizeOfBarrel)
            {
                barrelQueue.Enqueue(bullets[bullet-1]);
                bullets.RemoveAt(bullets.Count-1);
                bullet--;
            }
			
            while (true)
            {
                
                if (barrelQueue.Count == 0 && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    {
                        while (barrelQueue.Count != sizeOfBarrel)
                        {
                            barrelQueue.Enqueue(bullets[bullet - 1]);
                            bullets.RemoveAt(bullets.Count - 1);
                            bullet--;
                        }
                    }
                }
				
                if (locksQueue.Count == 0)
                {

                    Console.WriteLine($"{bulletsLeft} bullets left. Earned ${valueOfIntelligence}");
                    return;
                }
				
                if (bulletsLeft == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
                    return;
                }
				
                if (barrelQueue.Peek() > locksQueue.Peek())
                {
                    Console.WriteLine("Ping!");
                    valueOfIntelligence -= bulletPrice;
                    bulletsLeft--;
                    barrelQueue.Dequeue();
                    continue;
                }
				
                else if (barrelQueue.Peek() <= locksQueue.Peek())
                {
                    Console.WriteLine("Bang!");
                    valueOfIntelligence -= bulletPrice;
                    bulletsLeft--;
                    barrelQueue.Dequeue();
                    locksQueue.Dequeue();
                    continue;
                }
            }
        }
    }
}

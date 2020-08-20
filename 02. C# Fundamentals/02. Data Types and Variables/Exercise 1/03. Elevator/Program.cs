using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Elevator
{
    class Program
    {
        static void Main(string[] args)
        {

            int numberOfPeople = int.Parse(Console.ReadLine());          
            int capacityOfElevator = int.Parse(Console.ReadLine());      
            int coursesCount = 0;                                        

            for (int i = numberOfPeople; i > 0; i -= capacityOfElevator) 
            {                                                            
                coursesCount++;                                          
            }                                                            

            Console.WriteLine(coursesCount);                             
        }
    }
}

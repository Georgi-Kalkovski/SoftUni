using System;

namespace _04._Print_and_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());  
            int sum = 0;                                    

            for (var i = startNumber; i <= endNumber; i++)  
            {
                sum += i;                                   
                Console.Write(i + " ");                     
            }
			
            Console.WriteLine();                            
            Console.WriteLine($"Sum: {sum}");               
        }
    }
}

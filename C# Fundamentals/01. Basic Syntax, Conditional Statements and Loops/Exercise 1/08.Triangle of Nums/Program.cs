using System;

namespace _08.Triangle_of_Nums
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());  

            for (int i = 0; i <= number; i++)            
            {
                for (int j = 0; j < i; j++)              
                {
                    Console.Write(i + " ");              
                }
				
                Console.WriteLine();                     
            }
        }
    }
}

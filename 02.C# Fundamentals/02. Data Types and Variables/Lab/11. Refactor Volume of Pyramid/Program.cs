using System;

namespace _11._Refactor_Volume_of_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            double length, width, heigth = 0;            

            length = double.Parse(Console.ReadLine());   
            Console.Write("Length: ");                   

            width = double.Parse(Console.ReadLine());    
            Console.Write("Width: ");                    

            heigth = double.Parse(Console.ReadLine());   
            Console.Write("Height: ");                   

            double sum = (length * width * heigth)/3;    
            Console.Write($"Pyramid Volume: {sum:f2}");  
        }
    }
}

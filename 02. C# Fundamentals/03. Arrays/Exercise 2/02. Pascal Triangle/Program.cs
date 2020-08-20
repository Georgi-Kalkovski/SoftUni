using System;

namespace _02._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            long input = long.Parse(Console.ReadLine());               

            long[][] arr = new long[input][];                          

            arr[0] = new long[1];                                      
            arr[0][0] = 1;                                             

            for (long row = 1; row < arr.Length; row++)                
            {                                                          
                arr[row] = new long[row + 1];                          
                arr[row][0] = 1;                                       
                arr[row][arr[row].Length - 1] = 1;                     

                for (long col = 1; col < arr[row].Length - 1; col++)   
                {                                                     
                    long leftDiagonal = arr[row - 1][col - 1];         
                    long rightDiagonal = arr[row - 1][col];            

                    arr[row][col] = leftDiagonal + rightDiagonal;      
                }                                                      
            }                                                          

            for (long row = 0; row < input; row++)                     
            {                                                          
                Console.WriteLine(string.Join(" ", arr[row]));         
            }                                                          
        }
    }
}
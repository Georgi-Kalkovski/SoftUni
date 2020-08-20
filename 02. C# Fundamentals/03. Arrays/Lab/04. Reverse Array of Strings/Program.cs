using System;
using System.Linq;
namespace _04._Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine()
                .Split()
                .ToArray();

            for(int i = array.Length - 1; i >= 0;i--)
            {
                Console.Write(array[i] + " ");
            } 
        }
    }
}

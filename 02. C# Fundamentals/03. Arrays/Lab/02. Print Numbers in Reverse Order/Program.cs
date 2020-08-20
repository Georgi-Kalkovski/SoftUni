using System;

namespace _02._Print_Numbers_in_Reverse_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numArr = new int [n];

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                numArr[i] = input;
            }

            for (int i = numArr.Length - 1; i >= 0; i--)
            {
                Console.Write(numArr[i] + " ");
            }
        }
    }
}

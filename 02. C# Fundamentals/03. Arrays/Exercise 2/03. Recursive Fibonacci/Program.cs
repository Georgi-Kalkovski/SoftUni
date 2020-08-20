using System;
using System.Linq;

namespace _03._Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            if (input < 3)
            {
                if (input == 0)
                {
                    Console.WriteLine("0");
                    return;
                }

                else
                {
                    Console.WriteLine("1");
                    return;
                }
            }

            int[] arr = new int[input];
            arr[0] = 1;
            arr[1] = 1;

            while (true)
            {
                for (int i = 0; i < arr.Length; i++)
                {

                    if (i > 1)
                    {
                        arr[i] = arr[i-1] + arr[i-2];
                    }

                    if (i+1 == input)
                    {
                        Console.WriteLine(arr[i]);
                        return;
                    }
                }
            }
        }
    }
}

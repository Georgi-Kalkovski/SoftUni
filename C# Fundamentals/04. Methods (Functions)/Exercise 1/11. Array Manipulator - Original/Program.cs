using System;
using System.Linq;

namespace _11._Array_Manipulator
{
    class Program
    {
        static string ManipulationCommands(string input, string[] mainArray, int minMaxOddEven)
        {
            string[] inputArray = input
                .Split()
                .ToArray();
            if (inputArray[0] == "exchange")
            {
                int numOfRotations = int.Parse(inputArray[1]); ;
                string firstNum = string.Empty;
                if (int.Parse(inputArray[1]) - 1 > inputArray.Length)
                {
                    return "Invalid index";
                }
                while (numOfRotations != -1)
                {
                    firstNum = mainArray[0];

                    for (int i = 0; i < mainArray.Length - 1; i++)
                    {
                        mainArray[i] = mainArray[i + 1];
                    }
                    mainArray[mainArray.Length - 1] = firstNum;
                    numOfRotations--;
                }
            }

            int j = 0;

            if (inputArray[0] == "max" && inputArray[1] == "odd")
            {
                minMaxOddEven = int.MinValue;
                for (int i = 0; i < mainArray.Length; i++)
                {
                    if (minMaxOddEven < int.Parse(mainArray[i]) && int.Parse(mainArray[i]) % 2 != 0)
                    {
                        minMaxOddEven = int.Parse(mainArray[i]);
                        j = i;
                    }
                    else continue;
                }
            }
            if (inputArray[0] == "max" && inputArray[1] == "even")
            {
                minMaxOddEven = int.MinValue;
                for (int i = 0; i < mainArray.Length; i++)
                {
                    if (minMaxOddEven < int.Parse(mainArray[i]) && int.Parse(mainArray[i]) % 2 == 0)
                    {
                        minMaxOddEven = int.Parse(mainArray[i]);
                        j = i;
                    }
                    else continue;
                }
            }
            if (inputArray[0] == "min" && inputArray[1] == "odd")
            {
                minMaxOddEven = int.MaxValue;
                for (int i = 0; i < mainArray.Length; i++)
                {
                    if (minMaxOddEven > int.Parse(mainArray[i]) && int.Parse(mainArray[i]) % 2 != 0)
                    {
                        minMaxOddEven = int.Parse(mainArray[i]);
                        j = i;
                    }
                    else continue;
                }
            }
            if (inputArray[0] == "min" && inputArray[1] == "even")
            {
                minMaxOddEven = int.MaxValue;
                for (int i = 0; i < mainArray.Length; i++)
                {
                    if (minMaxOddEven > int.Parse(mainArray[i]) && int.Parse(mainArray[i]) % 2 == 0)
                    {
                        minMaxOddEven = int.Parse(mainArray[i]);
                        j = i;
                    }
                    else continue;
                }
            }
            Console.WriteLine(j);
            // FOR NEXT TIME ---->>>>> izvajdane na Min/Max Odd/Even
            return "";
        }
        static void Main(string[] args)
        {
            string[] mainArray = Console.ReadLine()
                .Split()
                .ToArray();
            string input = Console.ReadLine();
            int minMaxOddEven = 0;
            while (input != "end")
            {
                Console.WriteLine(ManipulationCommands(input, mainArray, minMaxOddEven));
                input = Console.ReadLine();
            }
        }
    }
}


/*
using System;
using System.Linq;
 
namespace _11.Array_Manipulator
{
    class Program
    {
        static void Main()
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input.Split(' ');
                if (command[0] == "exchange") ExchangeArray(command[1], ref array);
                else if (command[0] == "max" && command[1] == "odd") Console.WriteLine(MaxOdd(array));
                else if (command[0] == "max" && command[1] == "even") Console.WriteLine(MaxEven(array));
                else if (command[0] == "min" && command[1] == "even") Console.WriteLine(MinEven(array));
                else if (command[0] == "min" && command[1] == "odd") Console.WriteLine(MinOdd(array));
                else if (command[0] == "first" && command[2] == "odd") Console.WriteLine(FirstOdd(command[1], array));
                else if (command[0] == "first" && command[2] == "even") Console.WriteLine(FirstEven(command[1], array));
                else if (command[0] == "last" && command[2] == "odd") Console.WriteLine(LastOdd(command[1], array));
                else if (command[0] == "last" && command[2] == "even") Console.WriteLine(LastEven(command[1], array));
            }
            Console.WriteLine($"[{string.Join(", ", array)}]");
        }
 
        static void ExchangeArray(string index, ref int[] array)
        {
            int length = array.Length;
            int[] exchArray = new int[length];
            int point = int.Parse(index);
            if (point < 0 || point >= length) Console.WriteLine("Invalid index");
            else
            {
                int lenght1array = length - 1 - point;
                int length2array = length - lenght1array;
                Array.Copy(array, point + 1, exchArray, 0, length - 1 - point);
                Array.Copy(array, 0, exchArray, length - 1 - point, length2array);
                array = exchArray;
            }
        }
 
        static string MaxOdd(int[] array)
        {
            string result = "";
            int maxOdd = int.MinValue;
            int maxOddIndex = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0 && maxOdd <= array[i])
                {                    
                   maxOdd = array[i];
                   maxOddIndex = i;                    
                }
            }
            if (maxOddIndex > -1) result = maxOddIndex.ToString();
            else result = "No matches";
            return result;
        }
 
        static string MaxEven(int[] array)
        {
            string result = "";
            int maxEven = int.MinValue;
            int maxEvenIndex = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0 && maxEven <= array[i])
                {
                        maxEven = array[i];
                        maxEvenIndex = i;
                }
            }
            if (maxEvenIndex > -1) result = maxEvenIndex.ToString();
            else result = "No matches";
            return result;
        }
 
        static string MinEven(int[] array)
        {
            string result = "";
            int minEven = int.MaxValue;
            int minEvenIndex = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0 && minEven >= array[i])
                {
                        minEven = array[i];
                        minEvenIndex = i;
                }
            }
            if (minEvenIndex > -1) result = minEvenIndex.ToString();
            else result = "No matches";
            return result;
        }
 
        static string MinOdd(int[] array)
        {
            string result = "";
            int minOdd = int.MaxValue;
            int minOddIndex = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0 && minOdd >= array[i])
                {
                        minOdd = array[i];
                        minOddIndex = i;
                }
            }
            if (minOddIndex > -1) result = minOddIndex.ToString();
            else result = "No matches";
            return result;
        }
 
        static string FirstOdd(string count, int[] array)
        {
            int maxLength = int.Parse(count);
            if (maxLength > array.Length) return "Invalid count";
            int[] values = new int[maxLength];
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    values[sum] = array[i];
                    sum++;
                }
                if (sum >= maxLength) break;
            }
            if (sum < maxLength) Array.Resize(ref values, sum);
            return "[" + string.Join(", ", values) + "]";
        }
 
        static string FirstEven(string count, int[] array)
        {
            int maxLength = int.Parse(count);
            if (maxLength > array.Length) return "Invalid count";
            int[] values = new int[maxLength];
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    values[sum] = array[i];
                    sum++;
                }
                if (sum >= maxLength) break;
            }
            if (sum < maxLength) Array.Resize(ref values, sum);
            return "[" + string.Join(", ", values) + "]";
        }
 
        static string LastEven(string count, int[] array)
        {
            int maxLength = int.Parse(count);
            if (maxLength > array.Length) return "Invalid count";
            int[] values = new int[maxLength];
            int sum = 0;
            for (int i = array.Length-1; i >=0; i--)
            {
                if (array[i] % 2 == 0)
                {
                    values[sum] = array[i];
                    sum++;
                }
                if (sum >= maxLength) break;
            }
            if (sum < maxLength) Array.Resize(ref values, sum);
            Array.Reverse(values);
            return "[" + string.Join(", ", values) + "]";
        }
 
        static string LastOdd(string count, int[] array)
        {
            int maxLength = int.Parse(count);
            if (maxLength > array.Length) return "Invalid count";
            int[] values = new int[maxLength];
            int sum = 0;
            for (int i = array.Length-1; i >=0; i--)
            {
                if (array[i] % 2 != 0)
                {
                    values[sum] = array[i];
                    sum++;
                }
                if (sum >= maxLength) break;
            }
            if (sum < maxLength) Array.Resize(ref values, sum);
            Array.Reverse(values);
            return "[" + string.Join(", ", values) + "]";
        }
    }
}

*/

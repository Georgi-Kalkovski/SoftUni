using System;
using System.Linq;
using System.Collections.Generic;

namespace Anonymous_Threat
{
    class Program
    {
        public static void Merge(List<string> input, string[] command)
        {
            var temp = "";
            var len = input.Count;
            var start = int.Parse(command[1]);
			
            if (start < 0)
            {
                start = 0;
            }
			
            else if (start > len - 1)
            {
                start = len - 1;
            }
			
            var end = int.Parse(command[2]);
			
            if (end < 0)
            {
                end = 0;
            }
			
            else if (end > len - 1)
            {
                end = len - 1;
            }
			
            for (int i = start; i <= end; i++)
            {
                temp += input[i];
            }
			
            var count = end - start + 1;
			
            if (start + count > len)
                count = len - start + 1;
			
            input.RemoveRange(start, count);
            input.Insert(start, temp);
        }
		
        public static void Divide(List<string> input, string[] command)
        {
            var index = int.Parse(command[1]);
            var parts = int.Parse(command[2]);
            var temp = input[index];
            var strLen = temp.Length;
            var firstPart = strLen / parts;
            var lastPart = 0;
			
            if (strLen % parts == 0)
                lastPart = strLen / parts;
			
            else
                lastPart = strLen - (parts - 1) * firstPart;
			
            var arrStr = new string[parts];
            var count = 0;
			
            for (int i = 0; i < (parts - 1) * firstPart; i += firstPart)
            {
                var str = "";
				
                for (int j = 0; j < firstPart; j++)
                {
                    str += temp[i + j];
                }

                arrStr[count] = str;
                count++;
            }
			
            var str1 = "";
			
            for (int i = strLen - lastPart; i <= strLen - 1; i++)
            {
                str1 += temp[i];
            }
			
            arrStr[count] = str1;
            input.RemoveAt(index);
            input.InsertRange(index, arrStr);
        }
		
        static void Main()
        {
            List<string> input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
				
            var command = Console.ReadLine()
               .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .ToArray();
			   
            while (command[0] != "3:1")
            {
                if (command[0] == "merge")
                    Merge(input, command);
				
                else
                    Divide(input, command);
				
                command = Console.ReadLine()
               .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .ToArray();
            }
			
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
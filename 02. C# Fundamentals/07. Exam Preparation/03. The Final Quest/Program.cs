using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
 
class Program
{
    public static List<string> words = new List<string>();
    static void Main()
    {
        words = Console.ReadLine().Split(" ").ToList();
 
        string input;
 
        while ((input = Console.ReadLine()) != "Stop")
        {
            string[] commands = input.Split(" ");
            string command = commands[0];
           
            int index;
            string word, word1, word2;
 
            switch (command)
            {
                case "Delete":
                    index = int.Parse(commands[1]);
                    Delete(index);
                    break;
                case "Swap":
                    word1 = commands[1];
                    word2 = commands[2];
                    Swap(word1, word2);
                    break;
                case "Put":
                    word = commands[1];
                    index = int.Parse(commands[2]);
                    Put(word, index);
                    break;
                case "Sort":
                    words.Sort();
                    words.Reverse();
                    break;
                case "Replace":
                    word1 = commands[1];
                    word2 = commands[2];
                    Replace(word1, word2);
                    break;
 
                default:
                    break;
            }
 
        }
 
        words.ForEach(w => Console.Write(w + " "));
        return;
    }
	
    public static void Delete(int index)
    {
        if (words.Count > index + 1 && index + 1 > -1)
        {
            words.RemoveAt(index + 1);
        }
		
        return;
    }
	
    public static void Swap(string word1, string word2)
    {
        if (words.Contains(word1) && words.Contains(word2))
        {
            int index1 = words.IndexOf(word1);
            int index2 = words.IndexOf(word2);
 
            words[index2] = word1;
            words[index1] = word2;
        }
		
        return;
    }
	
    public static void Put(string word, int index)
    {
        if (/*words.Count > index - 1 && index - 1 > -1*/ index > 0 && index <= words.Count + 1)
        {
            words.Insert(index - 1, word);
        }
		
        return;
    }
	
    public static void Replace(string word1, string word2)
    {
        if (words.Contains(word2))
        {
            words[words.IndexOf(word2)] = word1;
        }
		
        return;
    }
}
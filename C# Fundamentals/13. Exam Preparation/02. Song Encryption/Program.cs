using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Song_Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"((^[A-Z][a-z' ]+):([A-Z ]+)[^a-z#$&]*$)");
            var groups = new List<string>();

            while (true)
            {
                string line = Console.ReadLine();
                string[] input = line.Split(":");
				
                if (input[0] == "end")
                {
                    break;
                }

                Match match = regex.Match(line);

                if (match.Success)
                {
                    var newLine = string.Empty;
                    int keyNum = input[0].Length;
					
                    for(int i =0;i<line.Length;i++)
                    {
                        if (line[i] == ' ' || line[i] == '\'')
                        {
                            newLine += line[i];
                            continue;
                        }
						
                        if (line[i] == ':')
                        {
                            newLine += '@';
                            continue;
                        }
						
                        char newCh = (char)(line[i]+keyNum);

                        if (newCh >= 'a' && newCh <= 'z' && line[i] >= 'a')
                        {
                            newLine += newCh;
                        }
						
                        else if (newCh >= 'A' && newCh <= 'Z' && line[i] <= 'Z')
                        {
                            newLine += newCh;
                        }
						
                        else
                        {
                            newCh -= (char)26;
                            newLine += newCh;
                        }

                    }
					
                    groups.Add("Successful encryption: " + newLine);
                }
				
                else
                {
                    groups.Add("Invalid input!");
                }
            }
			
            foreach (var group in groups)
            {
                Console.WriteLine(group);
            }
        }
    }
}

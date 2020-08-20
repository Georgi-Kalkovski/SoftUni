using System;
using System.Collections.Generic;
using System.Linq;

namespace Messages_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacityOfMessages = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string,List<int>>();
			
            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split("=");
                string command = input[0];
                string username = string.Empty;
				
                if (command != "Statistics")
                {
                    username = input[1];
                }

                if (command == "Statistics")
                {
                    int counter = 0;
                    var newDict = dict.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Key);
					
                    foreach (var user in newDict)
                    {
                        int lastTry = user.Value[0] + user.Value[1];
						
                        if (lastTry >= capacityOfMessages)
                        {
                            Console.WriteLine($"{user.Key} reached the capacity!");
                            dict.Remove(user.Key);
                            continue;
                        }
                        
                        if (counter == 0)
                        {
                            Console.WriteLine($"Users count: {dict.Keys.Count}");
                            counter++;
                        }
						
                        Console.WriteLine($"{user.Key} - {user.Value[0] + user.Value[1]}");
                    }
					
                    break;
                }

                if (command == "Add")
                {
                    if (!dict.ContainsKey(username))
                    {
                        int sent = int.Parse(input[2]);
                        int received = int.Parse(input[3]);
                        var sendReceived = new List<int>();
                        sendReceived.Add(sent);
                        sendReceived.Add(received);
                        dict.Add(username, sendReceived);
                    }
					
                    else
                    {
                        continue;
                    }
                }
				
                else if (command == "Message")
                {
                    string receiver = input[2];
					
                    if (dict.ContainsKey(username) && dict.ContainsKey(receiver))
                    {
                        dict[username][0]++;
                        dict[receiver][1]++;
						
                        if (dict[username][0] == capacityOfMessages)
                        {
                            Console.WriteLine($"{username} reached the capacity!");
                            dict.Remove(username);
                        }
						
                        if (dict[receiver][1] == capacityOfMessages)
                        {
                            Console.WriteLine($"{receiver} reached the capacity!");
                            dict.Remove(receiver);
                        }
                    }
                }
				
                else if (command == "Empty")
                {
                    if (dict.ContainsKey(username))
                    {
                        dict.Remove(username);
                    }
					
                    if (username == "All")
                    {
                        dict.Clear();
                    }
                }
            }
        }
    }
}

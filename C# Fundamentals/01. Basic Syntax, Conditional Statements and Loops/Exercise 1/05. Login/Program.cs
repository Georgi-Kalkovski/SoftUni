using System;

namespace _05._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = string.Empty;
            int counter = 0;

            string user = Console.ReadLine();                                 
            string reverseUserPassword = new string(user.Reverse().ToArray());
            int counter = 0;                                                  

            while (true)                                                      
            {
                string guessingPassword = Console.ReadLine();                 

                if (guessingPassword != reverseUserPassword)                  
                {
                    counter++;                                                

                    if (counter == 4)                                         
                    {
                        Console.WriteLine($"User {user} blocked!");           
                        break;                                                
                    }
					
                    Console.WriteLine($"Incorrect password. Try again.");     
                }

                else if (guessingPassword == reverseUserPassword)             
                {
                    Console.WriteLine($"User {user} logged in.");             
                    break;                                                    
                }
            }
        }
    }
}

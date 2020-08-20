using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Game_Number_Wars
{
    class Program
    {
        static void Main(string[] args)
        {

            string firstPlayer = Console.ReadLine();  
            string secondPlayer = Console.ReadLine(); 
            string input = string.Empty;              
            string secondInput = string.Empty;        
            int firstPlayerSum = 0;                   
            int secondPlayerSum = 0;                  

            while (true)                                                 
            {                                                            
                input = Console.ReadLine();                              
                if (input == "End of game")                              
                {                                                        
                    break;                                               
                }                                                        
                                                                         
                secondInput = Console.ReadLine();                        

                if (secondInput == "End of game")                        
                {                                                        
                    break;                                               
                }                                                        
                                                                         
                int firstPlayerCard = int.Parse(input);                  
                int secondPlayerCard = int.Parse(secondInput);           

                if (firstPlayerCard > secondPlayerCard)                  
                {                                                        
                    firstPlayerSum += firstPlayerCard - secondPlayerCard;
                }                                                        
                                                                         
                else if (firstPlayerCard < secondPlayerCard)             
                {                                                        
                    secondPlayerSum += secondPlayerCard - firstPlayerCard; 
                }                                                          
                                                                           
                else if (firstPlayerCard == secondPlayerCard)              
                {                                                          
                    input = Console.ReadLine();                            
                    secondInput = Console.ReadLine();                      
                    int firstPlayerWar = int.Parse(input);                 
                    int secondPlayerWar = int.Parse(secondInput);          
                    Console.WriteLine("Number wars!");                     

                    if (firstPlayerWar > secondPlayerWar)                                              
                    {                                                                                  
                        Console.WriteLine($"{firstPlayer} is winner with {firstPlayerSum} points");    
                        return;                                                                        
                    }                                                                                  
                                                                                                       
                    else if (firstPlayerWar < secondPlayerWar)                                         
                    {                                                                                  
                        Console.WriteLine($"{secondPlayer} is winner with {secondPlayerSum} points");  
                        return;                                                                        
                    }
                }  
            }
            Console.WriteLine($"{firstPlayer} has {firstPlayerSum} points");      
            Console.WriteLine($"{secondPlayer} has {secondPlayerSum} points");    
        }
    }
}

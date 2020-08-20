using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Basketball_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {

            string tournamentName = Console.ReadLine();  
            int games = int.Parse(Console.ReadLine());   
            double firstTeamWin = 0;                     
            double firstTeamLost = 0;                    
            double gamesCounter = 0;                     

            while (true)                                                  
            {
                if (tournamentName == "End of tournaments")               
                {                                                         
                    break;                                                
                }                                                         
                                                                          
                for (int i = 0; i < games; i++)                           
                {                                                         
                    gamesCounter++;                                       
                    int firstTeamPoints = int.Parse(Console.ReadLine());  
                    int secondTeamPoints = int.Parse(Console.ReadLine()); 

                    if (firstTeamPoints > secondTeamPoints)                                                          
                    {                                                                                                
                        firstTeamWin++;                                                                              
                        int points = firstTeamPoints - secondTeamPoints;                                             
                        Console.WriteLine($"Game {i+1} of tournament {tournamentName}: win with {points} points.");  
                    }                                                                                                
                                                                                                                     
                    else if (firstTeamPoints < secondTeamPoints)                                                     
                    {                                                                                                
                        firstTeamLost++;                                                                             
                        int points = secondTeamPoints - firstTeamPoints;                                             
                        Console.WriteLine($"Game {i+1} of tournament {tournamentName}: lost with {points} points."); 
                    }
                }

                tournamentName = Console.ReadLine();          
                                                              
                if (tournamentName == "End of tournaments")   
                {                                             
                    break;                                    
                }                                             
                                                              
                games = int.Parse(Console.ReadLine());        
                
            }

            double gamesWinPercentage = (firstTeamWin / gamesCounter) * 100;   
            Console.WriteLine($"{gamesWinPercentage:F2}% matches win");        
            double gamesLostPercentage = (firstTeamLost / gamesCounter) * 100; 
            Console.WriteLine($"{gamesLostPercentage:F2}% matches lost");      
        }
    }
}

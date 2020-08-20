using System;

namespace _10._Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());           
            double headSetPrice = double.Parse(Console.ReadLine());       
            double mousePrice = double.Parse(Console.ReadLine());         
            double keyboardPrice = double.Parse(Console.ReadLine());      
            double displayPrice = double.Parse(Console.ReadLine());       

            int trashedHeadset = 0;                                       
            int trashedMouse = 0;                                         
            int trashedKeyboard = 0;                                      
            int trashedDisplay = 0;                                       

            while (lostGamesCount > 0)                                    
            {
                if (lostGamesCount % 2 == 0)                              
                {
                    trashedHeadset++;                                     
                }

                if (lostGamesCount % 3 == 0)                              
                {
                    trashedMouse++;                                       
                }

                if (lostGamesCount % 2 == 0 && lostGamesCount % 3 == 0)   
                {
                    trashedKeyboard++;                                   

                    if (trashedKeyboard % 2 == 0)                        
                    {
                        trashedDisplay++;                                
                    }
                }
				
                lostGamesCount--;                                         
            }

            double rageExpenses =                                         
                (headSetPrice * trashedHeadset) +                         
                (mousePrice * trashedMouse) +                             
                (keyboardPrice * trashedKeyboard) +                       
                (displayPrice * trashedDisplay);                          

            Console.WriteLine($"Rage expenses: {rageExpenses:F2} lv.");   
        }
    }
}
using System;

namespace _09._Padawan_Equip
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyIvanChoHas = double.Parse(Console.ReadLine());                            
            int students = int.Parse(Console.ReadLine());                                         
            double singleSaberPrice = double.Parse(Console.ReadLine());                           
            double singleRobePrice = double.Parse(Console.ReadLine());                            
            double singleBeltPrice = double.Parse(Console.ReadLine());                            
            int freeBeltCounter = 0;                                                              
            int minusBelt = students;            
			
            double totalSabers = (students + Math.Ceiling(students * 0.10)) * singleSaberPrice;   

            double totalRobes = students * singleRobePrice;                                       

            while (minusBelt > 0)                                                                 
            {
                minusBelt -= 6;                                                                   
                freeBeltCounter++;    
				
                if (minusBelt < 0)                                                                
                {
                    freeBeltCounter--;                                                            
                }
            }

            double totalBelts = (students - freeBeltCounter) * singleBeltPrice;                   

            double totalPrice = totalSabers + totalRobes + totalBelts;                            

            if (moneyIvanChoHas >= totalPrice)                                                    
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:F2}lv.");     
            }
			
            else if (moneyIvanChoHas < totalPrice)                                                
            {
                totalPrice -= moneyIvanChoHas;                                                    
                Console.WriteLine($"Ivan Cho will need {totalPrice:F2}lv more.");                 
            }
        }
    }
}
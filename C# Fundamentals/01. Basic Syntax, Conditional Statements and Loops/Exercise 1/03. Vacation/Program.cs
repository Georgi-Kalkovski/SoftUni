using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int group = int.Parse(Console.ReadLine());              
            string type = Console.ReadLine();                       
            string day = Console.ReadLine();                        
            double price = 0;                                       

            switch (day)                                            
            {
                case "Friday":                                      
                    switch (type)                                   
                    {
                        case "Students": price += 8.45; break;      
                        case "Business": price += 10.90; break;     
                        case "Regular": price += 15; break;         
                    }
                    break;                                          

                case "Saturday":                                    
                    switch (type)                                   
                    {
                        case "Students": price += 9.80; break;      
                        case "Business": price += 15.60; break;     
                        case "Regular": price += 20; break;         
                    }
                    break;                                          

                case "Sunday":                                      
                    switch (type)                                   
                    {
                        case "Students": price += 10.46; break;     
                        case "Business": price += 16; break;        
                        case "Regular": price += 22.50; break;      
                    }
                    break;                                          
            }

            if (type == "Students")                                 
            {
                price = price * group;                              

                if (group >= 30)                                    
                {
                    price = price - (price * 0.15);                 
                }
            }

            if (type == "Business")                                 
            {
                if (group >= 100)                                   
                {
                    group -= 10;                                    
                }

                price = price * group;                              
            }

            if (type == "Regular")                                  
            {
                price = price * group;                              

                if (group >= 10 && group <= 20)                     
                {
                    price = price - (price * 0.05);                 
                }
            }

            Console.WriteLine($"Total price: {price:F2}");          

        }
    }
}

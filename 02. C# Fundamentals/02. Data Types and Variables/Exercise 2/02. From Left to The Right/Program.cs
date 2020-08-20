using System;

namespace _02._From_Left_to_The_Right
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());                  

            for (int i = 0; i < n; i++)                             
            {                                                     
                string leftAndRightNumbers = Console.ReadLine();    
                string placeToHoldLeftNum = string.Empty;           
                string placeToHoldRightNum = string.Empty;          
                bool ifEmptySpace = false;                          

                foreach (char character in leftAndRightNumbers)     
                {                                                   
                    if (character == ' ')                           
                    {                                               
                        ifEmptySpace = true;                        
                        continue;                                   
                    }                                             

                    if (ifEmptySpace == false)                      
                    {                                              
                        placeToHoldLeftNum += character.ToString(); 
                        continue;                                   
                    }                                             

                    placeToHoldRightNum += character.ToString();    
                }                                                   

                long trueLeftNum = long.Parse(placeToHoldLeftNum);  
                long trueRightNum = long.Parse(placeToHoldRightNum);

                if (trueLeftNum >= trueRightNum)                    
                {                                                  
                    int leftSum = 0;     
					
                    foreach (char leftChar in placeToHoldLeftNum)   
                    {                                              
                        if (leftChar == '-')                        
                        {                                         
                            continue;                               
                        }   
						
                        leftSum += leftChar - '0';                  
                    }  
					
                    Console.WriteLine(leftSum);                     
                }

                else if (trueLeftNum < trueRightNum)                
                {                                                   
                    int rightSum = 0;      
					
                    foreach (char rightChar in placeToHoldRightNum) 
                    {                                              
                        if (rightChar == '-')                       
                        {                                          
                            continue;                               
                        }    
						
                        rightSum += rightChar - '0';                
                    }    
					
                    Console.WriteLine(rightSum);                    
                }
            }
        }
    }
}

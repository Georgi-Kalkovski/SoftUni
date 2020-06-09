using System;
using System.Linq;

namespace Ladybugs
{
    public class Ladybugs
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());                                 
            int[] field = new int[size];                                              
            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();   

            for (int i = 0; i < field.Length; i++)                                    
            {                                                                         
                if (indexes.Contains(i))                                              
                {                                                                     
                    field[i] = 1;                                                     
                }                                                                     
            }                                                                         

            string[] command = Console.ReadLine().Split();                            

            while (!command[0].Equals("end"))                                         
            {                                                                         
                int ladybugIndex = int.Parse(command[0]);                             
                string direction = command[1];                                        
                int flightLength = int.Parse(command[2]);                             

                if (ladybugIndex < 0 || ladybugIndex >= field.Length)                 
                {                                                                     
                    command = Console.ReadLine().Split();                             
                    continue;                                                         
                }    
				
                else if (field[ladybugIndex] == 0)                                    
                {                                                                     
                    command = Console.ReadLine().Split();                             
                    continue;                                                         
                }      
				
                else if (direction.Equals("right"))                                   
                {                                                                     
                    if (ladybugIndex + flightLength >= field.Length)                  
                    {                                                                 
                        field[ladybugIndex] = 0;                                      
                        command = Console.ReadLine().Split();                         
                        continue;                                                     
                    }           
					
                    else if (flightLength > 0)                                        
                    {                                                                 
                        FlyRight(ladybugIndex, flightLength, field);                  
                    }      
					
                    else if (flightLength < 0)                                        
                    {                                                                 
                        flightLength = Math.Abs(flightLength);   
                        FlyLeft(ladybugIndex, flightLength, field);                   
                    }                                                                 
                }      
				
                else if (direction.Equals("left"))                                    
                {                                                                     
                    if (ladybugIndex - flightLength < 0)                              
                    {                                                                 
                        field[ladybugIndex] = 0;                                      
                        command = Console.ReadLine().Split();                         
                        continue;                                                     
                    }     
					
                    else if (flightLength > 0)                                        
                    {                                                                 
                        FlyLeft(ladybugIndex, flightLength, field);                   
                    }     
					
                    else if (flightLength < 0)                                        
                    {                                                                 
                        flightLength = Math.Abs(flightLength);                        

                        FlyRight(ladybugIndex, flightLength, field);                  
                    }                                                                
                }                                                                     

                command = Console.ReadLine().Split();                                 
            }                                                                         

            Console.WriteLine(string.Join(" ", field));                               
        }                                                                             

        public static void FlyRight(int startIndex, int flyLength, int[] field)       
        {                                                                             
            field[startIndex] = 0;                                                    

            for (int i = startIndex + flyLength; i < field.Length; i += flyLength)    
            {                                                                         
                if (field[i] == 1)                                                    
                {                                                                     
                    continue;                                                         
                }     
				
                else                                                                  
                {                                                                     
                    field[i] = 1;                                                     
                    return;                                                           
                }                                                                     
            }                                                                         
        }                                                                             

        public static void FlyLeft(int startIndex, int flyLength, int[] field)        
        {                                                                             
            field[startIndex] = 0;                                                    

            for (int i = startIndex - flyLength; i >= 0; i -= flyLength)              
            {                                                                         
                if (field[i] == 1)                                                    
                {                                                                     
                    continue;                                                         
                }   
				
                else                                                                  
                {                                                                     
                    field[i] = 1;                                                     
                    return;                                                           
                }
            }
        }
    }
}
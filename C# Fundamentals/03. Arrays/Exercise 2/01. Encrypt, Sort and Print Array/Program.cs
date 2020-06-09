using System;

namespace _01._Encrypt__Sort_and_Print_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int sequenceOfNames = int.Parse(Console.ReadLine());     
            string[] arr = new string[sequenceOfNames];                            
            double[] sumOfNames = new double[sequenceOfNames];                     

            for (int i = 0; i < sequenceOfNames; i++)                              
            {                                                                      
                arr[i] = Console.ReadLine();                                       

                foreach (var j in arr[i])                                          
                {                                                                  
                    if (j == 'a' || j == 'e' || j == 'i' || j == 'o' || j == 'u' ||
                        j == 'A' || j == 'E' || j == 'I' || j == 'O' || j == 'U')  
                    {                                                              
                        sumOfNames[i] += j * arr[i].Length;                        
                    }                                                             

                    else                                                           
                    {                                                              
                        sumOfNames[i] += j / arr[i].Length;                        
                    }                                                              
                }                                                                  
            }       
			
            Array.Sort(sumOfNames); 
			
            foreach (int i in sumOfNames) Console.WriteLine(i + " ");              
        }
    }
}

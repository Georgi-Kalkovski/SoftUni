using System;

namespace _02._Grades
{
    class Program
    {
        static void Main(string[] args)                     
        {                                                  
            PrintInWords(double.Parse(Console.ReadLine())); 
        }       
		
        private static void PrintInWords(double grade)      
        {                                                  

            string gradeInWords = string.Empty;             

            if (grade >= 2.00 && grade <= 2.99)             
            {                                              
                gradeInWords = "Fail";                      
            }   
			
            if (grade >= 3.00 && grade <= 3.49)             
            {                                               
                gradeInWords = "Poor";                      
            }  
			
            if (grade >= 3.50 && grade <= 4.49)             
            {                                              
                gradeInWords = "Good";                      
            }   
			
            if (grade >= 4.50 && grade <= 5.49)             
            {                                             
                gradeInWords = "Very good";                 
            }   
			
            if (grade >= 5.50 && grade <= 6.00)             
            {                                              
                gradeInWords = "Excellent";                 
            }                                               

            Console.WriteLine(gradeInWords);                

        }

    }
}

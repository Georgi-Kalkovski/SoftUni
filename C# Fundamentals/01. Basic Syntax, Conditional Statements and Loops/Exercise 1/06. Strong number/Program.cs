using System;

namespace _06._Strong_number
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();   
            int total = 0;                        

            foreach (char ch in number)           
            {
                int num = ch - 48;                
                int factoriel = 1;                

                for (var i = 1; i <= num; i++)    
                {
                    factoriel *= i;               
                }

                total += factoriel;               
            }

            int stringToNum = int.Parse(number);  

            if (stringToNum == total)             
            {
                Console.WriteLine("yes");         
            }

            else if (stringToNum != total)        
            {
                Console.WriteLine("no");          
            }
        }
    }
}

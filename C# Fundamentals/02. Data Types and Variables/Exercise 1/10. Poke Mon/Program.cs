using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {

            int pokePower = int.Parse(Console.ReadLine());        
            int targetsDistance = int.Parse(Console.ReadLine());  
            int exaustionFactor = int.Parse(Console.ReadLine());  

            double halfPoke = pokePower * 0.5;                    
            int targetsCounter = 0;                               

            while (pokePower >= targetsDistance)                  
            {                                                     
                targetsCounter++;                                 
                pokePower -= targetsDistance;                     

                if (halfPoke == pokePower && exaustionFactor != 0)
                {                                                 
                    pokePower /= exaustionFactor;                 
                }                                                 
            }  
			
            Console.WriteLine($"{pokePower}");                    
            Console.WriteLine(targetsCounter);                    
        }
    }
}

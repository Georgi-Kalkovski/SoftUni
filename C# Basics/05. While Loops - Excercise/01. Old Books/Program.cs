using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {

            string theBook = Console.ReadLine();
            int capacity = int.Parse(Console.ReadLine());

            string search = string.Empty;
            int searchCount = 0;

            while (theBook != search)
            {
                search = Console.ReadLine();
                searchCount++;
				
                if (capacity <= searchCount)
                    break;
            }
			
            if (theBook == search)
            {
                Console.WriteLine($"You checked {searchCount-1} books and found it.");
            }
			
            else if (capacity == searchCount)
            {
                Console.WriteLine($"The book you search is not here!");
                Console.WriteLine($"You checked {searchCount} books.");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.On_Time_for_the_Exam
{
    class Program
    {
        static void Main(string[] args)
        {

            int examHour = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int arriveHour = int.Parse(Console.ReadLine());
            int arriveMinutes = int.Parse(Console.ReadLine());

            int examHourToMinutes = (examHour * 60) + examMinutes;
            int arriveHourToMinutes = (arriveHour * 60) + arriveMinutes;

            int difference =Math.Abs(examHourToMinutes - arriveHourToMinutes);
            int hoursCount = 0;


            if (examHourToMinutes == arriveHourToMinutes)
            {
                Console.WriteLine("On time");
            }


            else if (examHourToMinutes > arriveHourToMinutes)
            {
                if (difference <= 30)
                {
                    Console.WriteLine("On time");
                    Console.WriteLine($"{difference} minutes before the start");
                }

                else if (difference > 30 && difference < 60)
                {
                    Console.WriteLine("Early");
                    Console.WriteLine($"{difference} minutes before the start");
                }

                else if (difference >= 60 && difference < 120)
                {
                    difference = difference - 60;
                    hoursCount+= 1;
                    Console.WriteLine("Early");

                    if (difference < 10)
                    {
                        Console.WriteLine($"{hoursCount}:0{difference} hours before the start");
                    }

                    else
                    {
                        Console.WriteLine($"{hoursCount}:{difference} hours before the start");
                    }
                }

                else if (difference >= 120 && difference < 180)
                {
                    difference = difference - 120;
                    hoursCount+= 2;
                    Console.WriteLine("Early");

                    if (difference < 10)
                    {
                        Console.WriteLine($"{hoursCount}:0{difference} hours before the start");
                    }

                    else
                    {
                        Console.WriteLine($"{hoursCount}:{difference} hours before the start");
                    }
                }

                else if (difference >= 180 && difference < 240)
                {
                    difference = difference - 180;
                    hoursCount += 3;
                    Console.WriteLine("Early");

                    if (difference < 10)
                    {
                        Console.WriteLine($"{hoursCount}:0{difference} hours before the start");
                    }

                    else
                    {
                        Console.WriteLine($"{hoursCount}:{difference} hours before the start");
                    }
                }
            }


            else if (examHourToMinutes < arriveHourToMinutes)
            {
                if (difference < 60)
                {
                    Console.WriteLine("Late");
                    Console.WriteLine($"{difference} minutes after the start");
                }

                else if (difference >= 60 && difference < 120)
                {
                    difference = difference - 60;
                    hoursCount += 1;
                    Console.WriteLine("Late");

                    if (difference < 10)
                    {
                        Console.WriteLine($"{hoursCount}:0{difference} hours after the start");
                        
                    }

                    else
                    {
                        Console.WriteLine($"{hoursCount}:{difference} hours after the start");
                    }
                }

                else if (difference >= 120 && difference < 180)
                {
                    difference = difference - 120;
                    hoursCount += 2;
                    Console.WriteLine("Late");

                    if (difference < 10)
                    {
                        Console.WriteLine($"{hoursCount}:0{difference} hours after the start");
                    }

                    else
                    {
                        Console.WriteLine($"{hoursCount}:{difference} hours after the start");
                    }
                }

                else if (difference >= 180 && difference < 240)
                {
                    difference = difference - 180;
                    hoursCount += 3;
                    Console.WriteLine("Late");

                    if (difference < 10)
                    {
                        Console.WriteLine($"{hoursCount}:0{difference} hours after the start");
                    }

                    else
                    {
                        Console.WriteLine($"{hoursCount}:{difference} hours after the start");
                    }
                }
            }
        }
    }
}

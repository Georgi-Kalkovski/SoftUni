using System;

namespace Chronometer
{
    class Program
    {
        static void Main(string[] args)
        {
            var chronometer = new Chronometer();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "start")
                {
                    chronometer.Start();
                }
                else if (input == "stop")
                {
                    chronometer.Stop();
                }
                else if (input == "lap")
                {
                    Console.WriteLine(chronometer.Lap());
                }
                else if (input == "laps")
                {
                    Console.WriteLine(chronometer.GetLaps());
                }
                else if (input == "time")
                {
                    Console.WriteLine(chronometer.GetTime);
                }
                else if (input == "reset")
                {
                    chronometer.Reset();
                }
                else if (input == "exit")
                {
                    break;
                }
            }
        }
    }
}

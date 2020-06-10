using MXGP.IO.Contracts;
using MXGP.IO;
using System;

namespace MXGP.Core.Contracts
{
    public class IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IChampionshipController controller;

        public IEngine()
        {
            this.writer = new ConsoleWriter();
            this.reader = new ConsoleReader();
            this.controller = new ChampionshipController();
        }
        public void Run()
        {     

            while (true)
            {
                var input = reader.ReadLine();
                if (input == "End")
                {
                    Environment.Exit(0);
                }
                var args = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    if (args[0] == "CreateRider")
                    {
                        writer.WriteLine(controller.CreateRider(args[1]));
                    }
                    else if (args[0] == "CreateMotorcycle")
                    {
                        writer.WriteLine(controller.CreateMotorcycle(args[1], args[2],int.Parse(args[3])));
                    }
                    else if (args[0] == "AddMotorcycleToRider")
                    {
                        writer.WriteLine(controller.AddMotorcycleToRider(args[1], args[2]));
                    }
                    else if (args[0] == "AddRiderToRace")
                    {
                        writer.WriteLine(controller.AddRiderToRace(args[1], args[2]));
                    }
                    else if (args[0] == "CreateRace")
                    {
                        writer.WriteLine(controller.CreateRace(args[1],int.Parse(args[2])));
                    }
                    else if (args[0] == "StartRace")
                    {
                        writer.WriteLine(controller.StartRace(args[1]));
                    }
                }                
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                    //writer.WriteLine(ex.ToString());
                }
            }
        }
    }
}

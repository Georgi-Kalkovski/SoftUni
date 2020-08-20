namespace SantaWorkshop.Core
{
    using System;

    using SantaWorkshop.IO;
    using SantaWorkshop.IO.Contracts;
    using SantaWorkshop.Core.Contracts;

    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IController controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            //this.controller = new Controller();
        }

        public void Run()
        {
            while (true)
            {
                string[] input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                //try
                //{
                string result = string.Empty;

                if (input[0] == "AddDwarf")
                {
                    string dwarfType = input[1];
                    string dwarfName = input[2];

                    result = controller.AddDwarf(dwarfType, dwarfName);
                }
                else if (input[0] == "AddPresent")
                {
                    string presentName = input[1];
                    int energyRequired = int.Parse(input[2]);

                    result = controller.AddPresent(presentName, energyRequired);
                }
                else if (input[0] == "AddInstrumentToDwarf")
                {
                    string dwarfname = input[1];
                    int power = int.Parse(input[2]);

                    result = controller.AddInstrumentToDwarf(dwarfname, power);
                }
                else if (input[0] == "CraftPresent")
                {
                    string presentName = input[1];

                    result = controller.CraftPresent(presentName);
                }
                else if (input[0] == "Report")
                {
                    result = controller.Report();
                }

                writer.WriteLine(result);
                //}
                //catch (Exception ex)
                //{
                //    writer.WriteLine(ex.Message);
                //}
            }
        }
    }
}

using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Models.Presents;
using SantaWorkshop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private DwarfRepository dwarfs;
        private PresentRepository presents;
        private int counter = 0;

        public Controller()
        {
            this.dwarfs = new DwarfRepository();
            this.presents = new PresentRepository();
        }

        public string AddDwarf(string dwarfType, string dwarfName)
        {
            switch (dwarfType)
            {
                case "HappyDwarf":
                    dwarfs.Add(new HappyDwarf(dwarfName));
                    return $"Successfully added {dwarfType} named {dwarfName}.";

                case "SleepyDwarf":
                    dwarfs.Add(new SleepyDwarf(dwarfName));
                    return $"Successfully added {dwarfType} named {dwarfName}.";
            }
            return "Invalid dwarf type.";
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            var instrument = new Instrument(power);

            foreach (var dwarf in dwarfs.Models)
            {
                if (dwarf.Name == dwarfName)
                {
                    dwarf.AddInstrument(instrument);
                    return $"Successfully added instrument with power {power} to dwarf {dwarfName}!";
                }
            }
            return "The dwarf you want to add an instrument to doesn't exist!";
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            presents.Add(new Present(presentName, energyRequired));
            return $"Successfully added Present: {presentName}!";
        }

        public string CraftPresent(string presentName)
        {
            foreach (var present in presents.Models)
            {
                if (present.Name == presentName)
                {
                    foreach (var dwarf in dwarfs.Models.Where(x => x.Energy >= 50))
                    {
                        while (dwarf.Energy != 0 && dwarf.Instruments.Count != 0)
                        {
                            foreach (var instrument in dwarf.Instruments)
                            {
                                dwarf.Work();
                                if (instrument.Power <= 0)
                                {
                                    instrument.IsBroken();
                                }
                            }
                        }
                        if (present.IsDone())
                        {
                            counter++;
                            return $"Present {presentName} is done.";
                        }
                        else
                        {
                            return $"Present {presentName} is not done.";
                        }
                    }
                }
            }
            return "There is no dwarf ready to start crafting!";
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{counter} presents are done!");
            sb.AppendLine("Dwarfs info:");
            foreach (var dwarf in dwarfs.Models)
            {
                sb.AppendLine($"Name: { dwarf.Name}");
                sb.AppendLine($"Energy: { dwarf.Energy}");
                sb.AppendLine($"Instruments { dwarf.Instruments.Count} not broken left");
            }

            return sb.ToString().TrimEnd();
        }

        public void Exit()
        {
            return;
        }
    }
}

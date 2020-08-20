using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private Garage garage;
        private List<IProcedure> procedure;
        private bool chipped;
        private Chip chip;

        public Controller()
        {
            this.garage = new Garage();
            procedure = new List<IProcedure>();
            chip = new Chip();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            switch (robotType)
            {
                case "HouseholdRobot":
                    {
                        garage.Manufacture(new HouseholdRobot(name, energy, happiness, procedureTime));
                        return String.Format(OutputMessages.RobotManufactured, name);
                    }
                case "PetRobot":
                    {
                        garage.Manufacture(new PetRobot(name, energy, happiness, procedureTime));
                        return String.Format(OutputMessages.RobotManufactured, name);
                    }
                case "WalkerRobot":
                    {
                        garage.Manufacture(new WalkerRobot(name, energy, happiness, procedureTime));
                        return String.Format(OutputMessages.RobotManufactured, name);
                    }
                default: throw new ArgumentException(String.Format(ExceptionMessages.InvalidRobotType, robotType));
            }
        }

        public string Chip(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            chip.DoService(garage.Robots.FirstOrDefault(x => x.Key == robotName).Value, procedureTime);
            return String.Format(OutputMessages.ChipProcedure, robotName);
        }

        public string Charge(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            chip.DoService(garage.Robots.FirstOrDefault(x => x.Key == robotName).Value, procedureTime);
            return String.Format(OutputMessages.ChargeProcedure, robotName);
        }

        public string History(string procedureType)
        {
            var sb = new StringBuilder();
            sb.AppendLine(procedureType);
            foreach (var robot in procedure)
            {
                sb.AppendLine(robot.History());
            }
            return sb.ToString().Trim();
        }

        public string Polish(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            Polish chip = new Polish();
            chip.DoService(garage.Robots.FirstOrDefault(x => x.Key == robotName).Value, procedureTime);
            return String.Format(OutputMessages.PolishProcedure, robotName);
        }

        public string Rest(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            Rest chip = new Rest();
            chip.DoService(garage.Robots.FirstOrDefault(x => x.Key == robotName).Value, procedureTime);
            return String.Format(OutputMessages.RestProcedure, robotName);
        }

        public string Sell(string robotName, string ownerName)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            var robot = garage.Robots.FirstOrDefault(x => x.Key == robotName).Value;
            garage.Sell(robotName, ownerName);
            if (chip.Chipped == true)
                return String.Format(OutputMessages.SellChippedRobot, ownerName);
            else
                return String.Format(OutputMessages.SellNotChippedRobot, ownerName);

        }

        public string TechCheck(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            TechCheck chip = new TechCheck();
            chip.DoService(garage.Robots.FirstOrDefault(x => x.Key == robotName).Value, procedureTime);
            return String.Format(OutputMessages.TechCheckProcedure, robotName);
        }

        public string Work(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            Work chip = new Work();
            chip.DoService(garage.Robots.FirstOrDefault(x => x.Key == robotName).Value, procedureTime);
            return String.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
        }
    }
}

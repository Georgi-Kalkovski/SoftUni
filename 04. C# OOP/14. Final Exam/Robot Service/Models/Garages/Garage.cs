using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private Dictionary<string, IRobot> robots;
        private int capacity = 10;
        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }

        public IReadOnlyDictionary<string, IRobot> Robots => robots;

        public void Manufacture(IRobot robot)
        {
            if (capacity == 0)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.NotEnoughCapacity));
            }
            if (robots.ContainsKey(robot.Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingRobot, robot.Name));
            }

            robots.Add(robot.Name, robot);
            capacity--;
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            var robot = robots.FirstOrDefault(x => x.Key == robotName);
            robot.Value.Owner = ownerName;

        }
    }
}

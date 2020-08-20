using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        private List<IRobot> robots;

        protected Procedure()
        {
            this.robots = new List<IRobot>();
        }

        public string History()
        {
            var sb = new StringBuilder();
            foreach (var robot in robots)
            {
                sb.AppendLine(String.Format(OutputMessages.RobotInfo, robot.GetType().Name, robot.Name, robot.Happiness, robot.Energy));
            }
            return sb.ToString().Trim();
        }

        public abstract void DoService(IRobot robot, int procedureTime);
        //{
        //    if (robot.ProcedureTime < procedureTime)
        //    {
        //        throw new ArgumentException(String.Format(ExceptionMessages.InsufficientProcedureTime));
        //    }
        //}
    }
}

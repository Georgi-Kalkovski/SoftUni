using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public class Rest : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InsufficientProcedureTime));
            }
            robot.Happiness -= 3;
            robot.Energy += 10;
        }
    }
}

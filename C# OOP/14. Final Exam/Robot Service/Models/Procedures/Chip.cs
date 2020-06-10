using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public class Chip : Procedure
    {
        private bool chipped;
        public bool Chipped
        { 
            get => false;
            protected set => chipped = value;
        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InsufficientProcedureTime));
            }
            if (Chipped == false)
            {
                robot.Happiness -= 5;
                Chipped = true;
            }
            if (Chipped == true)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.AlreadyChipped, robot.Name));
            }


        }
    }
}

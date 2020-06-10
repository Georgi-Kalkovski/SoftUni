using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Robots
{
    public abstract class Robot : IRobot
    {
        private string name;
        private int energy;
        private int happiness;
        private int procedureTime;

        protected Robot(string name, int energy, int happiness, int procedureTime)
        {
            Name = name;
            Energy = energy;
            Happiness = happiness;
            ProcedureTime = procedureTime;
            Owner = "Service";
            IsBought = false;
            IsChipped = false;
            IsChecked = false;
        }
        public string Name
        {
            get => name;
            private set
            {
                name = value;
            }
        }

        public int Happiness 
        { 
            get => happiness;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidHappiness));
                }
                happiness = value;
            }
        }
        public int Energy 
        {
            get => energy;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidEnergy));
                }
                energy = value;
            }
        }
        public int ProcedureTime 
        {
            get => procedureTime; 
            set => procedureTime = value;
        }
        private string owner;
        private bool isBought;
        private bool isChipped;
        private bool isChecked;
        public string Owner
        {
            get => owner;
            set
            {
                owner = value;
            }
        }
        public bool IsBought
        {
            get => isBought;
            set
            {
                isBought = value;
            }
        }
        public bool IsChipped
        {
            get => isChipped;
            set
            {
                isChipped = value;
            }
        }
        public bool IsChecked
        {
            get => isChecked;
            set
            {
                isChecked = value;
            }
        }

        public override string ToString()
        {
            return String.Format(OutputMessages.RobotInfo, GetType().Name, Name, Happiness.ToString(), Energy.ToString());
        }
    }
}

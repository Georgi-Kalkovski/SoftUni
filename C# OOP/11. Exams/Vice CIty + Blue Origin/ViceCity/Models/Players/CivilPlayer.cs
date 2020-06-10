using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Players
{
    public class CivilPlayer : Player, IPlayer
    {
        private const int CivilPlayerInitialLifePoints = 50;
        public CivilPlayer(string name) 
            : base(name, CivilPlayerInitialLifePoints)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Players
{
    public class MainPlayer : Player, IPlayer
    {
        private const string MainPlayerName = "Tommy Vercetti";
        private const int MainPlayerInitialLifePoints = 100;
        public MainPlayer() 
            : base(MainPlayerName, MainPlayerInitialLifePoints)
        {
        }
    }
}

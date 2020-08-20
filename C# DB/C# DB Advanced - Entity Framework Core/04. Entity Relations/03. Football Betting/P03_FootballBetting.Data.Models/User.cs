using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class User
    {
        public User()
        {
            this.Bets = new HashSet<Bet>();
        }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } 
        public string Email { get; set; } 
        public string Name { get; set; }
        public decimal Balance { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
    }
}

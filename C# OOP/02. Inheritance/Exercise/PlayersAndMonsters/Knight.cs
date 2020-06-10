namespace PlayersAndMonsters
{
    public class Knight : Hero
    {
        public Knight(string username, int level)
            : base(username, level)
        {
            base.Username = username;
            base.Level = level;
        }
    }
}

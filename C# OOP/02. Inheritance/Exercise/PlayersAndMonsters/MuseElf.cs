namespace PlayersAndMonsters
{
    public class MuseElf : Elf
    {
        public MuseElf(string username, int level)
            : base(username, level)
        {
            base.Username = username;
            base.Level = level;
        }
    }
}

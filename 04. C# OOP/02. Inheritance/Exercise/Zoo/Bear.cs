namespace Zoo
{
    public class Bear : Mammal
    {
        public Bear(string name)
            : base(name)
        {
            base.Name = name;
        }
    }
}

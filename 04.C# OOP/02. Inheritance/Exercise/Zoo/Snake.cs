namespace Zoo
{
    public class Snake : Reptile
    {
        public Snake(string name)
            : base(name)
        {
            base.Name = name;
        }
    }
}

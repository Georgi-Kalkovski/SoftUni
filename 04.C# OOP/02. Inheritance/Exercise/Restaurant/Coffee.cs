namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public double Caffeine { get; set; }
        public Coffee(string name, double caffeine)
            : base(name, 3.50m, 50)
        {
            Caffeine = caffeine;
        }
    }
}

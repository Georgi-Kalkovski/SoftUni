namespace Christmas
{
    public class Present
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public string Gender { get; set; }

        public Present(string name, double weight, string gender)
        {
            this.Name = name;
            this.Weight = weight;
            this.Gender = gender;
        }

        public override string ToString()
        {
            return $"Present {this.Name} ({this.Weight}) for a {this.Gender}";
        }
    }
}
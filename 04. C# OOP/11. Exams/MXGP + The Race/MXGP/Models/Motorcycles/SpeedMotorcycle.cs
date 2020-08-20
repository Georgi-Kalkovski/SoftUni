namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        public SpeedMotorcycle(string model, int horsePower) 
            : base(model, horsePower, 125,50,69)
        {
        }
    }
}

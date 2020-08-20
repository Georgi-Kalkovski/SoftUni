
namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {         
        public PowerMotorcycle(string model, int horsePower) 
            : base(model, horsePower, 450,70,100)
        {
        }
    }
}

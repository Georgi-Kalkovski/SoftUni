
namespace FerrariCar
{
    public class Ferrari : ICarInfo
    {
        string carModel = "488-Spider";
        string driver;
        string brakes = "Brakes!";
        string gasPedal = "Gas!";

        public Ferrari(string driver)
        {
            CarModel = carModel;
            Driver = driver;
            Brakes = brakes;
            GasPedal = gasPedal;
        }

        public string CarModel
        {
            get { return carModel; }
            set { carModel = value; }
        }
        public string Driver
        {
            get { return driver; }
            set { driver = value; }
        }
        public string Brakes
        {
            get { return brakes; }
            set { brakes = value; }
        }
        public string GasPedal
        {
            get { return gasPedal; }
            set { gasPedal = value; }
        }

        public override string ToString()
        {
            return $"{CarModel}/{Brakes}/{GasPedal}/{Driver}";
        }
    }
}
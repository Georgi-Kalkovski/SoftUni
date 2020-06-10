using ViceCity.Core.Factories.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Core.Factories
{
    public class GunFactory : IGunFactory
    {
        public IGun CreateGun(string type, string name)
        {
            IGun gun = null;

            switch (type)
            {
                case "Pistol":
                    gun = new Pistol(name);
                    break;
                case "Rifle":
                    gun = new Rifle(name);
                    break;
            }

            return gun;
        }
    }
}

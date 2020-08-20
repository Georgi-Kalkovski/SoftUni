using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Core.Factories.Contracts
{

    public interface IGunFactory
    {
        IGun CreateGun(string type, string name);
    }
}

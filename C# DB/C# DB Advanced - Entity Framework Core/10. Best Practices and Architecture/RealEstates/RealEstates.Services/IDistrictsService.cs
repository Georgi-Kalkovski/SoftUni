using RealEstates.Services.Models;
using System.Collections.Generic;

namespace RealEstates.Services
{
    public interface IDistrictsService
    {
        IEnumerable<DistrictViewModel> GetTopDistrictsByAveragePrice(int count = 10);

        IEnumerable<DistrictViewModel> GetTopDistrictsByNumberOfProperties(int count = 10);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using YamlDeploymentWeb.Models;

namespace YamlDeploymentWeb.Services
{
    public interface IBikesService
    {
        Task<List<BikeDto>> GetBikes();
        Task AddBike(BikeDto bike);
        Task UpdateBike(BikeDto bike);
        Task RemoveBike(int id);
    }
}

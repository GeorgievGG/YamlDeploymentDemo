using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using YamlDeploymentDomain;
using YamlDeploymentInfrastructure;

namespace YamlDeploymentAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BikeController : ControllerBase
    {
        private readonly BikeDbContext dbContext;

        public BikeController(BikeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await dbContext.Bikes.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post(Bike bike)
        {
            var entity = await dbContext.Bikes.SingleOrDefaultAsync(x => x.Id == bike.Id);
            if (entity == null)
            {
                await dbContext.Bikes.AddAsync(bike);
            }
            else
            {
                entity.Name = bike.Name;
                entity.Price = bike.Price;
                entity.RentedUntil = bike.RentedUntil;
                dbContext.Bikes.Update(entity);
            }

            await dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await dbContext.Bikes.SingleOrDefaultAsync(x => x.Id == id);

            dbContext.Bikes.Remove(entity);

            await dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}

using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using YamlDeploymentInfrastructure;

namespace YamlDeploymentFunctions
{
    public class StolenBikeCheckFunction
    {
        private readonly BikeDbContext dbContext;

        public StolenBikeCheckFunction(BikeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [FunctionName("StolenBikeCheckFunction")]
        public void Run([TimerTrigger("%StolenBikeCheckFunctionInterval%", RunOnStartup = true)]TimerInfo myTimer, ILogger log)
        {
            var stolenBikes = dbContext.Bikes.Where(x => x.RentedUntil.AddHours(4) <= DateTime.UtcNow && x.Available == false);
            foreach (var stolenBike in stolenBikes)
            {
                log.LogWarning($"Bike {stolenBike.Id}/{stolenBike.Name} was stolen!");
            }
        }
    }
}

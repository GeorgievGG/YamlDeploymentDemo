using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using YamlDeploymentDomain;

namespace YamlDeploymentInfrastructure
{
    public class InMemoryContext
    {
        public static BikeDbContext GetContext()
        {
            var options = new DbContextOptionsBuilder<BikeDbContext>().UseInMemoryDatabase("InMemDb").Options;
            var context = new BikeDbContext(options);

            context.SaveChanges();

            return context;
        }

        public static int InsertBike(BikeDbContext context, Bike bike)
        {
            context.Bikes.Add(bike);
            context.SaveChanges();

            return bike.Id;
        }
    }
}

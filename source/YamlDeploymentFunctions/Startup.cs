using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using YamlDeploymentInfrastructure;

namespace YamlDeploymentFunctions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddDbContext<BikeDbContext>(
                options => options.UseSqlServer(Environment.GetEnvironmentVariable("Db_Connection_String")));
        }
    }
}

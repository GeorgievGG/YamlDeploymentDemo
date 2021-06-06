using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YamlDeploymentInfrastructure;

namespace YamlDeploymentFunctions
{
    public class Startup : FunctionsStartup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddDbContext<BikeDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("Db_Connection_String")));
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TaskerProject.Main.Configuration
{
    public static class ConfigureServices
    {
        internal static void AddConfigDependencies(IServiceCollection services, ConfigurationManager configuration)
        {
            // services.Configure<JobsPublisherAPIClientConfiguration>(configuration.GetSection("JobsPublisherAPIConfiguration"));
        }

        internal static void AddServiceDependencies(IServiceCollection services)
        {
            //  services.AddTransient<IAlertService, AlertService>();
        }

        internal static void AddGatewayDependencies(IServiceCollection services, ConfigurationManager configuration)
        {
            //services.AddTransient<ISignUpLeadsGateway, SignUpLeadsGateway>();
            //services.AddDbContext<SignUpLeadsContext>(options => options.UseSqlServer(configuration["ConnectionStrings:BillPayLeads"]));
        }

        internal static void AddAPIClientDependencies(IServiceCollection services)
        {
            //    services.AddTransient<IJobsPublisherAPIClient, JobsPublisherAPIClient>();
        }

        internal static void AddAutoMapperProfiles(IServiceCollection services)
        {
            //   services.AddAutoMapper(typeof(LowBalanceAlertProfile));
        }
    }
}

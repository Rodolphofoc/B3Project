using B3Project.Applications.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CrossCuting
{
    public static class ServicesDependencyInjection
    {
        private const string applicationProjectName = "B3Project.Applications";


        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            var assembly = Assembly.Load(applicationProjectName);
            services.AddAutoMapper(assembly);
            services.AddMediatr();
            services.AddSingleton(new TaxServices()
            {
                Cdi = Convert.ToDouble(Environment.GetEnvironmentVariable("CDI")),
                TB = Convert.ToDouble(Environment.GetEnvironmentVariable("TB")),
                UntilSixMonth = Convert.ToDouble(Environment.GetEnvironmentVariable("UntilSixMonth")),
                UntilOneYear = Convert.ToDouble(Environment.GetEnvironmentVariable("UntilOneYear")),
                UntilTwoYear = Convert.ToDouble(Environment.GetEnvironmentVariable("UntilTwoYear")),
                MoreTwoYear = Convert.ToDouble(Environment.GetEnvironmentVariable("MoreThreeYear"))
            });

            return services;

        }



        private static void AddMediatr(this IServiceCollection services)
        {
            var assembly = Assembly.Load(applicationProjectName);
            services.AddMediatR(assembly);
        }

    }
}

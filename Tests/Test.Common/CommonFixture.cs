using AuctriaProject.Application.Interfaces.Persistence;
using AuctriaProject.Application.Interfaces.Services;
using AuctriaProject.Application.Services;
using AuctriaProject.Infrastructure.Data;
using AuctriaProject.Infrastructure.Interfaces;
using AuctriaProject.Infrastructure.Repositories;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Data;
using System.Reflection;
using System.Text.Json;
using Tests.Common.Models;

namespace Tests.Common
{
    public class CommonFixture
    {
        public CommonFixture()
        {
            string? path = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location ?? "");
            if (string.IsNullOrEmpty(path))
                throw new InvalidDataException();

            var builder = new ConfigurationBuilder()
                                          .SetBasePath(path)
                                          .AddJsonFile($"appsettings.json", false);

            var Configuration = builder.Build();

            var services = new ServiceCollection();

            #region Configuration

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddOptions();
            var sectionAppSettings = Configuration.GetSection("ConnectionStrings");
            services.Configure<ConnectionStrings>(sectionAppSettings);
            var config = new ConnectionStrings();
            Configuration.Bind("ConnectionStrings", config);
            services.AddSingleton(config);

            #endregion Configuration

            FinalizeSetup(services);

            ServiceProvider = services.BuildServiceProvider();
        }

        public void FinalizeSetup(IServiceCollection services)
        {
            services.AddScoped<ISharedContext, SharedContext>();
            services.AddScoped<IUserAuthenticationRepository, UserAuthenticationRepository>();
            services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IShoppingCardRepository, ShoppingCardRepository>();
            services.AddScoped<IShoppingCardService, ShoppingCardService>();
        }

        public ServiceProvider ServiceProvider { get; private set; }
    }
}
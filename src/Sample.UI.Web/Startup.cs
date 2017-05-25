using System.IO;
using System.Linq;
using System.Reflection;
using AutoMapper;
using MessagePack.AspNetCoreMvcFormatter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sample.App.Web;
using Sample.Infra.CsvEntity;
using Sample.Infra.EF.DataContext;
using Sample.Infra.EF.Model;
using Sample.Infra.Interface.AppContext;
using Sample.UI.Web.Filters;
using Sample.UI.Web.Formatters;
using Sample.UI.Web.Settings;
using Sample.UI.Web.Utility.AutoMapper;

namespace Sample.UI.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public Startup(IConfigurationRoot configuration)
        {
            Configuration = configuration;
        }

        private IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Settings
            services.AddOptions();
            services.Configure<AppSettings>(Configuration.GetSection("Common"));

            // DbContext
            services.AddDbContext<GaiaDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbConnection")));

            // AppContext
            services.AddScoped<IAppContext, AppContext>(provider =>
            {
                var dataContext = new DataContext(provider.GetService<GaiaDbContext>());
                return new AppContext(dataContext);
            });

            // AutoMapper
            services.AddAutoMapper(cfg =>
            {
                var profiles = typeof(MappingProfileBase).GetTypeInfo()
                    .Assembly.GetTypes()
                    .Where(x => typeof(MappingProfileBase).IsAssignableFrom(x))
                    .ToArray();
                cfg.AddProfiles(profiles);
            });
            services.AddSingleton<IMapper, Mapper>();

            // Mvc
            services.AddMvc().AddMvcOptions(options =>
            {
                // InputFormatter
                var jsonInputFormatter = options.InputFormatters.OfType<JsonInputFormatter>().First();
                var messagePackInputFormatter = new MessagePackInputFormatter();
                var inputFormatter = new CompositeInputFormatter(jsonInputFormatter, messagePackInputFormatter);
                options.InputFormatters.Clear();
                options.InputFormatters.Add(inputFormatter);

                // OutputFormatter
                var jsonOutputFormatter = options.OutputFormatters.OfType<JsonOutputFormatter>().First();
                var messagePackOutputFormatter = new MessagePackOutputFormatter();
                var outputFormatter = new CompositeOutputFormatter(jsonOutputFormatter, messagePackOutputFormatter);
                options.OutputFormatters.Clear();
                options.OutputFormatters.Add(outputFormatter);

                // Filter
                options.Filters.Add(typeof(AttackDetectorFilter));
            });

            services.AddCors();

            // CsvLoad
            var csvConfig = Configuration.GetSection("CsvEntityLoader").Get<CsvEntityLoaderConfiguration>();
            csvConfig.CsvRootDirectoryPath = Path.Combine(System.AppContext.BaseDirectory, csvConfig.CsvRootDirectoryPath);
            var csvRelations = CsvEntityLoader.Load(csvConfig);
            CsvEntityInjector.Inject(csvRelations);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc(builder =>
            {
#if DEBUG
                builder.MapAreaRoute("test", "Test", "{controller}/{action=Index}/{id?}");
#endif
                builder.MapRoute("default", "{controller}/{action}/{id?}");
            });
        }
    }
}

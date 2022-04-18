using Blazor.FacileBudget.DataAccess.Models.Services.Application;
using Blazor.FacileBudget.DataAccess.Models.Services.Infrastructure;
using Blazor.FacileBudget.Server.Models.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Blazor.FacileBudget.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            services.AddDbContextPool<FacileBudgetDbContext>(optionsBuilder =>
            {
                string connectionString = Configuration.GetSection("ConnectionStrings").GetValue<string>("Default");
                optionsBuilder.UseSqlite(connectionString);
            });

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Blazor.FacileBudget",
                    Version = "v1",
                    Description = "API that allows budget management",
                    // TermsOfService = new Uri("https://example.com/terms"), 

                    //Contact = new OpenApiContact
                    //{
                    //    Name = "Nominativo contatto",
                    //    Email = "Email contatto",
                    //    Url = new Uri("https://twitter.com/username-contatto"),
                    //},

                    // License = new OpenApiLicense
                    // {
                    //     Name = "Nome licenza API",
                    //     Url = new Uri("https://example.com/license"),
                    // }
                });
            });

            services.AddTransient<ISpesaService, EfCoreSpesaService>();

            services.AddSingleton<ITransactionLogger, LocalTransactionLogger>();
        }

        public void Configure(WebApplication app)
        {
            IWebHostEnvironment env = app.Environment;
            IHostApplicationLifetime lifetime = app.Lifetime;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();

                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blazor.FacileBudget v1"));
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();

            app.UseStaticFiles();
            app.UseRouting();

            app.UseCors("CorsPolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
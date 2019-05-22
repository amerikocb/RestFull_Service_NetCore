using AngularNetCore.BusinessLogic.Implementations;
using AngularNetCore.BusinessLogic.Interfaces;
using AngularNetCore.DataAccess;
using AngularNetCore.UnitOfWork;
using AngularNetCore.WebApi.Authentication;
using AngularNetCore.WebApi.GlobalErrorHandling;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AngularNetCore.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ISupplierLogic, SupplierLogic>();
            services.AddTransient<IOrderLogic, OrderLogic>();
            services.AddTransient<ICustomerLogic, CustomerLogic>();
            services.AddTransient<ITokenLogic, TokenLogic>();

            services.AddSingleton<IUnitOfWork>(option => new AngularNetCoreUnitOfWork(
                Configuration.GetConnectionString("Northwind")
                ));

            var tokenProvider = new JwtProvider("issuer", "audience", "nothwind_2000");
            services.AddSingleton<ITokenProvider>(tokenProvider);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = tokenProvider.GetValidationParameters();
                });
            services.AddAuthorization(auth =>
            {
                auth.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();
            });
            //Controlar Erores COR en Localhost
            string[] paramCors = { "http://localhost:4200", "http://192.168.0.9:82" };
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins(paramCors)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.ConfigureExceptionHandler();
            app.UseCors("CorsPolicy"); //CORS
            app.UseMvc();
        }
    }
}

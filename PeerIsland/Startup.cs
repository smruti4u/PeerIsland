namespace PeerIsland
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using PeerIsland.Common;
    using PeerIsland.Entities.Extensions.Employees;
    using PeerIsland.Entities.ViewModel;
    using PeerIsland.Extensions;
    using PeersIsland.DataAccess;
    using PeersIsland.DataAccess.Repositories;
    using PeersIsland.DataAccess.Services;
    using Swashbuckle.AspNetCore.Swagger;

    /// <summary>
    /// Startup Class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Gets apiName.
        /// </summary>
        private string ApiName => "PeersIsland.API";

        /// <summary>
        /// Gets SwaggerEndPoint.
        /// </summary>
        private string SwaggerEndPoint => "/swagger/v1/swagger.json";

        /// <summary>
        /// Gets apiVersion.
        /// </summary>
        private string ApiVersion => "v1";

        /// <summary>
        /// The Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration">The configuration</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">IServiceCollection</param>        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(this.ApiVersion, new Info { Title = this.ApiName, Version = this.ApiVersion });
            });

            this.serviceRegistration(services);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        /// <summary>
        /// ervice Registration For Dependency Injenction
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        private void serviceRegistration(IServiceCollection services)
        {
            //Service Registration For Dependency Injenction for problem 1
            services.AddTransient<IEmployeeRepository<Employee>, EmployeeRepository<Employee>>();
            services.AddTransient<IEmployeeDbContext<Employee>, EmployeeDbContext<Employee>>();
            services.AddTransient<IXmlService, XmlService>();
            services.AddTransient<IEmployeeManager<Employee>, EmployeeManager<Employee>>();

            //Service Registration For Dependency Injenction for problem 2
            services.AddTransient<IEmployeeRepository<EmployeeExtensions>, EmployeeRepository<EmployeeExtensions>>();
            services.AddTransient<IEmployeeDbContext<EmployeeExtensions>, EmployeeDbContext<EmployeeExtensions>>();
            services.AddTransient<IXmlService, XmlService>();
            services.AddTransient<IEmployeeManager<EmployeeExtensions>, EmployeeManager<EmployeeExtensions>>();
        }

        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="app">IApplicationBuilder</param>
        /// <param name="env">IHostingEnvironment</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            this.UseSwagger(app, env);
            app.UseCustumErrorHandling();
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }

        /// <summary>
        /// Setup for Swagger Generation
        /// </summary>
        /// <param name="app">The App</param>
        /// <param name="env">The Env</param>
        protected virtual void UseSwagger(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(options =>
            {
                options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(this.SwaggerEndPoint, this.ApiName);
                c.RoutePrefix = string.Empty;
            });
        }
    }
}

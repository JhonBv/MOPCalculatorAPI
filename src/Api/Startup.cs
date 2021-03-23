using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MOP.Calculator.API.Configuration;
using MOP.Calculator.API.Extensions;
using System;
using System.IO;
using System.Reflection;

namespace MOP.Calculator
{

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            var PluginStore = Configuration.GetSection("PluginStoreUri");
            services.Configure<PluginStoreConfiguration>(PluginStore);

            services.ConfigureCalculatorServices();
            services.ConfigureLoggerService();
            services.AddSingleton<IPluginConfigurationWrapper, PluginConfigurationWrapper>();
            services.AddControllers();
            
            //Swagger Configuration
            services.AddSwaggerGen(c =>
            {
                //Generate some basic instructions on the Swager index page
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MOP Calculator Api",
                    Version = "v1",
                    Description = "Masters of Pie Calculator API is an internal API which allows developers to test Calculator plugins.<br/> <b>Instructions</b>" +
                    "<p>Click on 'Home/calculator' then click on 'Try it Out'. Then change the values as follows:</p>" +
                    "<b>operations variable:</b>" +
                    "<ul>" +
                    "<li>1: Performs Addition</li>" +
                    "<li>2: Performs Substruction</li>" +
                    "<li>3: Performs Multiplication</li>" +
                    "<li>4: Performs Divition</li>" +
                    "</ul>" +
                    "<b>Calculation variables</b>" +
                    "<ul><li>firstNumber</li><li>secondNumber</li></ul>"

                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MOP (Masters of Pie) API V1 (Dev)");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

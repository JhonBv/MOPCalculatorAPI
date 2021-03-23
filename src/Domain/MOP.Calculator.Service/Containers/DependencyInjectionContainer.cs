using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MOP.Calculator.Service.Containers
{
    public static class DependencyInjectionContainer
    {
        /// <summary>
        /// Adding the "god" class
        /// </summary>
        /// <param name="services"></param>
        public static void AddMediateR(IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}

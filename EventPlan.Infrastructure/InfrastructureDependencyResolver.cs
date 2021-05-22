using EventPlan.Application.Interfaces.IServices;
using EventPlan.Infrastructure.Presistence.Contexts;
using EventPlan.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventPlan.Infrastructure
{
    public static class InfrastructureDependencyResolver
    {

        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
      {
            string connection=configuration.GetConnectionString("EventPlanDbConnection");
            services.AddDbContext<EventPlanDbcontext>(options => options.UseSqlServer(connection));
            //services.AddDbContext<EventPlanDbcontext>(options => options.UseSqlServer(configuration.GetConnectionString("EventPlanDbConnection")));

            services.AddScoped<IUserDetailService, UserDetailService>();
            services.AddScoped<IEventDetailService, EventDetailServices>();



        }
    }
}

namespace ChallengeTechAndSolve.CrossCutting.Register
{
    using ChallengeTechAndSolve.Application.Contracts.IServices;
    using ChallengeTechAndSolve.Application.Services;
    using ChallengeTechAndSolve.CrossCutting.Filters;
    using ChallengeTechAndSolve.DataAccess;
    using ChallengeTechAndSolve.DataAccess.Contracts;
    using ChallengeTechAndSolve.DataAccess.Contracts.IRepositories;
    using ChallengeTechAndSolve.DataAccess.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public static class IoCRegister
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {

            services.AddRegisterServices();
            services.AddRegisterRepositories();
            services.AddRegisterOthers();
            return services;
        }
        /// <summary>
        /// Add Register Services
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        private static IServiceCollection AddRegisterServices(this IServiceCollection services)
        {
            services.AddTransient<ITraceabilityService, TraceabilityService>();
            services.AddTransient<IProcessInformationService, ProcessInformationService>();
            services.AddSingleton<ILogService, LogService>();
            return services;
        }
        /// <summary>
        /// Add Register Repositories
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        private static IServiceCollection AddRegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<ITraceabilityRepository, TraceabilityRepository>();
            return services;
        }
        /// <summary>
        /// Add Register Others
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        private static IServiceCollection AddRegisterOthers(this IServiceCollection services)
        {
            IServiceProvider serviceProvider   = services.BuildServiceProvider();
            IConfiguration _configuration = serviceProvider.GetService<IConfiguration>();
            services.AddTransient<IChallengeTechAndSolveDBContext, ChallengeTechAndSolveDBContext>();
            services.AddDbContext<ChallengeTechAndSolveDBContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DataBaseConnection")));
            var logService = serviceProvider.GetService<ILogService>();
            services.AddMvc(options =>
            {
                options.Filters.Add(new HandleExceptionAttribute(logService));
            });
            return services;
        }
    }
}

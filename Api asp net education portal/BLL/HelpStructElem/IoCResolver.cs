using BLL.Interfaces;
using BLL.Services;
using DAL.DBExt;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Text;



namespace BLL
{
    public class IoCResolver
    {
        /// <summary>
        /// DI Register from DAL and BLL
        /// </summary>
        public static void Load(IServiceCollection services)
        {
            services.AddScoped<ProtalDbContext>();
            services.AddScoped<IAccountService,AccountService>();
            services.AddScoped<IRepository, EfRepository>();
            services.AddScoped<IUserSkillService, UserSkillService>();
            services.AddScoped<IAutorBookService, AutorBookService>();
            services.AddScoped<IAutorService, AutorService>();
            services.AddScoped<ICourseMaterialService, CourseMaterialService>();
            services.AddScoped<ICourseUserService, CourseUserService>();
            services.AddScoped<IMaterialSkillService, MaterialSkillService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMaterialService, MaterialService>();

        }
    }
}

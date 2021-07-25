//using BLL.Interfaces;
//using BLL.Services;
//using DAL.DBExt;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace PL.ServicesExtensions
//{
//    static public class RegistrationOfInversions
//    {
//        public static IServiceCollection AddDependensys(this IServiceCollection services)
//        {
//            services.AddScoped<IRepository, EfRepository>();
//            services.AddScoped<AccountService>();
//            services.AddScoped<IUserSkillService, UserSkillService>();
//            services.AddScoped<IAutorBookService, AutorBookService>();
//            services.AddScoped<IAutorService, AutorService>();
//            services.AddScoped<ICourseMaterialService, CourseMaterialService>();
//            services.AddScoped<ICourseUserService, CourseUserService>();
//            services.AddScoped<IMaterialSkillService, MaterialSkillService>();
//            services.AddScoped<ICourseService, CourseService>();
//            services.AddScoped<ISkillService, SkillService>();
//            services.AddScoped<IUserService, UserService>();
//            services.AddScoped<IMaterialService, MaterialService>();


//            //services.AddScoped<AutorModelValidator>();
//            //services.AddScoped <BookModellValidator>();
//            //services.AddScoped<CourseModelValidator>();
//            return services;
//        }
//    }
//}

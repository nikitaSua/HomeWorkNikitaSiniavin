using BLL.Abstractions.Interfaces;
using BLL.Services;
using DAL.Abstractions.Interfaces;
using DAL.Services;
using SimpleInjector;
using System;

namespace IoCResolver
{
    
    public static class DIRegistration
    {
        public static void Load(Container container)
        {
            container.Register<IUserService, UserService>(Lifestyle.Transient);
            container.Register<IRepository, UserRepository>(Lifestyle.Transient);
        }
    }
}

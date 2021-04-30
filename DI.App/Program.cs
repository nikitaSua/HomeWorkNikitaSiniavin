using DI.App.Abstractions;
using DI.App.Abstractions.BLL;
using DI.App.Services;
using DI.App.Services.PL;
using DI.App.Services.PL.Commands;
using SimpleInjector;

namespace DI.App
{
    internal class Program
    {
        private static void Main()
        {
            var container = new Container();
            container.Register<IDatabaseService, InMemoryDatabaseService>(Lifestyle.Transient);
            container.Register<ICommandProcessor, CommandProcessor>(Lifestyle.Transient);
            container.Register<IUserStore, UserStore>(Lifestyle.Transient);
            container.RegisterConditional<ICommand, ListUsersCommand>(
                c => c.Consumer.Target.Parameter.Name.Contains("addUsers"));
            container.RegisterConditional<ICommand, AddUserCommand>(
                c => c.Consumer.Target.Parameter.Name.Contains("listUsers"));
            container.Register<CommandManager>();
            container.Verify();
            var service = container.GetInstance<CommandManager>();
            service.Start();
            // Inversion of Control
            //var manager = new CommandManager();

            //manager.Start();
        }
    }
}

using System;
using Ninject.Modules;
using TransportApp.DAL.Interfaces;
using TransportApp.DAL.Repositories;

namespace TransportApp.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        }

    }
}

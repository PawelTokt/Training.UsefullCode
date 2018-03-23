using Autofac;
using Soccer.Data;
using Soccer.Data.Interfaces;

namespace Soccer.Business.Modules
{
    public class BusinessModule : Module
    {
        private readonly string _connectionString;

        public BusinessModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.Register(x => new UnitOfWork(_connectionString)).As<IUnitOfWork>();
        }
    }
}
using Autofac;
using Soccer.Business;
using Soccer.Business.Contract;

namespace Soccer.Web.Modules
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<TeamService>().As<ITeamService>();
            containerBuilder.RegisterType<PlayerService>().As<IPlayerService>();
        }
    }
}
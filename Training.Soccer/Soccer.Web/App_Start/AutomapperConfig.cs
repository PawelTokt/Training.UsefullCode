using AutoMapper;
using System.Reflection;

namespace Soccer.Web
{
    public class AutomapperConfig
    {
        public static void InitializeAutoMapper()
        {
            Mapper.Initialize(profile =>
            {
                profile.AddProfiles(
                    Assembly.Load("Soccer.Business"),
                    Assembly.Load("Soccer.Web"));
            });
        }
    }
}
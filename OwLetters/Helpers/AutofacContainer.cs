using Autofac;
using OwLetter.Service;
using OwLetter.Service.Interfaces;

namespace OwLetter.Helpers
{
    public class AutofacContainer
    {
        public static IContainer Create()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<JsonManager>();
            builder.RegisterType<JsonSerializer>().As<IJsonSerializer>();
            return builder.Build();
        }
    }
}

using System.Reflection;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Autofac.Extras.Moq;
using CommonServiceLocator;
using Moq;

namespace ENSEK_Techincal_TestyTest
{
    public class BaseTest
    {
        protected virtual void RegisterDependencies()
        {
            using (AutoMock mock = AutoMock.GetStrict())
            {

                ContainerBuilder builder = new ContainerBuilder();

                ConfigureDependencyInjection(builder);

                OverrideDependenciesWithMocks(mock, builder);

                IContainer container = builder.Build();

                // Set the service locator to an AutofacServiceLocator.
                AutofacServiceLocator serviceLocator = new AutofacServiceLocator(container);
                ServiceLocator.SetLocatorProvider(() => serviceLocator);
            }
        }

        protected virtual void ConfigureDependencyInjection(ContainerBuilder builder)
        {
            Assembly assembly = Assembly.Load("ENSEK Technical Test");

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => (t.Name.EndsWith("Factory")
                             || t.Name.EndsWith("Repository")
                             || t.Name.EndsWith("Mapper")
                             || t.Name.EndsWith("Service"))).AsImplementedInterfaces().SingleInstance();
        }

        protected virtual void OverrideDependenciesWithMocks(AutoMock mock, ContainerBuilder builder)
        {
            //Override to mock individual interfaces :)
        }
    }

    
}

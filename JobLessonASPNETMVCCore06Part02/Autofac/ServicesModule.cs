using Autofac;
using JobLessonASPNETMVCCore06v02.Services;
using JobLessonASPNETMVCCore06v02.Services.Impl;

namespace JobLessonASPNETMVCCore06v02.Autofac
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<OrderService>()
            .As<IOrderService>()
            .InstancePerLifetimeScope();
        }
    }
}

using Volo.Abp;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Zhang.Domain.Modules;

[DependsOn(
    typeof(AbpDddDomainModule)
)]
public class DomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var serivices = context.Services;
    }
}